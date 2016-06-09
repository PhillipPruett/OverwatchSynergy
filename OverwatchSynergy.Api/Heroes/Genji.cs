using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OverwatchSynergy.Api.Heroes
{
    public class Genji : Hero
    {
        public override string Id => "genji";
        public override string Name => "Genji";
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
            if (hero is Bastion)
            {
                return 100;
            }
            if (hero is Widowmaker)
            {
                return 100;
            }
            if (hero is Mercy)
            {
                return 100;
            }
            if (hero is Mercy)
            {
                return 0;
            }
            if (hero is Winston)
            {
                return 0;
            }
            if (hero is Zarya)
            {
                return 0;
            }
            return 50;
        }
    }
}