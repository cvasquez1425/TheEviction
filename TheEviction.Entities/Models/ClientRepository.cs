#region Includes
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace TheEviction.Entities.Models
{
    public class ClientRepository : IClientRepository
    {
        private EvictionDevContext _context;

        public ClientRepository(EvictionDevContext context)
        {
            _context = context;
        }

        public Client GetClientByName(string clientName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetTopClientDataTables()
        {
            return _context.Client
                    .Include(c => c.Contact)
                    .Include(c => c.CompanyType)
                    .Take(10)
                    .OrderByDescending(c => c.CreatedDt)
                    .ToList();
        }
    }
}
