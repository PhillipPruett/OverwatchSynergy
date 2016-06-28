using System.Collections.Generic;
using System.Linq;

namespace OverwatchSynergy.Api
{
    public abstract class Hero
    {
        public abstract string Name { get; }
        public abstract string Id { get; }
        public abstract string Role { get; }

        protected abstract double CountersMultiplier { get; }
        protected abstract double SynergyMultiplier { get;} 
        protected abstract double ObjectiveMultiplier { get; }

        public Weight CalculateWeight(IEnumerable<Hero> enemyTeam, IEnumerable<Hero> team , ObjectiveType objectiveType)
        {
            var counterValue = enemyTeam.Any()
                               ? (int)enemyTeam.Average(this.GetStrengthAgainstValue)
                               : 50;
            var synergyValue = team.Any()
                               ? (int)team.Average(this.GetSynergyValue)
                               : 50;

            var objectiveValue = GetObjectiveStrengthValue(objectiveType);

            return new Weight()
            {
                Hero = this,
                Value = (counterValue * CountersMultiplier + synergyValue * SynergyMultiplier) / 2.0 * (objectiveValue * ObjectiveMultiplier)
            };
        }

        public abstract int GetSynergyValue(Hero hero);

        public abstract int GetStrengthAgainstValue(Hero hero);

        public abstract double GetObjectiveStrengthValue(ObjectiveType objectiveType);
    }
}