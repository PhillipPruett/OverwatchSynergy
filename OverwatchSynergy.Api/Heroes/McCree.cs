using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class McCree : Hero
    {
        public override string Name => "McCree";
        public override string Role => "Attack";

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