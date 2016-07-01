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
        protected override double CountersMultiplier => 0.7;
        protected override double SynergyMultiplier => 1.2;
        protected override double ObjectiveMultiplier => 2.0;

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
            if (objectiveType is Control)
            {
                return 1.5;
            }
            if (objectiveType is AssaultAttack)
            {
                return 1.2;
            }
            if (objectiveType is AssaultDefend)
            {
                return 1.2;
            }
            if (objectiveType is EscortAttack)
            {
                return 0.7;
            }
            if (objectiveType is EscortDefend)
            {
                return 0.7;
            }
            return 1.0;
        }
    }
}