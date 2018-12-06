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
    public class ServiceResourceSabrine : Service<Resource> , IServiceResourceSabrine
    {

        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork uof = new UnitOfWork(dbf);


        public ServiceResourceSabrine() : base(uof)
        {

        }

        public IEnumerable<Resource> GetResourceByInterMandate(int id)
        {
            return this.GetMany().Where(r => r.InterMandateId == id);
        }
    }
}
