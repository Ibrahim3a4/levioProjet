using Domain.Entity;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IServiceMessage:IService<Message>
    {
        IEnumerable<Message> GetReceivedMessages(string curUserName);
        IEnumerable<Message> GetSentMessages(string curUserName);
    }
}
