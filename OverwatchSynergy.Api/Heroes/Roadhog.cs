using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Roadhog : Hero
    {
        public override string Id => "roadhog";
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

        public override int GetStrengthAgainstValue(Hero hero)
        {
            if (hero is Pharah)
            {
                return 100;
            }
            if (hero is Mercy)
            {
                return 100;
            }
            if (hero is Tracer)
            {
                return 100;
            }
            if (hero is Hero)
            {
                return 0;
            }
            if (hero is Zenyatta)
            {
                return 0;
            }
            if (hero is Reaper)
            {
                return 0;
            }
            return 50;
        }
    }
}