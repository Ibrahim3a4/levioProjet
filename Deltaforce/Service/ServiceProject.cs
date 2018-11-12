using Domain.Entity;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFinance.Data.Infrastructure;
using Infrastructure;
using Data.Infrastructure;

namespace Service
{
    public class ServiceProject : Service<Project>, IServiceProject
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork uof = new UnitOfWork(dbf);
        public ServiceProject() : base(uof)
        {
        }

    }
}
