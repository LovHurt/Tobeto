﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.ApplicationStudent
{
    public class CreateApplicationStudentRequest
    {
        public int ApplicationId { get; set; }
        public Guid StudentId { get; set; }
    }
}
