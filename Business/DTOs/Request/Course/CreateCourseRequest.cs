﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Course
{
    public class CreateCourseRequest
    {
        public int? CourseLevelId { get; set; }
        public int? CourseStatusId { get; set; }
        public int? SoftwareLanguageId { get; set; }
        public int? CategoryId { get; set; }
        public string? CertificateURL { get; set; }
        public int? Progress { get; set; }
        public string? Name { get; set; }
        public string? ImagePath { get; set; }
        public double? Price { get; set; }
    }
}
