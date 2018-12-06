using Domain.Entity;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IServiceResourceSabrine : IService<Resource>
    {
        
        IEnumerable<Resource> GetResourceByInterMandate(int id);
    }
}
