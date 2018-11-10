using Data;
using Domain;
using Domain.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;


namespace Service.Identity
{
    public class ApplicationUserManager : UserManager<User>
    {



        public ApplicationUserManager(IUserStore<User> store) : base(store)
        {
            store = new ApplicationUserStore(new LevioMapCtx());
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var store = new UserStore<User>(context.Get<LevioMapCtx>());
            var manager = new ApplicationUserManager(store);

            // var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
              
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = false,
            };


            return manager;
        }

    }
}
