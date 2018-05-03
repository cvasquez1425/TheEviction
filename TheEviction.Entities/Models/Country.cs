using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class Country
    {
        public Country()
        {
            Address = new HashSet<Address>();
            State = new HashSet<State>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public ICollection<Address> Address { get; set; }
        public ICollection<State> State { get; set; }
    }
}
