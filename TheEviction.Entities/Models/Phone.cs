using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class Phone
    {
        public Phone()
        {
            Client = new HashSet<Client>();
            Defendant = new HashSet<Defendant>();
        }

        public int PhoneId { get; set; }
        public int PhoneTypeId { get; set; }
        public string PhoneNum { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        public int? PhoneEntityTypeId { get; set; }
        public string PhoneExt { get; set; }

        public PhoneEntityType PhoneEntityType { get; set; }
        public PhoneType PhoneType { get; set; }
        public ICollection<Client> Client { get; set; }
        public ICollection<Defendant> Defendant { get; set; }
    }
}
