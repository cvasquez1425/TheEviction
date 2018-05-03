using System;
using System.Collections.Generic;

namespace TheEviction.Entities.Models
{
    public partial class Users
    {
        public Users()
        {
            Eviction = new HashSet<Eviction>();
        }

        public int UserId { get; set; }
        public string GmUserId { get; set; }
        public string UserName { get; set; }

        public ICollection<Eviction> Eviction { get; set; }
    }
}
