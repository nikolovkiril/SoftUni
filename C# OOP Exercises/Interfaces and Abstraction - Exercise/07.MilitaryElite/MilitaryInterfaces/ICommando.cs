using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.MilitaryInterfaces 
{
    public interface ICommando : ISpecialisedSoldier
    {

        IReadOnlyCollection<IMissions> Missions { get; }

        void AddMission(IMissions mission);
    }
}
