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

        public override int GetStrengthAgainstValue(Hero hero)
        {
            if (hero is Genji)
            {
                return 100;
            }
            if (hero is Widowmaker)
            {
                return 100;
            }
            if (hero is Symmetra)
            {
                return 100;
            }
            if (hero is McCree)
            {
                return 0;
            }
            if (hero is Reaper)
            {
                return 0;
            }
            if (hero is Zenyatta)
            {
                return 0;
            }
            return 50;
        }
    }
}