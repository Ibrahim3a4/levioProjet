using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IServiceInterMandate
    {
        void AddInterMandate(InterMandate im);
        void UpdateInterMandate(InterMandate im);
        void DeleteInterMandate(InterMandate im);
        InterMandate GetInterMandate(int id);
        IEnumerable<InterMandate> GetInterMandates();
    }
}
