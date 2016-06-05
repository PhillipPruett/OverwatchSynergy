using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Junkrat : Hero
    {
        public override string Name => "Junkrat";
        public override string Role => "Defense";

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Mei)
            {
                return 100;
            }
            return 0;
        }
    }
}