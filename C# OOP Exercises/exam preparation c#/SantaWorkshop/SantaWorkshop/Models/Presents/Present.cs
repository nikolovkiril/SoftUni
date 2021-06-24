﻿using System;
using System.Collections.Generic;
using System.Text;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Utilities.Messages;

namespace SantaWorkshop.Models.Presents
{
    public class Present : IPresent
    {
        private const int Decreases_Energy = 10;
        private string name;
        private int energyRequired;

        public Present(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPresentName);
                }

                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get => this.energyRequired;
            private set => this.energyRequired = value > 0 ? value : 0;
        }

        public void GetCrafted()
        {
            this.energyRequired -= Decreases_Energy;

        }

        public bool IsDone() => this.energyRequired == 0;

    }
}
