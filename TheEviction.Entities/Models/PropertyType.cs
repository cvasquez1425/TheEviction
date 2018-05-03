using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class PropertyType
    {
        public PropertyType()
        {
            Eviction = new HashSet<Eviction>();
        }

        public int PropertyTypeId { get; set; }
        public string PropertyType1 { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public ICollection<Eviction> Eviction { get; set; }
    }
}
