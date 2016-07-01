using System;
using System.Collections.Generic;
using OverwatchSynergy.Api.ObjectiveTypes;

namespace OverwatchSynergy.Api.Heroes
{
    public class Bastion : Hero
    {
        public override string Id => "bastion";
        public override string Name => "Bastion";
        public override string Role => "Defense";
        protected override double CountersMultiplier => 1.5;
        protected override double SynergyMultiplier => 1.2;
        protected override double ObjectiveMultiplier => 2.0;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Reinhardt)
            {
                return 100;
            }
            return 0;
        }

        public override int GetStrengthAgainstValue(Hero hero)
        {
            if (hero is Winston)
            {
                return 100;
            }
            if (hero is Reinhardt)
            {
                return 100;
            }
            if (hero is McCree)
            {
                return 100;
            }
            if (hero is Genji)
            {
                return 0;
            }
            if (hero is Junkrat)
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
            if (objectiveType is AssaultAttack)
            {
                return 0.5;
            }
            if (objectiveType is EscortAttack)
            {
                return 0.8;
            }
            if (objectiveType is EscortDefend)
            {
                return 1.2;
            }
            if (objectiveType is AssaultDefend)
            {
                return 2.0;
            }
            return 1.0;
        }
    }
}