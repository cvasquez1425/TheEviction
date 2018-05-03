using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class CompanyType
    {
        public CompanyType()
        {
            Client = new HashSet<Client>();
        }

        public int CompanyTypeId { get; set; }
        public string CompanyTypeName { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public ICollection<Client> Client { get; set; }
    }
}
