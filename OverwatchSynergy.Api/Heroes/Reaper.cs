﻿using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Reaper : Hero
    {
        public override string Name => "Reaper";
        public override string Role => "Attack";



        public override int GetSynergyValue(Hero hero)
        {
            return 0;
        }
    }
}