using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class Attorney
    {
        public Attorney()
        {
            Eviction = new HashSet<Eviction>();
        }

        public int AttorneyId { get; set; }
        public string Email { get; set; }
        public string Initials { get; set; }
        public string Osbnum { get; set; }
        public string Wsbnum { get; set; }
        public string AttyName { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public ICollection<Eviction> Eviction { get; set; }
    }
}
