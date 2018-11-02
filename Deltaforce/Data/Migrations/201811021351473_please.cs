namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class please : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Gender = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Category = c.Int(),
                        Type = c.Int(),
                        Logo = c.String(),
                        Addresse = c.String(),
                        OrganizationalChart = c.String(),
                        NbResInServ = c.Int(),
                        NbProjAf = c.Int(),
                        Seniority = c.String(),
                        BusinessProfile = c.String(),
                        Rating = c.Int(),
                        CV = c.String(),
                        Contract = c.Int(),
                        Availability = c.Int(),
                        Photo = c.String(),
                        HiringDate = c.DateTime(),
                        Salary = c.Single(),
                        AdRole = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        InterMandate_InterMandateId = c.Int(),
                        Mandate_MandateId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InterMandates", t => t.InterMandate_InterMandateId)
                .ForeignKey("dbo.Mandates", t => t.Mandate_MandateId)
                .Index(t => t.InterMandate_InterMandateId)
                .Index(t => t.Mandate_MandateId);
            
            CreateTable(
                "dbo.CustomUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CustomUserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CustomRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomRoles", t => t.CustomRole_Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CustomRole_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Project_id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        Type = c.Int(nullable: false),
                        TotalNbrRessources = c.Int(nullable: false),
                        TotalNbrLevio = c.Int(nullable: false),
                        Image = c.String(),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Project_id)
                .ForeignKey("dbo.Users", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.DayOffs",
                c => new
                    {
                        DayoffId = c.Int(nullable: false, identity: true),
                        DDate = c.DateTime(nullable: false),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.DayoffId);
            
            CreateTable(
                "dbo.Holidays",
                c => new
                    {
                        HolidayId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        History = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HolidayId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillId);
            
            CreateTable(
                "dbo.InterMandates",
                c => new
                    {
                        InterMandateId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InterMandateId);
            
            CreateTable(
                "dbo.Mandates",
                c => new
                    {
                        MandateId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Fees = c.Single(nullable: false),
                        IdMandateHistory = c.Int(),
                        Project_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MandateId)
                .ForeignKey("dbo.MandateHistories", t => t.IdMandateHistory)
                .Index(t => t.IdMandateHistory);
            
            CreateTable(
                "dbo.MandateHistories",
                c => new
                    {
                        IdMandateHistory = c.Int(nullable: false, identity: true),
                        SaveDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdMandateHistory);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        MessageDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        Subject = c.String(),
                        Received = c.Boolean(nullable: false),
                        Sender = c.String(),
                        Receiver = c.String(),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.CustomRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResourceDayOffs",
                c => new
                    {
                        Resource_Id = c.Int(nullable: false),
                        DayOff_DayoffId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Resource_Id, t.DayOff_DayoffId })
                .ForeignKey("dbo.Users", t => t.Resource_Id, cascadeDelete: true)
                .ForeignKey("dbo.DayOffs", t => t.DayOff_DayoffId, cascadeDelete: true)
                .Index(t => t.Resource_Id)
                .Index(t => t.DayOff_DayoffId);
            
            CreateTable(
                "dbo.HolidayResources",
                c => new
                    {
                        Holiday_HolidayId = c.Int(nullable: false),
                        Resource_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Holiday_HolidayId, t.Resource_Id })
                .ForeignKey("dbo.Holidays", t => t.Holiday_HolidayId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Resource_Id, cascadeDelete: true)
                .Index(t => t.Holiday_HolidayId)
                .Index(t => t.Resource_Id);
            
            CreateTable(
                "dbo.SkillResources",
                c => new
                    {
                        Skill_SkillId = c.Int(nullable: false),
                        Resource_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Skill_SkillId, t.Resource_Id })
                .ForeignKey("dbo.Skills", t => t.Skill_SkillId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Resource_Id, cascadeDelete: true)
                .Index(t => t.Skill_SkillId)
                .Index(t => t.Resource_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomUserRoles", "CustomRole_Id", "dbo.CustomRoles");
            DropForeignKey("dbo.Mandates", "IdMandateHistory", "dbo.MandateHistories");
            DropForeignKey("dbo.Users", "Mandate_MandateId", "dbo.Mandates");
            DropForeignKey("dbo.Users", "InterMandate_InterMandateId", "dbo.InterMandates");
            DropForeignKey("dbo.SkillResources", "Resource_Id", "dbo.Users");
            DropForeignKey("dbo.SkillResources", "Skill_SkillId", "dbo.Skills");
            DropForeignKey("dbo.HolidayResources", "Resource_Id", "dbo.Users");
            DropForeignKey("dbo.HolidayResources", "Holiday_HolidayId", "dbo.Holidays");
            DropForeignKey("dbo.ResourceDayOffs", "DayOff_DayoffId", "dbo.DayOffs");
            DropForeignKey("dbo.ResourceDayOffs", "Resource_Id", "dbo.Users");
            DropForeignKey("dbo.Projects", "Client_Id", "dbo.Users");
            DropIndex("dbo.SkillResources", new[] { "Resource_Id" });
            DropIndex("dbo.SkillResources", new[] { "Skill_SkillId" });
            DropIndex("dbo.HolidayResources", new[] { "Resource_Id" });
            DropIndex("dbo.HolidayResources", new[] { "Holiday_HolidayId" });
            DropIndex("dbo.ResourceDayOffs", new[] { "DayOff_DayoffId" });
            DropIndex("dbo.ResourceDayOffs", new[] { "Resource_Id" });
            DropIndex("dbo.Mandates", new[] { "IdMandateHistory" });
            DropIndex("dbo.Projects", new[] { "Client_Id" });
            DropIndex("dbo.CustomUserRoles", new[] { "CustomRole_Id" });
            DropIndex("dbo.CustomUserRoles", new[] { "UserId" });
            DropIndex("dbo.CustomUserLogins", new[] { "UserId" });
            DropIndex("dbo.CustomUserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Mandate_MandateId" });
            DropIndex("dbo.Users", new[] { "InterMandate_InterMandateId" });
            DropTable("dbo.SkillResources");
            DropTable("dbo.HolidayResources");
            DropTable("dbo.ResourceDayOffs");
            DropTable("dbo.CustomRoles");
            DropTable("dbo.Messages");
            DropTable("dbo.MandateHistories");
            DropTable("dbo.Mandates");
            DropTable("dbo.InterMandates");
            DropTable("dbo.Skills");
            DropTable("dbo.Holidays");
            DropTable("dbo.DayOffs");
            DropTable("dbo.Projects");
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.CustomUserLogins");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.Users");
        }
    }
}
