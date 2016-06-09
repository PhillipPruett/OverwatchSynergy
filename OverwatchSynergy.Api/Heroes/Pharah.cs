using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Pharah : Hero
    {
        public override string Id => "pharah";
        public override string Name => "Pharah";
        public override string Role => "Attack";
        protected override double CountersMultiplier => 1.0;
        protected override double SynergyMultiplier => 1.0;
        protected override double ObjectiveMultiplier => 1.0;

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
            if (hero is Mei)
            {
                return 100;
            }
            if (hero is Junkrat)
            {
                return 100;
            }
            if (hero is Reaper)
            {
                return 100;
            }
            if (hero is Lucio)
            {
                return 100;
            }
            if (hero is Widowmaker)
            {
                return 0;
            }
            if (hero is Roadhog)
            {
                return 0;
            }
            if (hero is McCree)
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