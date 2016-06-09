using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Torbjorn : Hero
    {
        public override string Id => "torbjorn";
        public override string Name => "Torbjörn";
        public override string Role => "Defense";
        protected override double CountersMultiplier => 1.0;
        protected override double SynergyMultiplier => 1.0;
        protected override double ObjectiveMultiplier => 1.0;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Symmetra)
            {
                return 100;
            }
            if (hero is Winston)
            {
                return 100;
            }
            return 0;
        }

        public override int GetStrengthAgainstValue(Hero hero)
        {
            if (hero is Genji)
            {
                return 100;
            }
            if (hero is Roadhog)
            {
                return 100;
            }
            if (hero is Lucio)
            {
                return 100;
            }
            if (hero is Reaper)
            {
                return 0;
            }
            if (hero is Junkrat)
            {
                return 0;
            }
            if (hero is DVa)
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