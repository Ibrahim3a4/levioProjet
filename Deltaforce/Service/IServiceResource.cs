using Domain.Entity;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IServiceResource : IService<Resource>
    {
        IEnumerable<Resource> Get5MostRatedResource();
        IEnumerable<Resource> GetResourceBySalary(float Sal);
    }
}
