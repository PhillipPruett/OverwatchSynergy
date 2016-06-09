var TeamMemberViewModel = function (hero, calculatorViewModel, team) {
    this.Name = hero.Name;

    this.IsEmpty = hero.Id === undefined;

    this.GetBackgroundImage = function () {
        if (!this.IsEmpty) {
            return "url('img/" + hero.Id + ".png')";
        }
        return "none"
    }

    this.GetClass = function () {
        if (!hero.Id) {
            if (this.IsAdding) {
                return "adding";
            }
            return "empty";
        }
    }

    this.Click = function () {
        if (!hero.Id) {
            calculatorViewModel.SelectedTeam(team);
        }
        if (team && typeof(team.remove) === 'function') {
            team.remove(this);
        }
    }

}

var AvailableHeroViewModel = function (hero, calculatorViewModel) {
    var _this = this;

    this.Name = hero.Name;

    this.GetBackgroundImage = function () {
        return "url('img/" + hero.Id + ".png')";
    }

    this.Add = function () {
        if (calculatorViewModel.SelectedTeam()().length < 6) {
            calculatorViewModel.SelectedTeam().push(new TeamMemberViewModel(hero, calculatorViewModel, calculatorViewModel.SelectedTeam()));
        }
    }
}

var SuggestedHeroViewModel = function (hero, weight) {
    this.Name = hero.Name;
    this.GetBackgroundImage = function () {
        return "url('img/" + hero.Id + ".png')";
    }
    this.Weight = weight;
}

var CalculatorViewModel = function (heroesJson) {
    var _this = this,
        opponents = ko.observableArray(),
        teammates = ko.observableArray(),
        suggestions = ko.observable([]);

    var addEmpties = function (currentTeam) {
        var team = currentTeam.slice(0);
        for (var i = team.length; i < 6; i++) {
            var teamMemberViewModel = new TeamMemberViewModel(
                {
                    Name: "Add Hero",
                },
                _this,
                currentTeam);

            team.push(teamMemberViewModel);
        }
        return team;
    }

    this.SelectedTeam = ko.observable([]);

    this.AvailableHeroes = heroesJson.map(function (hero) {
        return new AvailableHeroViewModel(hero, _this);
    });

    this.OpponentsView = ko.pureComputed(function() {
        return addEmpties(opponents);
    });

    this.TeammatesView = ko.pureComputed(function () {
        return addEmpties(teammates);
    });

    this.SuggestionsView = ko.pureComputed(function () {
        return suggestions()
            .slice(0, 3)
            .map(function (weight) {
                return new SuggestedHeroViewModel(weight.Hero, weight.Value)
                
            });
    });

    function getUpdatedScores() {
        var data = {
            Opponents: opponents().map(function (h) { return h.Name; }),
            Teammates: teammates().map(function (h) { return h.Name; }),
        }
        return $.post({
            url: "../calculator/GetOverallScoresForAllHeroes",
            data: JSON.stringify(data),
            contentType: "application/json"
        }).done(function (data) {
            suggestions(data.sort(function (a, b) { return b.Value - a.Value; }));
        });
    }

    opponents.subscribe(getUpdatedScores);
    teammates.subscribe(getUpdatedScores);
};

$(document).ready(function () {
    $.getJSON("../heroes/")
        .done(function (data) {
            ko.applyBindings(new CalculatorViewModel(data));
        });
});