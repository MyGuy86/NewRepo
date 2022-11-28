using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class BlazerAudit
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? QueryId { get; set; }
        public string? Statement { get; set; }
        public string? DataSource { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
