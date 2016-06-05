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
            return 0;
        }
    }
}