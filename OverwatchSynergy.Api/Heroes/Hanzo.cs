﻿using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Hanzo : Hero
    {
        public override string Name => "Hanzo";
        public override string Role => "Defense";

        public override int GetSynergyValue(Hero hero)
        {
            return 0;
        }
    }
}