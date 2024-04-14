using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Attributes
{
    public class SpParamDirectionAttribute : Attribute
    {
        public string Direction { get; set; }

        public SpParamDirectionAttribute(string direction)
        {
            Direction = direction;
        }
    }
}
