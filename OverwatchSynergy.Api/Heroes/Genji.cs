using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OverwatchSynergy.Api.Heroes
{
    public class Genji : Hero
    {
        public override string Name => "Genji";
        public override string Role => "Attack";

        public override int GetSynergyValue(Hero hero)
        {
            return 0;
        }
    }
}