using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Mercy : Hero
    {
        public override string Name => "Mercy";
        public override string Role => "Support";

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Reinhardt)
            {
                return 100;
            }
            return 0;
        }
    }
}