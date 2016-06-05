using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Roadhog : Hero
    {
        public override string Name => "Roadhog";
        public override string Role => "Tank";



        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Lucio)
            {
                return 100;
            }
            return 0;
        }
    }
}