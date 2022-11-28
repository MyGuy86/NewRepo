using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class BlazerQuery
    {
        public long Id { get; set; }
        public long? CreatorId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Statement { get; set; }
        public string? DataSource { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
