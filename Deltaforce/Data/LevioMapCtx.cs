using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
    public class LevioMapCtx : DbContext
    {

        //Constructeur 
        public LevioMapCtx (): base("LevioLastHope")
        {
           
        }

        
        public  DbSet<Client> Client { get; set; }

        public DbSet<DayOff> DayOff { get; set; }
        public DbSet<Holiday> Holiday { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<Resource> Resource { get; set; }

        public DbSet<Skill> Skill { get; set; }
        public DbSet<RecruitmentManager> RecruitmentManager { get; set; }
        public DbSet<Applicant> Applicant { get; set; }

        public DbSet<Message> Message  { get; set; }
        public DbSet<Project> project { get; set; }
        public DbSet<Mandate> Mandat { get; set; }
        public DbSet<InterMandate> InterMandat { get; set; }
        public DbSet<MandateHistory> MandatHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //pour enlever des conventions
            // modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            

        }



    }
}
