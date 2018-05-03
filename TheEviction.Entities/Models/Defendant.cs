using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class Defendant
    {
        public Defendant()
        {
            Eviction = new HashSet<Eviction>();
        }

        public int DefendantId { get; set; }
        public string DefendantFirstName { get; set; }
        public string DefendantLastName { get; set; }
        public string DefendantSsn { get; set; }
        public int? AddressId { get; set; }
        public int? PhoneId { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public Address Address { get; set; }
        public Phone Phone { get; set; }
        public ICollection<Eviction> Eviction { get; set; }
    }
}
