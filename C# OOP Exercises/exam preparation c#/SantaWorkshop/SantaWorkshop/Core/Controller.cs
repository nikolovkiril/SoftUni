using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private readonly DwarfRepository dwarfs;
        private readonly PresentRepository presents;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;
            switch (dwarfType)
            {
                case "HappyDwarf":
                    {
                        dwarf = new HappyDwarf(dwarfName);
                        dwarfs.Add(dwarf);
                        break;
                    }
                case "SleepyDwarf":
                    {
                        dwarf = new SleepyDwarf(dwarfName);
                        dwarfs.Add(dwarf);
                        break;
                    }
                default:
                    {
                        throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
                        break;
                    }
            }
            return $"Successfully added {dwarfType} named {dwarfName}.";
        }



        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IDwarf dwarf = dwarfs.FindByName(dwarfName);
            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            dwarf.Instruments.Add(new Instrument(power));
            return $"Successfully added instrument with power {power} to dwarf {dwarfName}!";

        }

        public string AddPresent(string presentName, int energyRequired)
        {
            presents.Add(new Present(presentName,energyRequired));
            return string.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            Workshop workShop = new Workshop();
            IPresent present = presents.FindByName(presentName); 
            ICollection<IDwarf> dwarves = dwarfs
                .Models
                .Where(dw => dw.Energy >= 50)
                .OrderByDescending(dw => dw.Energy)
                .ToList();
            if (!dwarves.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }
            while (dwarves.Any())
            {
                IDwarf currDwarf = dwarves.First();
                workShop.Craft(present, currDwarf);
                if (!currDwarf.Instruments.Any())
                {
                    dwarves.Remove(currDwarf);
                }
                if (currDwarf.Energy == 0)
                {
                    dwarves.Remove(currDwarf);
                    dwarfs.Remove(currDwarf);
                }
                if (present.IsDone())
                {
                    break;
                }
            }

            return string.Format(present.IsDone() ? OutputMessages.PresentIsDone : OutputMessages.PresentIsNotDone,
                presentName);

        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{presents.Models.Count(p=>p.IsDone())} presents are done!");
            sb.AppendLine("Dwarfs info:");
            foreach (var dwarf in this.dwarfs.Models)
            {
                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments {dwarf.Instruments.Count} not broken left");
            }

            return sb.ToString().Trim();
        }
    }
}
