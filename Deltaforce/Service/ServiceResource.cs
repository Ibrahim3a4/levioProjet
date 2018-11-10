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
    public class ServiceResource : Service<Resource> , IServiceResource 
    {

        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork uof = new UnitOfWork(dbf);


        public ServiceResource() : base(uof)
        {

        }

        public IEnumerable<Resource> Get5MostRatedResource()
        {
            var req = from p in GetMany()
                      orderby p.Rating descending
                      select p;
            return req.Take(5);
        }


        public IEnumerable<Resource> GetResourceBySalary(float Sal)
        {
            var req = from p in GetMany()
                      orderby p.Salary == Sal
                      select p;
            return req;
        }







    }
}
