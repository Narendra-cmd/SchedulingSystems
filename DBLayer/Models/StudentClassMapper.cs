using System;
using System.Collections.Generic;

#nullable disable

namespace DBLayer.Models
{
    public partial class StudentClassMapper
    {
        public int MapperId { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateTime? AssignedDate { get; set; }
        public string AssignedBy { get; set; }
        public bool? IsActive { get; set; }
}
}
