using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using MyFinance.Data.Infrastructure;
using ServicePattern;
using Infrastructure;
using Data.Infrastructure;

namespace Service
{
    public class ServiceMandate :  Service<Mandate>,IServiceMandate
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork utwk = new UnitOfWork(dbf);
        public ServiceMandate() : base(utwk)
        {
        }

        public void AddMandate(Mandate m)
        {
            this.Add(m);
            this.Commit();
        }

        public void DeleteMandate(Mandate m)
        {
            this.Delete(m);
            this.Commit();
        }

        public Mandate GetMandate(int id)
        {
            return GetMany().Where(e => e.MandateId == id).FirstOrDefault();
        }

        public IEnumerable<Mandate> GetMandates()
        {
            return this.GetMany();
        }

        public void UpdateMandate(Mandate m)
        {
            this.Update(m);
            this.Commit();
        }
    }
}
