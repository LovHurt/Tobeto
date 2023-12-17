﻿using Business.DTOs.Request.Student;
using Business.DTOs.Response.Student;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStudentService
    {
        Task<IPaginate<GetListStudentResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedStudentResponse> Add(CreateStudentRequest createStudentRequest);
        Task<UpdatedStudentResponse> Update(UpdateStudentRequest updateStudentRequest);
        Task<DeletedStudentResponse> Delete(DeleteStudentRequest deleteStudentRequest);
        Task<CreatedStudentResponse> GetById(Guid id);
    }
}