class TeamSlot {
    constructor(private calculatorViewModel: AegisCalculator) {
        this.Hero.subscribe(calculatorViewModel.UpdateScores);
    }

    Hero = ko.observable<Hero>(null);
    IsSelected = ko.observable(false);

    Name = ko.computed(() => {
        let hero = ko.unwrap(this.Hero);
        return hero && hero.Name;
    });

    BackgroundImage = ko.pureComputed(() => {
        let hero = ko.unwrap(this.Hero);
        
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