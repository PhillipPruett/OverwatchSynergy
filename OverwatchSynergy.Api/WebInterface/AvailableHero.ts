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