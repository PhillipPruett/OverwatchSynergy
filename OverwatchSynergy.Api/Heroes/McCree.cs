using System;
using System.Collections.Generic;
using OverwatchSynergy.Api.ObjectiveTypes;

namespace OverwatchSynergy.Api.Heroes
{
    public class McCree : Hero
    {
        public override string Id => "mccree";
        public override string Name => "McCree";
        public override string Role => "Attack";
        protected override double CountersMultiplier => 2.0;
        protected override double SynergyMultiplier => 1.2;
        protected override double ObjectiveMultiplier => 0.5;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Lucio)
            {
                return 100;
            }
            return 0;
        }

        public override int GetStrengthAgainstValue(Hero hero)
        {
            if (hero is Reaper)
            {
                return 100;
            }
            if (hero is Winston)
            {
                return 100;
            }
            if (hero is Tracer)
            {
                return 100;
            }
            if (hero is Zarya)
            {
                return 0;
            }
            if (hero is Genji)
            {
                return 0;
            }
            if (hero is Bastion)
            {
                return 0;
            }
            return 50;
        }

        public override double GetObjectiveStrengthValue(ObjectiveType objectiveType)
        {
            if (objectiveType is AssaultAttack)
            {
                return 1.2;
            }
            if (objectiveType is EscortAttack)
            {
                return 1.2;
            }

            return 1.0;
        }
    }
}