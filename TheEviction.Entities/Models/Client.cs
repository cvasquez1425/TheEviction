using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class Client
    {
        public Client()
        {
            Eviction = new HashSet<Eviction>();
            Matter = new HashSet<Matter>();
        }

        public int ClientId { get; set; }
        public int ClientNum { get; set; }
        public string ClientName { get; set; }
        public int CompanyTypeId { get; set; }
        public int? FacilityId { get; set; }
        public int? AddressId { get; set; }
        public int? ContactId { get; set; }
        public int? PhoneId { get; set; }
        public int CountyId { get; set; }
        public string Notes { get; set; }
        public bool IsActiveFlg { get; set; }
        public bool? IsOfficeAccessFlg { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public Address Address { get; set; }
        public CompanyType CompanyType { get; set; }
        public Contact Contact { get; set; }
        public County County { get; set; }
        public Facility Facility { get; set; }
        public Phone Phone { get; set; }
        public ICollection<Eviction> Eviction { get; set; }
        public ICollection<Matter> Matter { get; set; }
    }
}
