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
            return 0;
        }
    }
}