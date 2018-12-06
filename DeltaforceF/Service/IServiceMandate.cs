using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IServiceMandate
    {
        void AddMandate(Mandate m);
        void UpdateMandate(Mandate m);
        void DeleteMandate(Mandate m);
        Mandate GetMandate(int id);
        IEnumerable<Mandate> GetMandates();
    }
}
