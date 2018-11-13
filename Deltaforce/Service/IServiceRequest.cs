using Domain.Entity;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public interface IServiceRequest: IService<Request>
    {
       void Commit();
        void Add(Request req);


    }
}
