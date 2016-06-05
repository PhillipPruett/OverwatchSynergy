using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Zarya : Hero
    {
        public override string Name => "Zarya";
        public override string Role => "Tank";

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Hanzo)
            {
                return 50;
            }
            if (hero is Tracer)
            {
                return 100;
            }
            if (hero is Mei)
            {
                return 100;
            }
            return 0;
        }
    }
}