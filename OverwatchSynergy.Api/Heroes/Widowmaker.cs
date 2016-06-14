using System;
using System.Collections.Generic;
using OverwatchSynergy.Api.ObjectiveTypes;

namespace OverwatchSynergy.Api.Heroes
{
    public class Widowmaker : Hero
    {
        public override string Id => "widowmaker";
        public override string Name => "Widowmaker";
        public override string Role => "Defense";
        protected override double CountersMultiplier => 1.5;
        protected override double SynergyMultiplier => 0.5;
        protected override double ObjectiveMultiplier => 1.0;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Zenyatta)
            {
                return 100;
            }
            return 0;
        }

        public override int GetStrengthAgainstValue(Hero hero)
        {
            if (hero is Zenyatta)
            {
                return 100;
            }
            if (hero is Torbjorn)
            {
                return 100;
            }
            if (hero is Pharah)
            {
                return 100;
            }
            if (hero is Tracer)
            {
                return 0;
            }
            if (hero is Genji)
            {
                return 0;
            }
            if (hero is Winston)
            {
                return 0;
            }
            return 50;
        }

        public override double GetObjectiveStrengthValue(ObjectiveType objectiveType)
        {
            if (objectiveType is NeutralCapture)
            {
                return 0.7;
            }
            return 1.0;
        }
    }
}