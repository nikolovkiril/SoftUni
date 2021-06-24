using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Comman;
using Telephony.Contracts;

namespace Telephony.Models
{
    public class StationaryPhone : ICallOtherPhones
    {
        public StationaryPhone()
        {

        }
        public string PhoneNumber(string number)
        {
            if (number.Any(char.IsLetter))
            {
                throw new ArgumentException(string.Format(GlobalExeptionMsg.WrongNumberExceptionMessage));
            }
            return $"Dialing... {number}";
        }
    }
}
