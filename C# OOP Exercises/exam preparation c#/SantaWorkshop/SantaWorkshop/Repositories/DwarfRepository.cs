﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly List<IDwarf> models;

        public DwarfRepository()
        {
            this.models = new List<IDwarf>();
        }
        public IReadOnlyCollection<IDwarf> Models => this.models;
        public void Add(IDwarf model)
        {
            this.models.Add(model);
        }

        public bool Remove(IDwarf model) => this.models.Remove(model);

        public IDwarf FindByName(string name) => this.models.FirstOrDefault(n => n.Name == name);
    }
}
