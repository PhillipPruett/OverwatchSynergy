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
            return 0;
        }
    }
}