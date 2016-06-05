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

        public override int GetStrengthAgainstValue(Hero hero)
        {
            if (hero is Reaper)
            {
                return 100;
            }
            if (hero is Winston)
            {
                return 100;
            }
            if (hero is Tracer)
            {
                return 100;
            }
            if (hero is Zarya)
            {
                return 0;
            }
            if (hero is Genji)
            {
                return 0;
            }
            if (hero is Bastion)
            {
                return 0;
            }
            return 50;
        }
    }
}