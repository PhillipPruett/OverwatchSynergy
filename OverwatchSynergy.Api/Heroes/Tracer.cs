using System;
using System.Collections.Generic;
using OverwatchSynergy.Api.ObjectiveTypes;

namespace OverwatchSynergy.Api.Heroes
{
    public class Tracer : Hero
    {
        public override string Id => "tracer";
        public override string Name => "Tracer";
        public override string Role => "Attack";
        protected override double CountersMultiplier => 2.0;
        protected override double SynergyMultiplier => 0.5;
        protected override double ObjectiveMultiplier => 0.7;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Zarya)
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
            if (hero is Mercy)
            {
                return 100;
            }
            if (hero is Zenyatta)
            {
                return 100;
            }
            if (hero is McCree)
            {
                return 0;
            }
            if (hero is Mei)
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
            if (objectiveType is AssaultDefend)
            {
                return 0.7;
            }

            return 1.0;
        }
    }
}