using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Tracer : Hero
    {
        public override string Name => "Tracer";
        public override string Role => "Attack";

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Zarya)
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
            if (hero is Mercy)
            {
                return 100;
            }
            if (hero is Zenyatta)
            {
                return 100;
            }
            if (hero is McCree)
            {
                return 0;
            }
            if (hero is Mei)
            {
                return 0;
            }
            if (hero is Soldier76)
            {
                return 0;
            }
            return 50;
        }
    }
}