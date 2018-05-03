using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class CourtDate
    {
        public CourtDate()
        {
            Eviction = new HashSet<Eviction>();
        }

        public int CourtDtId { get; set; }
        public int CourtTypeId { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CourtDt { get; set; }

        public CourtType CourtType { get; set; }
        public ICollection<Eviction> Eviction { get; set; }
    }
}
