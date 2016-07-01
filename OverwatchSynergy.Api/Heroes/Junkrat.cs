using System;
using System.Collections.Generic;
using OverwatchSynergy.Api.ObjectiveTypes;

namespace OverwatchSynergy.Api.Heroes
{
    public class Junkrat : Hero
    {
        public override string Id => "junkrat";
        public override string Name => "Junkrat";
        public override string Role => "Defense";
        protected override double CountersMultiplier => 2.0;
        protected override double SynergyMultiplier => 1.0;
        protected override double ObjectiveMultiplier => 1.5;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Mei)
            {
                return 100;
            }
            return 0;
        }

        public override int GetStrengthAgainstValue(Hero hero)
        {
            if (hero is Torbjorn)
            {
                return 100;
            }
            if (hero is Bastion)
            {
                return 100;
            }
            if (hero is Symmetra)
            {
                return 100;
            }
            if (hero is Pharah)
            {
                return 0;
            }
            if (hero is McCree)
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
            if (objectiveType is Control)
            {
                return 1.5;
            }
            if (objectiveType is AssaultDefend)
            {
                return 1.2;
            }
            if (objectiveType is EscortDefend)
            {
                return 1.2;
            }
            if (objectiveType is AssaultAttack)
            {
                return 0.7;
            }
            if (objectiveType is EscortAttack)
            {
                return 0.7;
            }
            return 1.0;
        }
    }
}