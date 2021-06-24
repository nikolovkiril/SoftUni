using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Comman;
using Telephony.Contracts;

namespace Telephony.Models
{
    public class Smartphone : ICallOtherPhones, IBrowseInWeb
    {
        public Smartphone()
        {

        }
        public string PhoneNumber(string number)
        {
            if (number.Any(char.IsLetter))
            {
                throw new ArgumentException(string.Format(GlobalExeptionMsg.WrongNumberExceptionMessage));
            }
            return $"Calling... {number}";

        }
        public string Url(string url)
        {
            if (url.Any(char.IsDigit))
            {
                throw new ArgumentException(string.Format(GlobalExeptionMsg.WrongUrlExceptionMessage));
            }
            return $"Browsing: {url}!";
        }
    }
}
