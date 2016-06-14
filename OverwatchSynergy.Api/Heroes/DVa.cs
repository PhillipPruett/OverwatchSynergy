using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class DVa : Hero
    {
        public override string Id => "dva";
        public override string Name => "D.Va";
        public override string Role => "Tank";
        protected override double CountersMultiplier => 1.2;
        protected override double SynergyMultiplier => 2.0;
        protected override double ObjectiveMultiplier => 0.5;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Mercy)
            {
                return 100;
            }
            return 0;
        }

        public override int GetStrengthAgainstValue(Hero hero)
        {
            if (hero is Bastion)
            {
                return 100;
            }
            if (hero is Widowmaker)
            {
                return 100;
            }
            if (hero is Pharah)
            {
                return 100;
            }
            if (hero is Zenyatta)
            {
                return 0;
            }
            if (hero is Mei)
            {
                return 0;
            }
            if (hero is Zarya)
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