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
            if (hero is Zenyatta)
            {
                return 100;
            }
            return 0;
        }
    }
}