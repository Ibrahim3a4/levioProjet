using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using MyFinance.Data.Infrastructure;
using ServicePattern;
using Infrastructure;
using Data.Infrastructure;

namespace Service
{
    public class ServiceProjectSabrine : Service<Project>,IServiceProjectSabrine
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork uof = new UnitOfWork(dbf);
        public ServiceProjectSabrine() : base(uof)
        {
        }

        public IEnumerable<Project> GetProjects(int id)
        {
            return this.GetMany().Where(r => r.Project_id == id);
        }

       
    }
}
