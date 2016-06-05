using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Lucio : Hero
    {
        public override string Name => "Lúcio";
        public override string Role => "Support";

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
            return 0;
        }
    }
}