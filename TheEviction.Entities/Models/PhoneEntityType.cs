using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class PhoneEntityType
    {
        public PhoneEntityType()
        {
            Phone = new HashSet<Phone>();
        }

        public int PhoneEntityTypeId { get; set; }
        public string PhoneEntityTypeDesc { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public ICollection<Phone> Phone { get; set; }
    }
}
