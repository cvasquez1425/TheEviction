using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class LeaseType
    {
        public LeaseType()
        {
            Eviction = new HashSet<Eviction>();
        }

        public int LeaseTypeId { get; set; }
        public string LeaseTypeDesc { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public ICollection<Eviction> Eviction { get; set; }
    }
}
