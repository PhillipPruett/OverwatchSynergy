using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Torbjorn : Hero
    {
        public override string Name => "Torbjörn";
        public override string Role => "Defense";

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Symmetra)
            {
                return 100;
            }
            if (hero is Winston)
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