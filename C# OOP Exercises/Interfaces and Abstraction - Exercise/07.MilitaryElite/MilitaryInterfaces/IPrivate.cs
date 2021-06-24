using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.MilitaryInfo
{
    public interface IPrivate : ISoldiers
    {
        decimal Salary { get; }
    }
}
