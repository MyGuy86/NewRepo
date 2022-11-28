using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class Column
    {
        public Column()
        {
            Elevators = new HashSet<Elevator>();
            Interventions = new HashSet<Intervention>();
        }

        public long? BatteryId { get; set; }
        public long Id { get; set; }
        public string? Type { get; set; }
        public int? NumOfFloorsServed { get; set; }
        public string? Status { get; set; }
        public string? Information { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Battery? Battery { get; set; }
        public virtual ICollection<Elevator> Elevators { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
    }
}
