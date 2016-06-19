class SuggestedHero {
    constructor(private calculatorViewModel: AegisCalculator, private hero?: Hero, public Weight?: number) { }
    Name = this.hero ? this.hero.Name : "";

    BackgroundImage = this.hero ? "url('img/" + this.hero.Id + ".png')" : "none";

    Class = !this.hero ? "empty" : "";

    Add = () => {
        this.calculatorViewModel.SelectNextAvailableTeammateSlot();
        this.calculatorViewModel.SelectedSlot().Hero(this.hero);
        this.calculatorViewModel.SelectNextAvailableSlot();
    }
}