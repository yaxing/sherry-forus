using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class WorkerInfo
    {
        private Guid id;
        private string name;

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
