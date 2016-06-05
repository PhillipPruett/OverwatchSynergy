﻿using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Bastion : Hero
    {
        public override string Name => "Bastion";
        public override string Role => "Defense";

        public override int GetSynergyValue(Hero hero)
        {
            return 0;
        }
    }
}