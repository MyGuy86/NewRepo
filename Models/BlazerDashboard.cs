using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class BlazerDashboard
    {
        public long Id { get; set; }
        public long? CreatorId { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
