using Data.Infrastructure;
using Domain.Entity;
using Infrastructure;
using MyFinance.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceClient : Service<Client>, IServiceClient
    {

        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork uof = new UnitOfWork(dbf);


        public ServiceClient() : base(uof)
        {
        }

        public Client GetClientbyId(int id)
        {
            return uof.getRepository<Client>().GetById(id);

        }

        public IEnumerable<Client> GetClientsByType(ClientType t)
        {
            var clients = from m in uof.getRepository<Client>().GetMany()
                          where m.Type == t
                          select m;
            return clients;
        }
    }
}
