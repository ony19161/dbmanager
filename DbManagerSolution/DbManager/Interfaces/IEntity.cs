﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; } 
        DateTime CreatedAt { get; set; }
        DateTime ModifiedAt { get; set; }
    }
}
