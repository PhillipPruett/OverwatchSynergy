using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Reaper : Hero
    {
        public override string Id => "reaper";
        public override string Name => "Reaper";
        public override string Role => "Attack";
        protected override double CountersMultiplier => 1.0;
        protected override double SynergyMultiplier => 1.0;
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
            if (hero is Bastion)
            {
                return 100;
            }
            if (hero is Widowmaker)
            {
                return 100;
            }
            if (hero is Mercy)
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
            if (hero is Lucio)
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