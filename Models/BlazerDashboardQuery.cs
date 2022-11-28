using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class BlazerDashboardQuery
    {
        public long Id { get; set; }
        public long? DashboardId { get; set; }
        public long? QueryId { get; set; }
        public int? Position { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
