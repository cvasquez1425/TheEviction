using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheEviction.Entities.Models
{
    public interface IClientRepository
    {
        Client GetClientByName(string clientName);
        IEnumerable<Client> GetTopClientDataTables();
    }
}
