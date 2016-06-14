using System;
using System.Collections.Generic;
using OverwatchSynergy.Api.ObjectiveTypes;

namespace OverwatchSynergy.Api.Heroes
{
    public class Symmetra : Hero
    {
        public override string Id => "symmetra";
        public override string Name => "Symmetra";
        public override string Role => "Support";
        protected override double CountersMultiplier => 1.0;
        protected override double SynergyMultiplier => 1.2;
        protected override double ObjectiveMultiplier => 2.0;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Torbjorn)
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
            if (hero is Reinhardt)
            {
                return 100;
            }
            if (hero is Genji)
            {
                return 100;
            }
            if (hero is Winston)
            {
                return 0;
            }
            if (hero is Pharah)
            {
                return 0;
            }
            if (hero is Junkrat)
            {
                return 0;
            }
            return 50;
        }

        public override double GetObjectiveStrengthValue(ObjectiveType objectiveType)
        {
            if (objectiveType is NeutralCapture)
            {
                return 0.3;
            }
            if (objectiveType is AttackPushCart)
            {
                return 0.5;
            }
            if (objectiveType is AttackCapture)
            {
                return 0.5;
            }
            if (objectiveType is DefenseCapture)
            {
                return 1.5;
            }

            return 1.0;
        }
    }
}