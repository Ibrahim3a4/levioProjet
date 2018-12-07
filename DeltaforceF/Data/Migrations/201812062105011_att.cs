namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class att : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                        HiringDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Salary = c.Single(),
                        InterMandateId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        InterMandate_InterMandateId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InterMandates", t => t.InterMandate_InterMandateId)
                .ForeignKey("dbo.InterMandates", t => t.InterMandateId)
                .Index(t => t.InterMandateId)
                .Index(t => t.InterMandate_InterMandateId);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.UserId)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Project_id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Address = c.String(),
                        Type = c.Int(nullable: false),
                        TotalNbrRessources = c.Int(nullable: false),
                        TotalNbrLevio = c.Int(nullable: false),
                        Image = c.String(),
                        Client_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Project_id)
                .ForeignKey("dbo.Users", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Mandates",
                c => new
                    {
                        IdResource = c.String(nullable: false, maxLength: 128),
                        IdProject = c.Int(nullable: false),
                        MandateId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Fees = c.Int(),
                        Disponibility = c.String(),
                        IdMandateHistory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdResource, t.IdProject })
                .ForeignKey("dbo.MandateHistories", t => t.IdMandateHistory, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.IdProject, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IdResource, cascadeDelete: true)
                .Index(t => t.IdResource)
                .Index(t => t.IdProject)
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
                "dbo.InterMandates",
                c => new
                    {
                        InterMandateId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IdResource = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.InterMandateId)
                .ForeignKey("dbo.Users", t => t.IdResource)
                .Index(t => t.IdResource);
            
            CreateTable(
                "dbo.SkillResources",
                c => new
                    {
                        SkillIdFK = c.Int(nullable: false),
                        ResourceIdFK = c.String(nullable: false, maxLength: 128),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SkillIdFK, t.ResourceIdFK })
                .ForeignKey("dbo.Users", t => t.ResourceIdFK, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.SkillIdFK, cascadeDelete: true)
                .Index(t => t.SkillIdFK)
                .Index(t => t.ResourceIdFK);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                    })
                .PrimaryKey(t => t.SkillId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Receiver = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        MessageDate = c.DateTime(nullable: false),
                        Received = c.Boolean(nullable: false),
                        Sender = c.String(),
                        MUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Users", t => t.MUser_Id)
                .Index(t => t.MUser_Id);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        idRequest = c.Int(nullable: false, identity: true),
                        requirements = c.String(),
                        profileRequired = c.String(),
                        career = c.String(),
                        startDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        endDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        depositDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.idRequest);
            
            CreateTable(
                "dbo.ResourceHistories",
                c => new
                    {
                        ResourceHistoryId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.ResourceHistoryId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DayOffResources",
                c => new
                    {
                        DayOff_DayoffId = c.Int(nullable: false),
                        Resource_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.DayOff_DayoffId, t.Resource_Id })
                .ForeignKey("dbo.DayOffs", t => t.DayOff_DayoffId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Resource_Id, cascadeDelete: true)
                .Index(t => t.DayOff_DayoffId)
                .Index(t => t.Resource_Id);
            
            CreateTable(
                "dbo.HolidayResources",
                c => new
                    {
                        Holiday_HolidayId = c.Int(nullable: false),
                        Resource_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Holiday_HolidayId, t.Resource_Id })
                .ForeignKey("dbo.Holidays", t => t.Holiday_HolidayId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Resource_Id, cascadeDelete: true)
                .Index(t => t.Holiday_HolidayId)
                .Index(t => t.Resource_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Messages", "MUser_Id", "dbo.Users");
            DropForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.IdentityUserLogins", "User_Id", "dbo.Users");
            DropForeignKey("dbo.IdentityUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Projects", "Client_Id", "dbo.Users");
            DropForeignKey("dbo.SkillResources", "SkillIdFK", "dbo.Skills");
            DropForeignKey("dbo.SkillResources", "ResourceIdFK", "dbo.Users");
            DropForeignKey("dbo.Mandates", "IdResource", "dbo.Users");
            DropForeignKey("dbo.Users", "InterMandateId", "dbo.InterMandates");
            DropForeignKey("dbo.Users", "InterMandate_InterMandateId", "dbo.InterMandates");
            DropForeignKey("dbo.InterMandates", "IdResource", "dbo.Users");
            DropForeignKey("dbo.HolidayResources", "Resource_Id", "dbo.Users");
            DropForeignKey("dbo.HolidayResources", "Holiday_HolidayId", "dbo.Holidays");
            DropForeignKey("dbo.DayOffResources", "Resource_Id", "dbo.Users");
            DropForeignKey("dbo.DayOffResources", "DayOff_DayoffId", "dbo.DayOffs");
            DropForeignKey("dbo.Mandates", "IdProject", "dbo.Projects");
            DropForeignKey("dbo.Mandates", "IdMandateHistory", "dbo.MandateHistories");
            DropIndex("dbo.HolidayResources", new[] { "Resource_Id" });
            DropIndex("dbo.HolidayResources", new[] { "Holiday_HolidayId" });
            DropIndex("dbo.DayOffResources", new[] { "Resource_Id" });
            DropIndex("dbo.DayOffResources", new[] { "DayOff_DayoffId" });
            DropIndex("dbo.Messages", new[] { "MUser_Id" });
            DropIndex("dbo.SkillResources", new[] { "ResourceIdFK" });
            DropIndex("dbo.SkillResources", new[] { "SkillIdFK" });
            DropIndex("dbo.InterMandates", new[] { "IdResource" });
            DropIndex("dbo.Mandates", new[] { "IdMandateHistory" });
            DropIndex("dbo.Mandates", new[] { "IdProject" });
            DropIndex("dbo.Mandates", new[] { "IdResource" });
            DropIndex("dbo.Projects", new[] { "Client_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropIndex("dbo.IdentityUserLogins", new[] { "User_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "InterMandate_InterMandateId" });
            DropIndex("dbo.Users", new[] { "InterMandateId" });
            DropTable("dbo.HolidayResources");
            DropTable("dbo.DayOffResources");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.ResourceHistories");
            DropTable("dbo.Requests");
            DropTable("dbo.Messages");
            DropTable("dbo.Skills");
            DropTable("dbo.SkillResources");
            DropTable("dbo.InterMandates");
            DropTable("dbo.Holidays");
            DropTable("dbo.DayOffs");
            DropTable("dbo.MandateHistories");
            DropTable("dbo.Mandates");
            DropTable("dbo.Projects");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.Users");
        }
    }
}
