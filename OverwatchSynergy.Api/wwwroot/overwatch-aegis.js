class AvailableHero {
    constructor(hero, calculatorViewModel) {
        this.hero = hero;
        this.calculatorViewModel = calculatorViewModel;
        this.Name = this.hero.Name;
        this.Role = this.hero.Role;
        this.BackgroundImage = "url('img/" + this.hero.Id + ".png')";
        this.Add = () => {
            var selectedSlot = this.calculatorViewModel.SelectedSlot();
            if (selectedSlot) {
                this.calculatorViewModel.SelectedSlot().Hero(this.hero);
                this.calculatorViewModel.SelectNextAvailableSlot();
            }
        };
    }
}
class CalculatorViewModel {
    constructor(heroesJson) {
        this.heroesJson = heroesJson;
        this.suggestions = ko.observable([]);
        this.Opponents = new Array();
        this.Teammates = new Array();
        this.SelectedSlot = ko.observable();
        this.SelectNextAvailableSlot = () => {
            var currentSelection = this.SelectedSlot();
            var isOpponentSelected = this.Opponents.some(t => {
                return t === currentSelection;
            });
            if (isOpponentSelected) {
                var nextAvailableSlot = this.Opponents.find(t => {
                    return t.Hero() == null;
                });
                this.SelectedSlot(nextAvailableSlot);
            }
            var isTeammateSelected = this.Teammates.some(t => {
                return t === currentSelection;
            });
            if (isTeammateSelected) {
                var nextAvailableSlot = this.Teammates.find(t => {
                    return t.Hero() == null;
                });
                this.SelectedSlot(nextAvailableSlot);
            }
        };
        this.SelectNextAvailableTeammateSlot = () => {
            var nextAvailableSlot = this.Teammates.find(t => {
                return t.Hero() == null;
            });
            this.SelectedSlot(nextAvailableSlot);
        };
        this.Suggestions = ko.pureComputed(() => {
            var noHeroesAreSelected = !this.Opponents.concat(this.Teammates).some(s => s.Hero() != null);
            if (noHeroesAreSelected) {
                return new Array(3).fill(new SuggestedHero(this));
            }
            return this.suggestions()
                .slice(0, 3)
                .map(weight => {
                return new SuggestedHero(this, weight.Hero, weight.Value);
            });
        });
        this.UpdateScores = () => {
            var data = {
                Opponents: this.Opponents.map(function (h) { return h.Name(); }),
                Teammates: this.Teammates.map(function (h) { return h.Name(); }),
            };
            return $.post({
                url: "../calculator/GetOverallScoresForAllHeroes",
                data: JSON.stringify(data),
                contentType: "application/json"
            }).done(data => {
                this.suggestions(data.sort(function (a, b) { return b.Value - a.Value; }));
            });
        };
        this.SelectedSlot.subscribe(function (currentSelection) {
            currentSelection && currentSelection.IsSelected(false);
        }, null, "beforeChange");
        this.SelectedSlot.subscribe(function (newSelection) {
            newSelection && newSelection.IsSelected(true);
        });
        var AvailableHeroes = heroesJson.map(hero => {
            return new AvailableHero(hero, this);
        });
        let roles = ["Attack", "Defense", "Tank", "Support"];
        this.AvailableHeroesByRole = roles.map(role => {
            return {
                Role: role,
                AvailableHeroes: AvailableHeroes.filter(hero => {
                    return hero.Role == role;
                })
            };
        });
        for (var i = 0; i < 6; i++) {
            this.Opponents.push(new TeamSlot(this));
            this.Teammates.push(new TeamSlot(this));
        }
        this.SelectedSlot(this.Opponents[0]);
    }
    ;
}
;
$(document).ready(function () {
    $.getJSON("../heroes/")
        .done(function (data) {
        ko.applyBindings(new CalculatorViewModel(data));
    });
});
class SuggestedHero {
    constructor(calculatorViewModel, hero, Weight) {
        this.calculatorViewModel = calculatorViewModel;
        this.hero = hero;
        this.Weight = Weight;
        this.Name = this.hero ? this.hero.Name : "";
        this.BackgroundImage = this.hero ? "url('img/" + this.hero.Id + ".png')" : "none";
        this.Class = !this.hero ? "empty" : "";
        this.Add = () => {
            this.calculatorViewModel.SelectNextAvailableTeammateSlot();
            this.calculatorViewModel.SelectedSlot().Hero(this.hero);
            this.calculatorViewModel.SelectNextAvailableSlot();
        };
    }
}
class TeamSlot {
    constructor(calculatorViewModel) {
        this.calculatorViewModel = calculatorViewModel;
        this.Hero = ko.observable(null);
        this.IsSelected = ko.observable(false);
        this.Name = ko.computed(() => {
            var hero = ko.unwrap(this.Hero);
            return hero && hero.Name;
        });
        this.BackgroundImage = ko.pureComputed(() => {
            var hero = ko.unwrap(this.Hero);
            if (hero) {
                return "url('img/" + hero.Id + ".png')";
            }
            return "none";
        });
        this.Class = ko.pureComputed(() => {
            if (this.IsSelected()) {
                return "adding";
            }
            if (!this.Hero()) {
                return "empty";
            }
        });
        this.Select = () => {
            this.Hero(null);
            this.calculatorViewModel.SelectedSlot(this);
        };
        this.Hero.subscribe(calculatorViewModel.UpdateScores);
    }
}
//# sourceMappingURL=overwatch-aegis.js.map