using MilitaryElite.Enumerators;
using MilitaryElite.MilitaryInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.MilitaryInterfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
