using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Lucio : Hero
    {
        public override string Id => "lucio";
        public override string Name => "Lúcio";
        public override string Role => "Support";

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Genji)
            {
                return 100;
            }
            if (hero is Roadhog)
            {
                return 100;
            }
            if (hero is McCree)
            {
                return 100;
            }
            return 0;
        }

        public override int GetStrengthAgainstValue(Hero hero)
        {
            if (hero is Mei)
            {
                return 100;
            }
            if (hero is Winston)
            {
                return 100;
            }
            if (hero is DVa)
            {
                return 100;
            }
            if (hero is Pharah)
            {
                return 0;
            }
            if (hero is Zarya)
            {
                return 0;
            }
            if (hero is Widowmaker)
            {
                return 0;
            }
            return 50;
        }
    }
}