class ObjectiveType {
    constructor(public Id: string, private calculatorViewModel: AegisCalculator) { }

    BackgroundImage = "url('img/" + this.Id + ".png')";
    Class = ko.pureComputed(() => this.calculatorViewModel.SelectedObjectiveType() == this ? "selected" : "");
}