using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int Pistol_Can_Strike = 1;
        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount == 0)
            {
                return 0;
            }
            this.BulletsCount -= Pistol_Can_Strike;
            return Pistol_Can_Strike;
        }
    }
}
