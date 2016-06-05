using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class DVa : Hero
    {
        public override string Name => "D.Va";
        public override string Role => "Tank";

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
            return 0;
        }
    }
}