using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.MilitaryInfo
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldiers> Privates { get; }

        void AddPrivate(ISoldiers @private);
    }
}
