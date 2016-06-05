var HeroViewModel = function (hero, calculatorViewModel) {
    this.Name = hero.Name;

    this.AddAsEnemy = function (enemy) {
        calculatorViewModel.Enemies.push(enemy.Name);
    }

    this.AddAsAlly = function (ally) {
        calculatorViewModel.Allies.push(ally.Name);
    }
}

var CalculatorViewModel = function (heroesJson) {
    var calculatorViewModel = this;

    this.HeroViewModels = heroesJson.map(function (hero) {
        return new HeroViewModel(hero, calculatorViewModel);
    });

    var _counterWeights = ko.observable([]);
    var _synergyWeights = ko.observable([]);
    var getWeightMap = function (weights) {
        var map = {};
        for (weight of weights) {
            map[weight.Hero.Name] = weight.Value;
        }
        return map;
    }

    var combineWeights = function (counter, synergy) {
        if (counter === undefined && synergy === undefined) {
            return 50;
        }
        if (counter === undefined) {
            return synergy;
        }
        if (synergy === undefined) {
            return counter;
        }
        return (counter + synergy) / 2
    }

    this.Enemies = ko.observableArray();
    this.Enemies.subscribe(function (enemies) {
        $.post({
            url: "../calculator/GetHeroesStrengthAgainst",
            data: JSON.stringify(enemies),
            contentType: "application/json"
        })
        .done(function (data) {
            _counterWeights(getWeightMap(data));
        })
    });

    this.Allies = ko.observableArray();
    this.Allies.subscribe(function (allies) {
        $.post({
            url: "../calculator/GetHeroesThatHaveSynergiesWith",
            data: JSON.stringify(allies),
            contentType: "application/json"
        })
        .done(function (data) {
            _synergyWeights(getWeightMap(data));
        })
    });

    this.WeightedSuggestions = ko.computed(function () {
        var counterWeights = ko.unwrap(_counterWeights),
            synergyWeights = ko.unwrap(_synergyWeights),
            allWeights = [];
        for (hero of heroesJson) {
            allWeights.push({
                Name: hero.Name,
                Weight: combineWeights(counterWeights[hero.Name], synergyWeights[hero.Name])
            });
        }
        return allWeights.sort(function(a,b){return b.Weight - a.Weight;});
    });
};

$(document).ready(function () {
    $.getJSON("../heroes/")
        .done(function (data) {
            ko.applyBindings(new CalculatorViewModel(data));
        });
});