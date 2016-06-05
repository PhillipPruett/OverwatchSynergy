using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Pharah : Hero
    {
        public override string Name => "Pharah";
        public override string Role => "Attack";

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Mercy)
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