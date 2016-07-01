using System;
using System.Collections.Generic;
using OverwatchSynergy.Api.ObjectiveTypes;

namespace OverwatchSynergy.Api.Heroes
{
    public class Roadhog : Hero
    {
        public override string Id => "roadhog";
        public override string Name => "Roadhog";
        public override string Role => "Tank";
        protected override double CountersMultiplier => 1.2;
        protected override double SynergyMultiplier => 1.0;
        protected override double ObjectiveMultiplier => 1.5;


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
            if (hero is Pharah)
            {
                return 100;
            }
            if (hero is Mercy)
            {
                return 100;
            }
            if (hero is Tracer)
            {
                return 100;
            }
            if (hero is Hero)
            {
                return 0;
            }
            if (hero is Zenyatta)
            {
                return 0;
            }
            if (hero is Reaper)
            {
                return 0;
            }
            return 50;
        }

        public override double GetObjectiveStrengthValue(ObjectiveType objectiveType)
        {
            if (objectiveType is EscortAttack)
            {
                return 1.5;
            }
            return 1.0;
        }
    }
}