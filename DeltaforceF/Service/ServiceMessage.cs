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
   public class ServiceMessage : Service<Message> , IServiceMessage
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        static IUnitOfWork uof = new UnitOfWork(dbf);


        public ServiceMessage() : base(uof)
        {

        }
       public  IEnumerable<Message> GetReceivedMessages(string curUserName)
        {
            var msgs = from m in GetMany().ToList()
                       where m.Receiver == curUserName
                       select m;
            return msgs;
        }

        public IEnumerable<Message> GetSentMessages(string curUserId)
        {
            var msgs = from m in GetMany().ToList()
                       where m.Sender == curUserId
                       select m;
            return msgs;
        }
    }
}
