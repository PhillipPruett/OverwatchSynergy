using System;
using System.Collections.Generic;
using OverwatchSynergy.Api.ObjectiveTypes;

namespace OverwatchSynergy.Api.Heroes
{
    public class Zarya : Hero
    {
        public override string Id => "zarya";
        public override string Name => "Zarya";
        public override string Role => "Tank";
        protected override double CountersMultiplier => 1.0;
        protected override double SynergyMultiplier => 2.0;
        protected override double ObjectiveMultiplier => 1.0;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Hanzo)
            {
                return 50;
            }
            if (hero is Tracer)
            {
                return 100;
            }
            if (hero is Mei)
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
            if (hero is DVa)
            {
                return 100;
            }
            if (hero is Torbjorn)
            {
                return 100;
            }
            if (hero is Pharah)
            {
                return 0;
            }
            if (hero is Reinhardt)
            {
                return 0;
            }
            if (hero is Zenyatta)
            {
                return 0;
            }
            return 50;
        }

        public override double GetObjectiveStrengthValue(ObjectiveType objectiveType)
        {
            if (objectiveType is Control)
            {
                return 0.7;
            }

            if (objectiveType is AssaultAttack)
            {
                return 1.2;
            }
            if (objectiveType is EscortAttack)
            {
                return 1.5;
            }
            if (objectiveType is EscortDefend)
            {
                return 1.5;
            }
            if (objectiveType is AssaultDefend)
            {
                return 0.7;
            }

            return 1.0;
        }
    }
}