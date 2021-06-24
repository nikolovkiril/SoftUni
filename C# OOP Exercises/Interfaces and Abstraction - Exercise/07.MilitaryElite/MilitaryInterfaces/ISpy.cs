using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.MilitaryInterfaces
{
    public interface ISpy : ISoldiers
    {
        int CodeNumber { get; }
    }
}
