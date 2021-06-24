using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface ISoldiers
    {
        int Id { get; }
        string FirstName  { get; }
        string LastName { get; }
    }
}
