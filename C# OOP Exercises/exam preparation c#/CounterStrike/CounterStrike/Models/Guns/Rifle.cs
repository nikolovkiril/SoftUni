﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int Gun_Can_Strike = 10;

        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            this.BulletsCount -= Gun_Can_Strike;
            return Gun_Can_Strike;
        }
    }
}
