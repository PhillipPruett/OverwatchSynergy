﻿using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Tracer : Hero
    {
        public override string Name => "Tracer";
        public override string Role => "Attack";

        public override int GetSynergyValue(Hero hero)
        {
            return 0;
        }
    }
}