using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace OverwatchSynergy.Api.Heroes
{
    public class Mercy : Hero
    {
        public override string Id => "mercy";
        public override string Name => "Mercy";
        public override string Role => "Support";
        protected override double CountersMultiplier => 1.0;
        protected override double SynergyMultiplier => 2.0;
        protected override double ObjectiveMultiplier => 1.2;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Reinhardt)
            {
                return 100;
            }
            if (hero is DVa)
            {
                return 100;
            }
            if (hero is Mei)
            {
                return 100;
            }
            if (hero is Pharah)
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
            if (hero is Zarya)
            {
                return 100;
            }
            if (hero is Torbjorn)
            {
                return 100;
            }
            if (hero is Genji)
            {
                return 0;
            }
            if (hero is Widowmaker)
            {
                return 0;
            }
            if (hero is Tracer)
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