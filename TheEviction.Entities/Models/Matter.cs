using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class Matter
    {
        public Matter()
        {
            Eviction = new HashSet<Eviction>();
        }

        public int MatterId { get; set; }
        public string MatterNum { get; set; }
        public string ClientMatterNum { get; set; }
        public string MatterDesc { get; set; }
        public int ClientId { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public Client Client { get; set; }
        public ICollection<Eviction> Eviction { get; set; }
    }
}
