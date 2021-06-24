using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Contracts;

namespace WildFarm.Models.Food
{
    public class Fruit : Food
    {
        public Fruit(int quantity) 
            : base(quantity)
        {
        }
    }
}
