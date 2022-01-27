using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBLayer.DTO
{
    [Keyless]
    public class StudentMappingDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }

    [Keyless]
    public class ClassMappingDto
    {
        public string ClassName { get; set; }
        public string Description { get; set; }
    }
}
