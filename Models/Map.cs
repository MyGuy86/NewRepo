using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class Map
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
