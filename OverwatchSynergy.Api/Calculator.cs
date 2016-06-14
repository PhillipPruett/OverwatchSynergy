using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using OverwatchSynergy.Api;
using OverwatchSynergy.Api.Heroes;

namespace OverwatchSynergy.Api
{
    public static class Calculator
    {
        public static Hero[] Heroes = new[]
                                       {
                                           new Genji(),
                                           new McCree(),
                                           new Pharah(),
                                           new Reaper(),
                                           new Soldier76(),
                                           new Tracer(),
                                           new Bastion(),
                                           new Hanzo(),
                                           new Junkrat(),
                                           new Mei(),
                                           new Torbjorn(),
                                           new Widowmaker(),
                                           new DVa(),
                                           new Reinhardt(),
                                           new Roadhog(),
                                           new Winston(),
                                           new Zarya(),
                                           new Lucio(),
                                           new Mercy(),
                                           new Symmetra(),
                                           (Hero) new Zenyatta(),
                                       };

        public static IEnumerable<Weight> GetSynergies(IEnumerable<Hero> team)
        {
            return Heroes.Select(h => GetWeightForTeam(h, team));
        }

        private static Weight GetWeightForTeam(Hero hero, IEnumerable<Hero> team)
        {
            return new Weight()
                    {
                        Hero = hero,
                        Value = team.Any()
                                    ? (int) team.Average(teamMate => teamMate.GetSynergyValue(hero))
                                    : 0
                    };
        }

        public static IEnumerable<Weight> GetHeroesStrengthAgainst(IEnumerable<Hero> enemyTeam)
        {
            return Heroes.Select(h => GetHeroesThatAreWeakAgainstForEnemyTeam(h, enemyTeam));
        }

        private static Weight GetHeroesThatAreWeakAgainstForEnemyTeam(Hero hero, IEnumerable<Hero> enemyTeam)
        {
            return new Weight()
            {
                Hero = hero,
                Value = enemyTeam.Any()
                                ? (int)enemyTeam.Average(enemy => enemy.GetStrengthAgainstValue(hero))
                                : 0
            };
        }

        public static IEnumerable<Weight> GetOverallScoresForAllHeroes(IEnumerable<Hero> enemyTeam, IEnumerable<Hero> team, ObjectiveType objectiveType)
        {
            return Heroes.Select(h => h.CalculateWeight( enemyTeam, team, objectiveType)).SuppressDuplicates(team).OrderByDescending(w => w.Value);;
        }

    }

    public class Weight
    {
        public Hero Hero { get; set; }

        public double Value { get; set; }
    }
}