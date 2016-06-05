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
            if (hero is Reaper)
            {
                return 100;
            }
            if (hero is Soldier76)
            {
                return 100;
            }
            if (hero is Widowmaker)
            {
                return 100;
            }
            return 0;
        }

        public override int GetStrengthAgainstValue(Hero hero)
        {
            return 0;
        }
    }
}