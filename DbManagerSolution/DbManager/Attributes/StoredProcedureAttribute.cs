using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Attributes
{
    public class StoredProcedureAttribute : Attribute
    {
        public string Name { get; set; }

        public StoredProcedureAttribute(string name)
        {
            Name = name;
        }
    }
}
