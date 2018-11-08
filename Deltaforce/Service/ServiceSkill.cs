using Data.Infrastructure;
using Domain.Entity;
using Infrastructure;
using MyFinance.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceSkill : Service<Skill> , IServiceSkill
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork uof = new UnitOfWork(dbf);


        public ServiceSkill() : base(uof)
        {

        }


        public Skill  GetSkillById(int id)
        {
            return uof.getRepository<Skill>().GetById(id);
        }





    }
}
