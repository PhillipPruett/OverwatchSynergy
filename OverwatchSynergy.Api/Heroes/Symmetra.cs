using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Symmetra : Hero
    {
        public override string Name => "Symmetra";
        public override string Role => "Support";

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Torbjorn)
            {
                return 100;
            }
            return 0;
        }
    }
}