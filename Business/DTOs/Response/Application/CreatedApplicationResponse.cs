﻿using Core.DataAccess.Paging;

namespace Business.DTOs.Response.Application;

public class CreatedApplicationResponse : BasePageableModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}