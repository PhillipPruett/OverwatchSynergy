using System;
using System.Collections.Generic;
using OverwatchSynergy.Api.ObjectiveTypes;

namespace OverwatchSynergy.Api.Heroes
{
    public class Lucio : Hero
    {
        public override string Id => "lucio";
        public override string Name => "Lúcio";
        public override string Role => "Support";
        protected override double CountersMultiplier => 1.0;
        protected override double SynergyMultiplier => 1.0;
        protected override double ObjectiveMultiplier => 1.0;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Genji)
            {
                return 100;
            }
            if (hero is Roadhog)
            {
                return 100;
            }
            if (hero is McCree)
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
            if (hero is Winston)
            {
                return 100;
            }
            if (hero is DVa)
            {
                return 100;
            }
            if (hero is Pharah)
            {
                return 0;
            }
            if (hero is Zarya)
            {
                return 0;
            }
            if (hero is Widowmaker)
            {
                return 0;
            }
            return 50;
        }

        public override double GetObjectiveStrengthValue(ObjectiveType objectiveType)
        {
            if (objectiveType is NeutralCapture)
            {
                return 1.5;
            }
            return 1.0;
        }
    }
}