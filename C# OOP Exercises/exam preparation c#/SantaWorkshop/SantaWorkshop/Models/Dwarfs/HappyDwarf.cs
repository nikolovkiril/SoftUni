using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class HappyDwarf : Dwarf
    {
        public HappyDwarf(string name)
            : base(name, 100)
        {

        }


        //public override void Work()
        //{
        //    base.Work();
        //    this.Energy -= 5;
        //}
    }
}
