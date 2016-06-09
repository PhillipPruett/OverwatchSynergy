using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Zenyatta : Hero
    {
        public override string Id => "zenyatta";
        public override string Name => "Zenyatta";
        public override string Role => "Support";
        protected override double CountersMultiplier => 1.0;
        protected override double SynergyMultiplier => 1.0;
        protected override double ObjectiveMultiplier => 1.0;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Reaper)
            {
                return 100;
            }
            if (hero is Soldier76)
            {
                return 100;
            }
            if (hero is Widowmaker)
            {
                return 100;
            }
            return 0;
        }

        public override int GetStrengthAgainstValue(Hero hero)
        {
            if (hero is DVa)
            {
                return 100;
            }
            if (hero is Winston)
            {
                return 100;
            }
            if (hero is Zarya)
            {
                return 100;
            }
            if (hero is Tracer)
            {
                return 0;
            }
            if (hero is Widowmaker)
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