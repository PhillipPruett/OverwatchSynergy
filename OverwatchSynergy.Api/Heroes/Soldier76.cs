using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Soldier76 : Hero
    {
        public override string Name => "Soldier: 76";
        public override string Role => "Attack";

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Zenyatta)
            {
                return 100;
            }
            return 0;
        }
    }
}