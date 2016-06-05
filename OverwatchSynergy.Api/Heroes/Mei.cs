using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Mei : Hero
    {
        public override string Name => "Mei";
        public override string Role => "Defense";

        public override int GetSynergyValue(Hero hero)
        {
            return 0;
        }
    }
}