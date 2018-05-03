using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class Contact
    {
        public Contact()
        {
            Client = new HashSet<Client>();
            Facility = new HashSet<Facility>();
        }

        public int ContactId { get; set; }
        public int ContractTypeId { get; set; }
        public string ContactName { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public ContactType ContractType { get; set; }
        public ICollection<Client> Client { get; set; }
        public ICollection<Facility> Facility { get; set; }
    }
}
