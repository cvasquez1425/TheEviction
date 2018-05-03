using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class CourtType
    {
        public CourtType()
        {
            CourtDate = new HashSet<CourtDate>();
        }

        public int CourtTypeId { get; set; }
        public string CourtTypeDesc { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public ICollection<CourtDate> CourtDate { get; set; }
    }
}
