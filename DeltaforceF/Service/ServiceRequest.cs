using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Data;
using Infrastructure;
using Data.Infrastructure;
using MyFinance.Data.Infrastructure;
using ServicePattern;

namespace Service
{
    public class ServiceRequest :Service<Request>,IServiceRequest
    //public  class ServiceProductcs : Service<Product> ,IServiceProduct 
    {
        //LevioMapCtx ctx = new LevioMapCtx();
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork uow = new UnitOfWork(dbf);

        public ServiceRequest():base(uow)
        {
                    
        }
/*
        public void Update()
        {
            throw new NotImplementedException();
        }*/

        /**   public void Add(Request req)
  {
      dbf.DataContext.Request.Add(req);
  }

  public void Commit()
  {
      dbf.DataContext.SaveChanges();
      uow.Commit();
  }*/
    }
}
