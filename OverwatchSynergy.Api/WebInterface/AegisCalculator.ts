class AegisCalculator {
    constructor() {
        this.SelectedSlot.subscribe(function (currentSelection) {
            currentSelection && currentSelection.IsSelected(false);
        }, null, "beforeChange");
        this.SelectedSlot.subscribe(function (newSelection) {
            newSelection && newSelection.IsSelected(true);
        });

        for (let i = 0; i < 6; i++) {
            this.Opponents.push(new TeamSlot(this));
            this.Teammates.push(new TeamSlot(this));
        }

        this.SelectedSlot(this.Opponents[0]);
        
        $.getJSON("../heroes/").done(heroesJson => {
            let AvailableHeroes = heroesJson.map(hero => {
                return new AvailableHero(hero, this);
            });

            let roles = ["Attack", "Defense", "Tank", "Support"];

            this.AvailableHeroesByRole(roles.map(role => {
                return {
                    Role: role,
                    AvailableHeroes: AvailableHeroes.filter(hero => {
                        return hero.Role == role;
                    })
                }
            }));
        });

        $.getJSON("../objectives/").done((objectivesJson: ObjectiveType []) => {
            this.AvailableObjectiveTypes(objectivesJson);
            this.SelectedObjectiveType(objectivesJson[0]);
            this.SelectedObjectiveType.subscribe(this.UpdateScores);
        });
    };

    private suggestions = ko.observable<WeightedHero[]>([]);

    Opponents = new Array<TeamSlot>();
    Teammates = new Array<TeamSlot>();
    SelectedObjectiveType = ko.observable<ObjectiveType>();

    SelectedSlot = ko.observable<TeamSlot>();

    AvailableHeroesByRole = ko.observable<RoleGrouping[]>([]);
    AvailableObjectiveTypes = ko.observable<ObjectiveType[]>([]);

    SelectNextAvailableSlot = () => {
        let currentSelection = this.SelectedSlot();
        let isOpponentSelected = this.Opponents.some(t => {
            return t === currentSelection
        });
        if (isOpponentSelected) {
            let nextAvailableSlot = this.Opponents.find(t => {
                return t.Hero() == null;
            });
            this.SelectedSlot(nextAvailableSlot);
        }

        let isTeammateSelected = this.Teammates.some(t => {
            return t === currentSelection
        });
        if (isTeammateSelected) {
            let nextAvailableSlot = this.Teammates.find(t => {
                return t.Hero() == null;
            });
            this.SelectedSlot(nextAvailableSlot);
        }
    }

    SelectNextAvailableTeammateSlot = () => {
        let nextAvailableSlot = this.Teammates.find(t => {
            return t.Hero() == null;
        });
        this.SelectedSlot(nextAvailableSlot);
    }

    SelectObjectiveType = (objectiveType: ObjectiveType) => {
        this.SelectedObjectiveType(objectiveType);
    }

    Suggestions = ko.pureComputed(() => {
        let noHeroesAreSelected = !this.Opponents.concat(this.Teammates).some(s => s.Hero() != null);
        if (noHeroesAreSelected) {
            return new Array(3).fill(new SuggestedHero(this))
        }

        return this.suggestions()
            .slice(0, 3)
            .map(weight => {
                return new SuggestedHero(this, weight.Hero, weight.Value)
            });
    });

    UpdateScores = () => {
        let data = {
            Opponents: this.Opponents.filter(h => h.Hero() != null).map(h => h.Name()),
            Teammates: this.Teammates.filter(h => h.Hero() != null).map(h => h.Name()),
            ObjectiveGameType: this.SelectedObjectiveType().Id
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