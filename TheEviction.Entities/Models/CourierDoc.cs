using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class CourierDoc
    {
        public CourierDoc()
        {
            Eviction = new HashSet<Eviction>();
        }

        public int CourierDocId { get; set; }
        public string DocName { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public ICollection<Eviction> Eviction { get; set; }
    }
}
