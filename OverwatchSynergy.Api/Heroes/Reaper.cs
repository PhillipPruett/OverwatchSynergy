using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Reaper : Hero
    {
        public override string Name => "Reaper";
        public override string Role => "Attack";



        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Zenyatta)
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