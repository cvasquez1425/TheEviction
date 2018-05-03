using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class ContactType
    {
        public ContactType()
        {
            Contact = new HashSet<Contact>();
        }

        public int ContractTypeId { get; set; }
        public string ContactTypeDesc { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public ICollection<Contact> Contact { get; set; }
    }
}
