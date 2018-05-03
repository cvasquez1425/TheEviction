using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class County
    {
        public County()
        {
            Client = new HashSet<Client>();
        }

        public int CountyId { get; set; }
        public string CountyName { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        public int StateId { get; set; }

        public State State { get; set; }
        public ICollection<Client> Client { get; set; }
    }
}
