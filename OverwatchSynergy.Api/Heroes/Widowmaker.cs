using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Widowmaker : Hero
    {
        public override string Name => "Widowmaker";
        public override string Role => "Defense";

        public override int GetSynergyValue(Hero hero)
        {
            return 0;
        }
    }
}