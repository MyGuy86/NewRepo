using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class Lead
    {
        public long Id { get; set; }
        public string? FullNameOfTheContact { get; set; }
        public string? BussinessName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDescription { get; set; }
        public string? DepartmentIncharge { get; set; }
        public string? Message { get; set; }
        public byte[]? AttachedFile { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
