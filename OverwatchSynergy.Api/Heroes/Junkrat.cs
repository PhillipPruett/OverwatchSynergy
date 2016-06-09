using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Junkrat : Hero
    {
        public override string Id => "junkrat";
        public override string Name => "Junkrat";
        public override string Role => "Defense";
        protected override double CountersMultiplier => 1.0;
        protected override double SynergyMultiplier => 1.0;
        protected override double ObjectiveMultiplier => 1.0;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Mei)
            {
                return 100;
            }
            return 0;
        }

        public override int GetStrengthAgainstValue(Hero hero)
        {
            if (hero is Torbjorn)
            {
                return 100;
            }
            if (hero is Bastion)
            {
                return 100;
            }
            if (hero is Symmetra)
            {
                return 100;
            }
            if (hero is Pharah)
            {
                return 0;
            }
            if (hero is McCree)
            {
                return 0;
            }
            if (hero is Soldier76)
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