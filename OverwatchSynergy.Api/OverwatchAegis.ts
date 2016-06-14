var TeamSlot = function (calculatorViewModel) {
    var _this = this;

    this.Hero = ko.observable(null);
    this.IsSelected = ko.observable(false);

    this.Name = ko.computed(function () {
        var hero = ko.unwrap(_this.Hero);
        return hero && hero.Name;
    });
    
    this.BackgroundImage = ko.pureComputed(function () {
        var hero = ko.unwrap(_this.Hero);

        if (hero) {
            return "url('img/" + hero.Id + ".png')";
        }
        return "none"
    });

    this.Class = ko.pureComputed(function () {
        if (_this.IsSelected()) {
            return "adding";
        }
        if (!_this.Hero()) {
            return "empty";
        }
    });

    this.Select = function () {
        this.Hero(null);
        calculatorViewModel.SelectedSlot(this);
    }

}

var AvailableHero = function (hero, calculatorViewModel) {
    var _this = this;

    this.Name = hero.Name;
    this.Role = hero.Role;

    this.BackgroundImage = "url('img/" + hero.Id + ".png')";
    
    this.Add = function () {
        var selectedSlot = calculatorViewModel.SelectedSlot();
        if (selectedSlot) {
            calculatorViewModel.SelectedSlot().Hero(hero);
            calculatorViewModel.SelectNextAvailableSlot();
        }
    }
}

var SuggestedHero = function (calculatorViewModel, hero, weight) {
    this.Name = hero ? hero.Name : "";
    this.Weight = weight;

    this.BackgroundImage = hero ? "url('img/" + hero.Id + ".png')" : "none";

    this.Class = !hero ? "empty" : "";

    this.Add = function () {
        calculatorViewModel.SelectNextAvailableTeammateSlot();
        calculatorViewModel.SelectedSlot().Hero(hero);
        calculatorViewModel.SelectNextAvailableSlot();
    }
}

var CalculatorViewModel = function (heroesJson) {
    var _this = this,
        suggestions = ko.observable([]);

    this.Opponents = Array(6).fill(0).map(function () { return new TeamSlot(_this); });
    this.Teammates = Array(6).fill(0).map(function () { return new TeamSlot(_this); });
        
    this.SelectedSlot = ko.observable();

    this.SelectedSlot.subscribe(function (currentSelection) {
        currentSelection && currentSelection.IsSelected(false);
    }, null, "beforeChange");
    this.SelectedSlot.subscribe(function (newSelection) {
        newSelection && newSelection.IsSelected(true);
    });

    this.SelectedSlot(this.Opponents[0]);

    this.SelectNextAvailableSlot = function () {
        var currentSelection = this.SelectedSlot();
        var isOpponentSelected = this.Opponents.some(function (t) {
            return t === currentSelection
        });
        if (isOpponentSelected) {
            var nextAvailableSlot = this.Opponents.find(function (t) {
                return t.Hero() == null;
            });
            this.SelectedSlot(nextAvailableSlot);
        }

        var isTeammateSelected = this.Teammates.some(function (t) {
            return t === currentSelection
        });
        if (isTeammateSelected) {
            var nextAvailableSlot = this.Teammates.find(function (t) {
                return t.Hero() == null;
            });
            this.SelectedSlot(nextAvailableSlot);
        }
    }

    this.SelectNextAvailableTeammateSlot = function () {
        var nextAvailableSlot = this.Teammates.find(function (t) {
            return t.Hero() == null;
        });
        this.SelectedSlot(nextAvailableSlot);
    }

    this.AvailableHeroes = heroesJson.map(function (hero) {
        return new AvailableHero(hero, _this);
    });

    var roles = ["Attack", "Defense", "Tank", "Support"];

    this.AvailableHeroesByRole = roles.map(function (role) {
        return {
            Role: role,
            AvailableHeroes: _this.AvailableHeroes.filter(function(hero){
                return hero.Role == role;
            })
        }
    });

    this.Suggestions = ko.pureComputed(function () {
        var noHeroesAreSelected = !_this.Opponents.concat(_this.Teammates).some(function (s) { return s.Hero() });
        if (noHeroesAreSelected) {
            return Array(3).fill(new SuggestedHero(_this))
        }

        return suggestions()
            .slice(0, 3)
            .map(function (weight) {
                return new SuggestedHero(_this, weight.Hero, weight.Value)
            });
    });

    this.UpdateScores = function() {
        var data = {
            Opponents: _this.Opponents.map(function (h) { return h.Name(); }),
            Teammates: _this.Teammates.map(function (h) { return h.Name(); }),
        }
        return $.post({
            url: "../calculator/GetOverallScoresForAllHeroes",
            data: JSON.stringify(data),
            contentType: "application/json"
        }).done(function (data) {
            suggestions(data.sort(function (a, b) { return b.Value - a.Value; }));
        });
    }

    this.Opponents.concat(this.Teammates).forEach(function (slot) {
        slot.Hero.subscribe(_this.UpdateScores);
    });
};

$(document).ready(function () {
    $.getJSON("../heroes/")
        .done(function (data) {
            ko.applyBindings(new CalculatorViewModel(data));
        });
});