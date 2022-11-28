using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class Quote
    {
        public long Id { get; set; }
        public string? BuildingType { get; set; }
        public string? ServiceQuality { get; set; }
        public string? NumberOfApartments { get; set; }
        public string? NumberOfFloors { get; set; }
        public string? NumberOfBusinesses { get; set; }
        public string? NumberOfBasements { get; set; }
        public string? NumberOfParking { get; set; }
        public string? NumberOfCages { get; set; }
        public string? NumberOfOccupants { get; set; }
        public string? NumberOfHours { get; set; }
        public string? NumberOfElevatorsNeeded { get; set; }
        public string? PricePerUnit { get; set; }
        public string? ElevatorPrice { get; set; }
        public string? InstallationFee { get; set; }
        public string? FinalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Name { get; set; }
        public string? CompanyName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Department { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDescription { get; set; }
    }
}
