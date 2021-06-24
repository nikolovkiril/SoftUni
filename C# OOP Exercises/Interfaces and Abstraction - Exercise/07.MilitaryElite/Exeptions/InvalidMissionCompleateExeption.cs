using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exeptions
{
    public class InvalidMissionCompleateExeption : Exception
    {

        private const string INVALID_MISSION_COMPLEATE_MSG = "Mission awready compleated!";
        public InvalidMissionCompleateExeption() : base()
        {
        }

        public InvalidMissionCompleateExeption(string message) : base(message)
        {
        }
    }

}
