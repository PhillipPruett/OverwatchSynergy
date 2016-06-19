class AvailableHero {
    constructor(private hero: Hero, private calculatorViewModel: AegisCalculator) {
    }

    Name = this.hero.Name;
    Role = this.hero.Role;

    BackgroundImage = "url('img/" + this.hero.Id + ".png')";

    Add = () => {
        let selectedSlot = this.calculatorViewModel.SelectedSlot();
        if (selectedSlot) {
            this.calculatorViewModel.SelectedSlot().Hero(this.hero);
            this.calculatorViewModel.SelectNextAvailableSlot();
        }
    }
}