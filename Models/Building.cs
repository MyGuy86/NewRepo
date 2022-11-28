using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class Building
    {
        public Building()
        {
            Batteries = new HashSet<Battery>();
            BuildingDetails = new HashSet<BuildingDetail>();
            Interventions = new HashSet<Intervention>();
        }

        public long? CustomerId { get; set; }
        public long? AddressId { get; set; }
        public long Id { get; set; }
        public string? FullNameOfBuildingAdmin { get; set; }
        public string? EmailOfAdminOfBuilding { get; set; }
        public int? PhoneNumOfBuildingAdmin { get; set; }
        public string? FullNameOfTechContactForBuilding { get; set; }
        public string? TechContactEmailForBuilding { get; set; }
        public int? TechContactPhoneForBuilding { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Address? Address { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<Battery> Batteries { get; set; }
        public virtual ICollection<BuildingDetail> BuildingDetails { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
    }
}
