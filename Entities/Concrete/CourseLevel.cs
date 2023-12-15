﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CourseLevel:Entity<int> 
    {
        public string Name { get; set; }
        public int CourseId { get; set; }   

    }
}
