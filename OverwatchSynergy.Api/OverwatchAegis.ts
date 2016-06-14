interface Hero {
    Name: string;
    Id: string;
    Role: string;
}

interface RoleGrouping {
    Role: string;
    AvailableHeroes: AvailableHero[];
}

interface WeightedHero {
    Value: number;
    Hero: Hero;
}

class TeamSlot {
    constructor(private calculatorViewModel: CalculatorViewModel) {
        this.Hero.subscribe(calculatorViewModel.UpdateScores);
    }

    Hero = ko.observable<Hero>(null);
    IsSelected = ko.observable(false);

    Name = ko.computed(() => {
        var hero = ko.unwrap(this.Hero);
        return hero && hero.Name;
    });
    
    BackgroundImage = ko.pureComputed(() => {
        var hero = ko.unwrap(this.Hero);

        if (hero) {
            return "url('img/" + hero.Id + ".png')";
        }
        return "none"
    });

    Class = ko.pureComputed(() => {
        if (this.IsSelected()) {
            return "adding";
        }
        if (!this.Hero()) {
            return "empty";
        }
    });

    Select = () => {
        this.Hero(null);
        this.calculatorViewModel.SelectedSlot(this);
    }
}

class AvailableHero {
    constructor(private hero: Hero, private calculatorViewModel: CalculatorViewModel) {
    }
    
    Name = this.hero.Name;
    Role = this.hero.Role;

    BackgroundImage = "url('img/" + this.hero.Id + ".png')";
    
    Add = () => {
        var selectedSlot = this.calculatorViewModel.SelectedSlot();
        if (selectedSlot) {
            this.calculatorViewModel.SelectedSlot().Hero(this.hero);
            this.calculatorViewModel.SelectNextAvailableSlot();
        }
    }
}

class SuggestedHero {
    constructor(private calculatorViewModel: CalculatorViewModel, private hero?: Hero, public Weight?: number) { }
    Name = this.hero ? this.hero.Name : "";

    BackgroundImage = this.hero ? "url('img/" + this.hero.Id + ".png')" : "none";

    Class = !this.hero ? "empty" : "";

    Add = () => {
        this.calculatorViewModel.SelectNextAvailableTeammateSlot();
        this.calculatorViewModel.SelectedSlot().Hero(this.hero);
        this.calculatorViewModel.SelectNextAvailableSlot();
    }
}

class CalculatorViewModel {
    constructor(private heroesJson: Hero[]) {
        this.SelectedSlot.subscribe(function (currentSelection) {
            currentSelection && currentSelection.IsSelected(false);
        }, null, "beforeChange");
        this.SelectedSlot.subscribe(function (newSelection) {
            newSelection && newSelection.IsSelected(true);
        });

        this.SelectedSlot(this.Opponents[0]);

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
            }
        });

        for (var i = 0; i < 6; i++) {
            this.Opponents.push(new TeamSlot(this));
            this.Teammates.push(new TeamSlot(this));
        }
    };
    
    private suggestions = ko.observable<WeightedHero[]>([]);

    Opponents: TeamSlot[];
    Teammates: TeamSlot[];

    SelectedSlot = ko.observable<TeamSlot>();

    AvailableHeroesByRole: RoleGrouping[];

    SelectNextAvailableSlot = () => {
        var currentSelection = this.SelectedSlot();
        var isOpponentSelected = this.Opponents.some(t => {
            return t === currentSelection
        });
        if (isOpponentSelected) {
            var nextAvailableSlot = this.Opponents.find(t => {
                return t.Hero() == null;
            });
            this.SelectedSlot(nextAvailableSlot);
        }

        var isTeammateSelected = this.Teammates.some(t => {
            return t === currentSelection
        });
        if (isTeammateSelected) {
            var nextAvailableSlot = this.Teammates.find(t => {
                return t.Hero() == null;
            });
            this.SelectedSlot(nextAvailableSlot);
        }
    }

    SelectNextAvailableTeammateSlot = () => {
        var nextAvailableSlot = this.Teammates.find(t => {
            return t.Hero() == null;
        });
        this.SelectedSlot(nextAvailableSlot);
    }

    Suggestions = ko.pureComputed(() => {
        var noHeroesAreSelected = !this.Opponents.concat(this.Teammates).some(s => s.Hero() != null);
        if (noHeroesAreSelected) {
            return new Array(3).fill(new SuggestedHero(this))
        }

        return this.suggestions()
            .slice(0, 3)
            .map(function (weight) {
                return new SuggestedHero(this, weight.Hero, weight.Value)
            });
    });

    UpdateScores = () => {
        var data = {
            Opponents: this.Opponents.map(function (h) { return h.Name(); }),
            Teammates: this.Teammates.map(function (h) { return h.Name(); }),
        }
        return $.post({
            url: "../calculator/GetOverallScoresForAllHeroes",
            data: JSON.stringify(data),
            contentType: "application/json"
        }).done(data => {
            this.suggestions(data.sort(function (a, b) { return b.Value - a.Value; }));
        });
    }
};

$(document).ready(function () {
    $.getJSON("../heroes/")
        .done(function (data) {
            ko.applyBindings(new CalculatorViewModel(data));
        });
});