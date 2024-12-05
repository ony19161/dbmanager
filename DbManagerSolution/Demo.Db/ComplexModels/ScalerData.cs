using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Db.ComplexModels
{
    public class ScalerData<T>
    {
        [Column("value")]
        public T? Value { get; set; }
    }
}
