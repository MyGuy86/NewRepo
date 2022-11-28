using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Buildings = new HashSet<Building>();
            Interventions = new HashSet<Intervention>();
        }

        public long? AddressId { get; set; }
        public long? UserId { get; set; }
        public long Id { get; set; }
        public string? CustomerCreationDate { get; set; }
        public string? Date { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyHqadress { get; set; }
        public string? FullNameOfCompanyContact { get; set; }
        public string? CompanyContactPhone { get; set; }
        public string? CompanyContactEmail { get; set; }
        public string? CompanyDesc { get; set; }
        public string? FullNameServiceTechAuth { get; set; }
        public string? TechAuthPhoneService { get; set; }
        public string? TechManagerEmailService { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Address? Address { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
    }
}
