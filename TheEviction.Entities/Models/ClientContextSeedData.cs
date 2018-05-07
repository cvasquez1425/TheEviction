using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEviction.Entities.Models
{
    public class ClientContextSeedData
    {
        private EvictionDevContext _context;

        public ClientContextSeedData(EvictionDevContext context)
        {
            _context = context;
        }
        public async Task EnsureSeedData()
        {
            //are there any Client int the database
            if (!_context.Client.Any())
            {
                var seedClient = new Client()
                {
                    ClientNum = 12345,
                    ClientName = "John Doe",
                    CompanyTypeId = 10,
                    FacilityId = 1,
                    AddressId = 5,
                    ContactId = 3,  // I just added manually.
                    PhoneId = 6,
                    CountyId = 12, // Clark
                    Notes = "This is Seed Test Client Data",
                    CreatedDt = DateTime.UtcNow,
                    CreatedBy = 748,
                    Eviction = new List<Eviction>()
                    {

                    },
                    Matter = new List<Matter>()
                    {

                    }
                };
                var seedClientPeterBrown = new Client()
                {
                    ClientNum = 12345,
                    ClientName = "Peter Brown",
                    CompanyTypeId = 10,
                    FacilityId = 1,
                    AddressId = 5,
                    ContactId = 3,  // I just added manually.
                    PhoneId = 6,
                    CountyId = 12, // Clark
                    Notes = "This is Seed Test Client Data Peter Brown",
                    CreatedDt = DateTime.UtcNow,
                    CreatedBy = 748,
                    Eviction = new List<Eviction>()
                    {

                    },
                    Matter = new List<Matter>()
                    {

                    }
                };
                var seedClientJohnSmith = new Client()
                {
                    ClientNum = 12345,
                    ClientName = "John Smith",
                    CompanyTypeId = 10,
                    FacilityId = 1,
                    AddressId = 5,
                    ContactId = 3,  // I just added manually.
                    PhoneId = 6,
                    CountyId = 12, // Clark
                    Notes = "This is Seed Test Client Data John Smith",
                    CreatedDt = DateTime.UtcNow,
                    CreatedBy = 748,
                    Eviction = new List<Eviction>()
                    {

                    },
                    Matter = new List<Matter>()
                    {

                    }
                };
                // Adding the context.
                _context.Client.Add(seedClient);
                _context.Client.Add(seedClientPeterBrown);
                _context.Client.Add(seedClientJohnSmith);
                
                // This will actually PUSH the data to the EvictionDev Database
                await _context.SaveChangesAsync();
            }
        }
    }
}
