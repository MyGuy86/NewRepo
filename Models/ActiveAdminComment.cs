using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class ActiveAdminComment
    {
        public long Id { get; set; }
        public string? Namespace { get; set; }
        public string? Body { get; set; }
        public string? ResourceType { get; set; }
        public long? ResourceId { get; set; }
        public string? AuthorType { get; set; }
        public long? AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
