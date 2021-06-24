 using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exeptions
{
    public class InvalidCorpsExeptionMsg : Exception
    {
        private const string INVALID_CORPS_MSG = "Invalid corps!";
        public InvalidCorpsExeptionMsg() : base (INVALID_CORPS_MSG)
        {

        }

        public InvalidCorpsExeptionMsg(string message) : base(message)
        {
        }

    }
}
