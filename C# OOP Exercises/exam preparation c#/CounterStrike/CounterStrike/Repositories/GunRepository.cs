using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> modelOfGuns;

        public GunRepository()
        {
            this.modelOfGuns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.modelOfGuns;
        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            this.modelOfGuns.Add(model);
        }

        public bool Remove(IGun model) => this.modelOfGuns.Remove(model);

        public IGun FindByName(string name)
        {
            return this.modelOfGuns.Where(g => g.Name == name).FirstOrDefault() as Gun;
        }
    }
}
