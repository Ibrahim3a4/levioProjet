using Domain.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
    public class LevioMapCtx : IdentityDbContext<User>
    {

        public static LevioMapCtx Create()
        {
            return new LevioMapCtx();
        }

      
        //Constructeur 
        public LevioMapCtx (): base("Name=MapLevio")
        {
            Database.SetInitializer(new ContexInit());

        }


         public DbSet<Client> Client { get; set; }
        public DbSet<SkillResource> SkillResource { get; set; }

        public DbSet<DayOff> DayOff { get; set; }
        public DbSet<Holiday> Holiday { get; set; }

       // public DbSet<User> User { get; set; }
        public DbSet<Resource> Resource { get; set; }

        public DbSet<Skill> Skill { get; set; }
        public DbSet<RecruitmentManager> RecruitmentManager { get; set; }
        public DbSet<Applicant> Applicant { get; set; }

        public DbSet<Message> Message { get; set; }
        public DbSet<Project> project { get; set; }
        public DbSet<Mandate> Mandat { get; set; }
        public DbSet<InterMandate> InterMandat { get; set; }
        public DbSet<MandateHistory> MandatHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
        public class ContexInit : DropCreateDatabaseIfModelChanges<LevioMapCtx>
        {
            protected override void Seed(LevioMapCtx context)
            {
                Client p = new Client();
                p.Email = "ah@gmail.com";
                p.PasswordHash = "123456789";
                p.UserName = "ah";
                context.Users.Add(p);
                context.SaveChanges();
            }
        }


    }
}
