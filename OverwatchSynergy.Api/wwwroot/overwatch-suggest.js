var HeroViewModel = function (hero, calculatorViewModel, team) {
    this.Name = hero.Name;

    this.GetBackgroundImage = function () {
        return "url('img/" + hero.Id + ".png')";
    }

    this.Add = function () {
        calculatorViewModel.SelectedTeam.push(new HeroViewModel(hero, calculatorViewModel, calculatorViewModel.SelectedTeam));
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
    this.SelectedTeam = [];

    this.AvailableHeroes = heroesJson.map(function (hero) {
        return new HeroViewModel(hero, _this);
    });

    this.WeightedSuggestions = ko.observable([]);

    this.AddTeammates = function() {
        this.SelectedTeam = this.Teammates;
    }

    this.AddOpponents = function () {
        this.SelectedTeam = this.Opponents;
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
            _this.WeightedSuggestions(data.sort(function (a, b) { return b.Value - a.Value; })
                                          .slice(0,3)
                                          .map(function (weight) { return { Weight: weight.Value, Hero: new HeroViewModel(weight.Hero, _this) } })
                                      );
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