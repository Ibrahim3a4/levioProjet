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
    public class ServiceInterMandate : Service<InterMandate>, IServiceInterMandate
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork utwk = new UnitOfWork(dbf);
        public ServiceInterMandate() : base(utwk)
        {

        }

        public void AddInterMandate(InterMandate im)
        {
            this.Add(im);
            this.Commit();
        }

        public void DeleteInterMandate(InterMandate im)
        {
            this.Delete(im);
            this.Commit();
        }

        public InterMandate GetInterMandate(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InterMandate> GetInterMandates()
        {
            return this.GetMany();
        }

        public void UpdateInterMandate(InterMandate im)
        {
            this.Update(im);
            this.Commit();
        }
    }
}
