using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Reinhardt : Hero
    {
        public override string Name => "Reinhardt";
        public override string Role => "Tank";

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Mercy)
            {
                return 100;
            }
            if (hero is Bastion)
            {
                return 100;
            }
            return 0;
        }
    }
}