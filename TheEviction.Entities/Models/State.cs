using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class State
    {
        public State()
        {
            Address = new HashSet<Address>();
            County = new HashSet<County>();
        }

        public int StateId { get; set; }
        public string StateAbbr { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public Country Country { get; set; }
        public ICollection<Address> Address { get; set; }
        public ICollection<County> County { get; set; }
    }
}
