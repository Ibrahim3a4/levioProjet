using Domain.Entity;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IServiceClient : IService<Client>
    {
       Client GetClientbyId(int id);
        IEnumerable<Client> GetClientsByType(ClientType t);

    }
}
