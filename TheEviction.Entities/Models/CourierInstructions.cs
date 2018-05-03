using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class CourierInstructions
    {
        public CourierInstructions()
        {
            Eviction = new HashSet<Eviction>();
        }

        public int CourierInstructionsId { get; set; }
        public string CourierInstructions1 { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public ICollection<Eviction> Eviction { get; set; }
    }
}
