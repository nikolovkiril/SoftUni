using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl
{
    public class Robot : ICheckId
    {
        private string model;
        public Robot(string model,string id)
        {
            this.model = model;
            this.Id = id;
        }

        public string Id { get; private set; }
}
}
