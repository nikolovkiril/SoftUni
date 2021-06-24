using MilitaryElite.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.MilitaryInterfaces
{
    public interface IMissions
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
