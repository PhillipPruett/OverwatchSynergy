using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api.Heroes
{
    public class Bastion : Hero
    {
        public override string Id => "bastion";
        public override string Name => "Bastion";
        public override string Role => "Defense";

        public override int GetSynergyValue(Hero hero)
        {
            if (hero is Reinhardt)
            {
                return 100;
            }
            return 0;
        }

        public override int GetStrengthAgainstValue(Hero hero)
        {
            if (hero is Winston)
            {
                return 100;
            }
            if (hero is Reinhardt)
            {
                return 100;
            }
            if (hero is McCree)
            {
                return 100;
            }
            if (hero is Genji)
            {
                return 0;
            }
            if (hero is Junkrat)
            {
                return 0;
            }
            if (hero is Widowmaker)
            {
                return 0;
            }
            return 50;
        }
    }
}