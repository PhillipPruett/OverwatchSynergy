using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Mercy : Hero
    {
        public override string Name => "Mercy";
        public override string Role => "Support";

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Reinhardt)
            {
                return 100;
            }
            if (hero is DVa)
            {
                return 100;
            }
            if (hero is Mei)
            {
                return 100;
            }
            if (hero is Pharah)
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