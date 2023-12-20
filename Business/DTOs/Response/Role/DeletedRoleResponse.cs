﻿using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Role
{
    public class DeletedRoleResponse : BasePageableModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
