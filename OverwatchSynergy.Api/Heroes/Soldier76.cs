using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Soldier76 : Hero
    {
        public override string Id => "soldier76";
        public override string Name => "Soldier: 76";
        public override string Role => "Attack";

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Zenyatta)
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
            if (hero is Tracer)
            {
                return 100;
            }
            if (hero is Roadhog)
            {
                return 100;
            }
            if (hero is Reinhardt)
            {
                return 0;
            }
            if (hero is Mercy)
            {
                return 0;
            }
            if (hero is Genji)
            {
                return 0;
            }
            return 50;
        }
    }
}