using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Threeuple
{
    public class Tuple<TFirst, TSecond, TThird>
    {
        public Tuple(TFirst first, TSecond second, TThird third)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
        }
        public TFirst First { get; set; }
        public TSecond Second { get; set; }
        public TThird Third { get; set; }

        public override string ToString()
        {
            return $"{this.First} -> { this.Second} -> {this.Third}";
        }
        
    }
}
