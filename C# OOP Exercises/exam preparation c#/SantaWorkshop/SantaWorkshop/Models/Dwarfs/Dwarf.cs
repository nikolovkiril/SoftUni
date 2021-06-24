using System;
using System.Collections.Generic;
using System.Text;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Utilities.Messages;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        private const int Decreases_Energy = 10;
        private string name;
        private int energy;
        private ICollection<IInstrument> instruments;

        public Dwarf()
        {
            this.instruments = new List<IInstrument>();
        }
        public Dwarf(string name, int energy)
            :this()
        {
            this.Name = name;
            this.Energy = energy;

        }

        public string Name
        {
            get=>this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }

                this.name = value;
            }
        }

        public int Energy
        {
            get=>this.energy;
            protected set=>this.energy = value > 0 ? value : 0; 
        }

        public ICollection<IInstrument> Instruments => this.instruments;
        public virtual void Work()
        {
            this.energy -= Decreases_Energy;
            
        }

        public  void AddInstrument(IInstrument instrument)
        {
            this.instruments.Add(instrument);
        }
    }
}
