using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Reinhardt : Hero
    {
        public override string Id => "reinhardt";
        public override string Name => "Reinhardt";
        public override string Role => "Tank";
        protected override double CountersMultiplier => 0.7;
        protected override double SynergyMultiplier => 2.0;
        protected override double ObjectiveMultiplier => 1.5;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Mercy)
            {
                return 100;
            }
            if (hero is Bastion)
            {
                return 100;
            }
            return 0;
        }

        public override int GetStrengthAgainstValue(Hero hero)
        {
            if (hero is Soldier76)
            {
                return 100;
            }
            if (hero is Torbjorn)
            {
                return 100;
            }
            if (hero is Widowmaker)
            {
                return 100;
            }
            if (hero is Pharah)
            {
                return 0;
            }
            if (hero is Tracer)
            {
                return 0;
            }
            if (hero is Reaper)
            {
                return 0;
            }
            return 50;
        }

        public override double GetObjectiveStrengthValue(ObjectiveType objectiveType)
        {
            return 1.0;
        }
    }
}