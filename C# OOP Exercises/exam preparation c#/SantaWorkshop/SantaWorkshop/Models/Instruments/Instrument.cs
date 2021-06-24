using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32.SafeHandles;
using SantaWorkshop.Models.Instruments.Contracts;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
        private const int Decreases_Power = 10;
        private int power;

        public Instrument(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get=>this.power;
            private set=> this.power = value > 0 ? value : 0;
        }

        public void Use()
        {
            this.power -= Decreases_Power;
        }


        public bool IsBroken() => this.power == 0;
    }
}
