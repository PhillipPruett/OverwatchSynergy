using System;
using System.Collections.Generic;
using OverwatchSynergy.Api.ObjectiveTypes;

namespace OverwatchSynergy.Api.Heroes
{
    public class Mei : Hero
    {
        public override string Id => "mei";
        public override string Name => "Mei";
        public override string Role => "Defense";
        protected override double CountersMultiplier => 1.2;
        protected override double SynergyMultiplier => 1.2;
        protected override double ObjectiveMultiplier => 1.5;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Junkrat)
            {
                return 100;
            }
            if (hero is Mercy)
            {
                return 100;
            }
            if (hero is Zarya)
            {
                return 100;
            }
            return 0;
        }

        public override int GetStrengthAgainstValue(Hero hero)
        {
            if (hero is Tracer)
            {
                return 100;
            }
            if (hero is Winston)
            {
                return 100;
            }
            if (hero is Genji)
            {
                return 100;
            }
            if (hero is Pharah)
            {
                return 0;
            }
            if (hero is Widowmaker)
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
            if (objectiveType is AssaultAttack)
            {
                return 0.5;
            }
            if (objectiveType is EscortAttack)
            {
                return 0.5;
            }
            return 1.0;
        }
    }
}