var TeamSlotViewModel = function (calculatorViewModel) {
    var _this = this;

    this.Hero = ko.observable();
    this.Name = ko.pureComputed(function () {
        var hero = ko.unwrap(this.Hero);
        return hero && hero.Name;
    });
    this.IsSelected = ko.observable(false);

    this.GetBackgroundImage = function () {
        var hero = ko.unwrap(this.Hero);

        if (hero) {
            return "url('img/" + hero.Id + ".png')";
        }
        return "none"
    }

    this.GetClass = function () {
        if (this.IsSelected()) {
            return "adding";
        }
        if (!this.Hero()) {
            return "empty";
        }
    }

    this.Click = function () {
        this.Hero(null);
        calculatorViewModel.SelectedSlot(this);
    }

}

var AvailableHeroViewModel = function (hero, calculatorViewModel) {
    var _this = this;

    this.Name = hero.Name;

    this.GetBackgroundImage = function () {
        return "url('img/" + hero.Id + ".png')";
    }

    this.Add = function () {
        var selectedSlot = calculatorViewModel.SelectedSlot();
        if (selectedSlot) {
            calculatorViewModel.SelectedSlot().Hero(hero);
            calculatorViewModel.SelectNextAvailableSlot();
        }
    }
}

var SuggestedHeroViewModel = function (hero, weight) {
    this.Name = hero ? hero.Name : "";
    this.Weight = weight;

    this.IsEmpty = !hero;

    this.GetBackgroundImage = function () {
        if (!this.IsEmpty) {
            return "url('img/" + hero.Id + ".png')";
        }
        return "none"
    }

    this.GetClass = function () {
        if (this.IsEmpty) {
            return "empty";
        }
    }
}

var CalculatorViewModel = function (heroesJson) {
    var _this = this,
        suggestions = ko.observable([]);

    this.Opponents = ko.observableArray(Array(6).fill(0).map(function () { return new TeamSlotViewModel(_this); } ));
    this.Teammates = ko.observableArray(Array(6).fill(0).map(function () { return new TeamSlotViewModel(_this); }));
        
    this.SelectedSlot = ko.observable(this.Opponents()[0]);

    this.SelectedSlot.subscribe(function (currentSelection) {
        currentSelection && currentSelection.IsSelected(false);
    }, null, "beforeChange");
    this.SelectedSlot.subscribe(function (newSelection) {
        newSelection && newSelection.IsSelected(true);
    });

    this.SelectNextAvailableSlot = function () {
        var currentSelection = this.SelectedSlot();
        var isOpponentSelected = this.Opponents().some(function (t) {
            return t === currentSelection
        });
        if (isOpponentSelected) {
            var nextAvailableSlot = this.Opponents().find(function (t) {
                return t.Hero() == null;
            });
            this.SelectedSlot(nextAvailableSlot);
        }

        var isTeammateSelected = this.Teammates().some(function (t) {
            return t === currentSelection
        });
        if (isTeammateSelected) {
            var nextAvailableSlot = this.Teammates().find(function (t) {
                return t.Hero() == null;
            });
            this.SelectedSlot(nextAvailableSlot);
        }
    }

    this.AvailableHeroes = heroesJson.map(function (hero) {
        return new AvailableHeroViewModel(hero, _this);
    });

    this.SuggestionsView = ko.pureComputed(function () {
        if (_this.Opponents().length == 0 && _this.Teammates().length == 0) {
            return Array(3).fill(new SuggestedHeroViewModel())
        }
        return suggestions()
            .slice(0, 3)
            .map(function (weight) {
                return new SuggestedHeroViewModel(weight.Hero, weight.Value)
            });
    });

    function getUpdatedScores() {
        var data = {
            Opponents: _this.Opponents().map(function (h) { return h.Name; }),
            Teammates: _this.Teammates().map(function (h) { return h.Name; }),
        }
        return $.post({
            url: "../calculator/GetOverallScoresForAllHeroes",
            data: JSON.stringify(data),
            contentType: "application/json"
        }).done(function (data) {
            suggestions(data.sort(function (a, b) { return b.Value - a.Value; }));
        });
    }

    this.Opponents.subscribe(getUpdatedScores);
    this.Teammates.subscribe(getUpdatedScores);
};

$(document).ready(function () {
    $.getJSON("../heroes/")
        .done(function (data) {
            ko.applyBindings(new CalculatorViewModel(data));
        });
});