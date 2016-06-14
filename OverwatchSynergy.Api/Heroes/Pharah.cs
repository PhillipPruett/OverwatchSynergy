using System;
using System.Collections.Generic;
using OverwatchSynergy.Api.ObjectiveTypes;

namespace OverwatchSynergy.Api.Heroes
{
    public class Pharah : Hero
    {
        public override string Id => "pharah";
        public override string Name => "Pharah";
        public override string Role => "Attack";
        protected override double CountersMultiplier => 1.5;
        protected override double SynergyMultiplier => 1.2;
        protected override double ObjectiveMultiplier => 0.5;

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Mercy)
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
            if (hero is Junkrat)
            {
                return 100;
            }
            if (hero is Reaper)
            {
                return 100;
            }
            if (hero is Lucio)
            {
                return 100;
            }
            if (hero is Widowmaker)
            {
                return 0;
            }
            if (hero is Roadhog)
            {
                return 0;
            }
            if (hero is McCree)
            {
                return 0;
            }
            return 50;
        }

        public override double GetObjectiveStrengthValue(ObjectiveType objectiveType)
        {
            if (objectiveType is DefenseCapture)
            {
                return 0.7;
            }

            return 1.0;
        }
    }
}