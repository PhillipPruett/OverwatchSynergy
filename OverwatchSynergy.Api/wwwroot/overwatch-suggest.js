var HeroViewModel = function (hero, calculatorViewModel, team) {
    this.Name = hero.Name;

    this.GetBackgroundImage = function () {
        if (hero.Id) {
            return "url('img/" + hero.Id + ".png')";
        }
        return "none"
    }

    this.GetClass = function () {
        if (!hero.Id) {
            return "empty";
        }
    }

    this.Add = function () {
        calculatorViewModel.SelectedTeam.push(new HeroViewModel(hero, calculatorViewModel, calculatorViewModel.SelectedTeam));
    }

    this.Click = function () {
        if (!hero.Id) {
            calculatorViewModel.SelectedTeam = team;
        }
        if (team && typeof(team.remove) === 'function') {
            team.remove(this);
        }
    }
}

var CalculatorViewModel = function (heroesJson) {
    var _this = this,
        opponents = ko.observableArray(),
        teammates = ko.observableArray(),
        suggestions = ko.observable([]);

    var addEmpties = function (currentTeam) {
        var team = currentTeam.slice(0);
        for (var i = team.length; i < 6; i++) {
            team.push(new HeroViewModel(
                {
                    Name: "Add Hero",
                    
                },
                _this,
                currentTeam));
        }
        return team;
    }

    this.SelectedTeam = [];

    this.AvailableHeroes = heroesJson.map(function (hero) {
        return new HeroViewModel(hero, _this);
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
                return {
                    Weight: weight.Value,
                    Hero: new HeroViewModel(weight.Hero, _this)
                }
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