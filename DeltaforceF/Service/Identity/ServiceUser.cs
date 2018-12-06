using Data;
using Data.Infrastructure;
using Domain;
using Domain.Entity;
using Microsoft.AspNet.Identity;
using MyFinance.Data.Infrastructure;
using Service.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePattern
{
   public class ServiceUser :Service<User> 
    
    {
        //   MyfinanceContex context = new MyfinanceContex();
        public ApplicationUserManager UserManager { get; set; }

        static DatabaseFactory DBF = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(DBF);
        public ServiceUser() : base(UOW)
        {
            ApplicationUserStore store = new ApplicationUserStore(new LevioMapCtx());
            UserManager = new ApplicationUserManager(store);
        }
        //  IRepositoryBase<Product> RBP = new RepositoryBase<Product>(DBF);
       
       
      
      /*  public Boolean verif(String Log , String pswd)
        {
            Boolean v = true;
            var req = from p in GetMany()
                      where p.Email == Log
                      || p.Password == pswd
                      select p;
            if (req != null)
                v = false;
            return v;
        }*/
    
   
    }
}
