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