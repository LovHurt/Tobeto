﻿using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Manager
{
    public class CreatedManagerResponse : BasePageableModel
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public int ManagerCode { get; set; }
        public bool IsActive { get; set; }
    }
}
