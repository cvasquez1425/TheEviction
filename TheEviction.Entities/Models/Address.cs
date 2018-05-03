using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class Address
    {
        public Address()
        {
            Client = new HashSet<Client>();
            Defendant = new HashSet<Defendant>();
            Eviction = new HashSet<Eviction>();
            Facility = new HashSet<Facility>();
        }

        public int AddressId { get; set; }
        public int AddressTypeId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public string Zip { get; set; }
        public int CountryId { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public AddressType AddressType { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public ICollection<Client> Client { get; set; }
        public ICollection<Defendant> Defendant { get; set; }
        public ICollection<Eviction> Eviction { get; set; }
        public ICollection<Facility> Facility { get; set; }
    }
}
