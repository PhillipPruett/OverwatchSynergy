using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Torbjorn : Hero
    {
        public override string Name => "Torbjörn";
        public override string Role => "Defense";

        public override int GetSynergyValue(Hero hero)
        {
            return 0;
        }
    }
}