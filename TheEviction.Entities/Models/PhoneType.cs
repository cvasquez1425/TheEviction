using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class PhoneType
    {
        public PhoneType()
        {
            Phone = new HashSet<Phone>();
        }

        public int PhoneTypeId { get; set; }
        public string PhoneTypeDesc { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public ICollection<Phone> Phone { get; set; }
    }
}
