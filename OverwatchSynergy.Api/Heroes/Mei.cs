using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Mei : Hero
    {
        public override string Name => "Mei";
        public override string Role => "Defense";

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Junkrat)
            {
                return 100;
            }
            if (hero is Mercy)
            {
                return 100;
            }
            if (hero is Zarya)
            {
                return 100;
            }
            return 0;
        }
    }
}