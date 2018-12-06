using Domain;
using Domain.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data
{
    public class ApplicationUserStore : UserStore<User>
    {

        public ApplicationUserStore(LevioMapCtx context) : base(context)
        {
        }
    }
}
