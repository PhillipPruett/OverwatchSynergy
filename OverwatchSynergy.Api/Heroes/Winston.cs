using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Winston : Hero
    {
        public override string Name => "Winston";
        public override string Role => "Tank";

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