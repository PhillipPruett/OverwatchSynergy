var HeroViewModel = function (hero, calculatorViewModel) {
    this.Name = hero.Name;

    this.AddEnemy = function (enemy) {
        calculatorViewModel.Enemies.push(enemy.Name);
    }

    this.AddAlly = function (ally) {
        console.log("adding " + JSON.stringify(ally) + "as ally");
    }
}

var CalculatorViewModel = function (heroesJson) {
    var calculatorViewModel = this;

    this.HeroViewModels = heroesJson.map(function (hero) {
        return new HeroViewModel(hero, calculatorViewModel);
    });
    this.Enemies = ko.observableArray();
    this.Enemies.subscribe(function (enemies) {
        $.post({
            url: "../calculator/GetHeroesStrengthAgainst",
            data: JSON.stringify(enemies),
            contentType: "application/json"
        })
        .done(function (data) {
            console.log(JSON.stringify(data));
        })
    });
};

$(document).ready(function () {
    $.getJSON("../heroes/")
        .done(function (data) {
            ko.applyBindings(new CalculatorViewModel(data));
        });
});