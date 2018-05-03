using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class Facility
    {
        public Facility()
        {
            Client = new HashSet<Client>();
        }

        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public int? ContactId { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        public int? AddressId { get; set; }

        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public ICollection<Client> Client { get; set; }
    }
}
