﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Exam
{
    public class GetListExamResponse
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Point { get; set; }
        public TimeSpan ExamDuration { get; set; }
    }
}
