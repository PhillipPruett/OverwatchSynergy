using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Symmetra : Hero
    {
        public override string Id => "symmetra";
        public override string Name => "Symmetra";
        public override string Role => "Support";
        protected override double CountersMultiplier => 1.0;
        protected override double SynergyMultiplier => 1.0;
        protected override double ObjectiveMultiplier => 1.0;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Torbjorn)
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
            if (hero is Reinhardt)
            {
                return 100;
            }
            if (hero is Genji)
            {
                return 100;
            }
            if (hero is Winston)
            {
                return 0;
            }
            if (hero is Pharah)
            {
                return 0;
            }
            if (hero is Junkrat)
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