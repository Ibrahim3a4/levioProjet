using Data;
using Domain.Entity;
using MapWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MapWeb.Startup))]
namespace MapWeb
{
    public partial class Startup
    {
        //ApplicationDbContext db = new ApplicationDbContext();

        //public void Configuration(IAppBuilder app)
        //{

        //    ConfigureAuth(app);
        //    CreateRoles();
        //    CreateUsers();
        //}

        //public void CreateUsers()
        //{
        //    var UserManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(db));
        //    var user = new IdentityUser();
        //    user.Email = "Admin@admin.com";
        //    //user.UserName = user.Email;

        //    var check = UserManager.Create(user, "123@Dmin");
        //    if (check.Succeeded)
        //    {
        //        UserManager.AddToRole(user.Id, "Admin");
        //    }

        //}
        //public void CreateRoles()
        //{
        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        //    IdentityRole role;
        //    if (!roleManager.RoleExists("Admin"))
        //    {
        //        role = new IdentityRole();
        //        role.Name = "Admin";
        //        roleManager.Create(role);
        //    }
        //    if (!roleManager.RoleExists("Ressource"))
        //    {
        //        role = new IdentityRole();
        //        role.Name = "Ressource";
        //        roleManager.Create(role);
        //    }
        //    if (!roleManager.RoleExists("Client"))
        //    {
        //        role = new IdentityRole();
        //        role.Name = "Client";
        //        roleManager.Create(role);
        //    }
        //    if (!roleManager.RoleExists("RecruitManager"))
        //    {
        //        role = new IdentityRole();
        //        role.Name = "RecruitManager";
        //        roleManager.Create(role);
        //    }
        //}

        //public void Configuration(IAppBuilder app)
        //{
        //    ConfigureAuth(app);
        //    createRolesandUsers();
        //}


        // In this method we will create default User roles and Admin user for login   
        //private void createRolesandUsers()
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();

        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        //    var UserManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(db));


        //    // In Startup iam creating first Admin Role and creating a default Admin User    
        //    if (!roleManager.RoleExists("Admin"))
        //    {

        //        // first we create Admin rool   
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "Admin";
        //        roleManager.Create(role);

        //        //Here we create a Admin super user who will maintain the website                  

        //        var user = new IdentityUser();
        //        user.UserName = "shanu";
        //        user.Email = "syedshanumcain@gmail.com";

        //        string userPWD = "A@Z200711";

        //        var chkUser = UserManager.Create(user, userPWD);

        //        //Add default User to Role Admin   
        //        if (chkUser.Succeeded)
        //        {
        //            var result1 = UserManager.AddToRole(user.Id, "Admin");

        //        }
        //    }

        //    // creating Creating Manager role    
        //    if (!roleManager.RoleExists("Manager"))
        //    {
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "Manager";
        //        roleManager.Create(role);

        //    }

        //    // creating Creating Employee role    
        //    if (!roleManager.RoleExists("Employee"))
        //    {
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "Employee";
        //        roleManager.Create(role);

        //    }
        //}




        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }


        // In this method we will create default User roles and Admin user for login
        private void createRolesandUsers()
        {
            //LevioMapCtx context = new LevioMapCtx();
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User 
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website				

                var user = new ApplicationUser();
                user.UserName = "shanu";
                user.Email = "syedshanumcain@gmail.com";

                string userPWD = "A@Z200711";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating Creating Manager role 
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

            }

            // creating Creating Employee role 
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }
        }

    }


}

