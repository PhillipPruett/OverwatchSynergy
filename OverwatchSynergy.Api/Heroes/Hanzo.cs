using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Hanzo : Hero
    {
        public override string Id => "hanzo";
        public override string Name => "Hanzo";
        public override string Role => "Defense";
        protected override double CountersMultiplier => 1.0;
        protected override double SynergyMultiplier => 1.0;
        protected override double ObjectiveMultiplier => 1.0;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Zarya)
            {
                return 50;
            }
            return 0;
        }

        public override int GetStrengthAgainstValue(Hero hero)
        {
            if (hero is Bastion)
            {
                return 100;
            }
            if (hero is Roadhog)
            {
                return 100;
            }
            if (hero is Torbjorn)
            {
                return 100;
            }
            if (hero is Tracer)
            {
                return 0;
            }
            if (hero is Reinhardt)
            {
                return 0;
            }
            if (hero is Genji)
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