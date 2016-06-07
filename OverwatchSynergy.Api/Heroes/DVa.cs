using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class DVa : Hero
    {
        public override string Id => "dva";
        public override string Name => "D.Va";
        public override string Role => "Tank";

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
            if (hero is Bastion)
            {
                return 100;
            }
            if (hero is Widowmaker)
            {
                return 100;
            }
            if (hero is Pharah)
            {
                return 100;
            }
            if (hero is Zenyatta)
            {
                return 0;
            }
            if (hero is Mei)
            {
                return 0;
            }
            if (hero is Zarya)
            {
                return 0;
            }
            return 50;
        }
    }
}