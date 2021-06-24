using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exeptions
{
    public class InvalidStateMissionMsg : Exception
    {

        private const string INVALID_MISSION_MSG = "Invalid mission state!";
        public InvalidStateMissionMsg() : base(INVALID_MISSION_MSG)
        {
        }

        public InvalidStateMissionMsg(string message) : base(message)
        {
        }
    }
}
