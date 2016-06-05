using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Zenyatta : Hero
    {
        public override string Name => "Zenyatta";
        public override string Role => "Support";

        public override int GetSynergyValue(Hero hero)
        {
            return 0;
        }
    }
}