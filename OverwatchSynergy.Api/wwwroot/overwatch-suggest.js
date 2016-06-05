var HeroViewModel = function (hero) {
    this.Name = hero.Name;

    this.AddEnemy = function (enemy) {
        console.log("adding " + JSON.stringify(enemy) + "as enemy");
    }

    this.AddAlly = function (ally) {
        console.log("adding " + JSON.stringify(ally) + "as ally");
    }
}

var ViewModel = function (heroesJson) {
    this.HeroViewModels = heroesJson.map(function (hero) {
        return new HeroViewModel(hero);
    });
};

$(document).ready(function () {
    $.getJSON("../heroes/")
        .done(function (data) {
            ko.applyBindings(new ViewModel(data));
        });
});