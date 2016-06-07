using System.Collections.Generic;

namespace OverwatchSynergy.Api
{
    public abstract class Hero
    {
        public abstract string Name { get; }
        public abstract string Id { get; }
        public abstract string Role { get; }
        
        public abstract int GetSynergyValue(Hero hero);
        public abstract int GetStrengthAgainstValue(Hero hero);
    }
}