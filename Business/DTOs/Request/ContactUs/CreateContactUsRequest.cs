﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.ContactUs
{
    public class CreateContactUsRequest
    {
        
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Message { get; set; }

        
    }
}
