var HeroViewModel = function (hero, calculatorViewModel, team) {
    this.Name = hero.Name;

    this.AddAsOpponent = function () {
        calculatorViewModel.Opponents.push(new HeroViewModel(hero, calculatorViewModel, calculatorViewModel.Opponents));
    }

    this.AddAsTeammate = function () {
        calculatorViewModel.Teammates.push(new HeroViewModel(hero, calculatorViewModel, calculatorViewModel.Teammates));
    }

    this.Remove = function () {
        if (team && typeof(team.remove) === 'function') {
            team.remove(this);
        }
    }
}

var CalculatorViewModel = function (heroesJson) {
    var _this = this;

    this.Opponents = ko.observableArray();
    this.Teammates = ko.observableArray();
    this.AvailableHeroes = heroesJson.map(function (hero) {
        return new HeroViewModel(hero, _this);
    });
    this.WeightedSuggestions = ko.observable([]);

    function updateScores(newScores) {

    }

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
            _this.WeightedSuggestions(data.sort(function (a, b) { return b.Value - a.Value; }))
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