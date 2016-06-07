var HeroViewModel = function(hero, calculatorViewModel, team) {
    this.Name = hero.Name;

    this.GetBackgroundImage = function() {
        return "url('img/" + hero.Id + ".png')";
    }

    this.AddAsOpponent = function() {
        if (calculatorViewModel.Opponents().length >= 6) {
            return;
        }
        calculatorViewModel.Opponents.push(new HeroViewModel(hero, calculatorViewModel, calculatorViewModel.Opponents));
    }

    this.AddAsTeammate = function() {
        if (calculatorViewModel.Teammates().length >= 6) {
            return;
        }
        calculatorViewModel.Teammates.push(new HeroViewModel(hero, calculatorViewModel, calculatorViewModel.Teammates));
    }

    this.Remove = function() {
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