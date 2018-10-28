namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        LastAuthentification = c.DateTime(nullable: false),
                        Role = c.String(),
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
                    })
                .PrimaryKey(t => t.UserId);
            
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
                        Client_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Project_id)
                .ForeignKey("dbo.Users", t => t.Client_UserId)
                .Index(t => t.Client_UserId);
            
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
                "dbo.ResourceDayOffs",
                c => new
                    {
                        Resource_UserId = c.Int(nullable: false),
                        DayOff_DayoffId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Resource_UserId, t.DayOff_DayoffId })
                .ForeignKey("dbo.Users", t => t.Resource_UserId, cascadeDelete: true)
                .ForeignKey("dbo.DayOffs", t => t.DayOff_DayoffId, cascadeDelete: true)
                .Index(t => t.Resource_UserId)
                .Index(t => t.DayOff_DayoffId);
            
            CreateTable(
                "dbo.HolidayResources",
                c => new
                    {
                        Holiday_HolidayId = c.Int(nullable: false),
                        Resource_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Holiday_HolidayId, t.Resource_UserId })
                .ForeignKey("dbo.Holidays", t => t.Holiday_HolidayId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Resource_UserId, cascadeDelete: true)
                .Index(t => t.Holiday_HolidayId)
                .Index(t => t.Resource_UserId);
            
            CreateTable(
                "dbo.SkillResources",
                c => new
                    {
                        Skill_SkillId = c.Int(nullable: false),
                        Resource_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Skill_SkillId, t.Resource_UserId })
                .ForeignKey("dbo.Skills", t => t.Skill_SkillId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Resource_UserId, cascadeDelete: true)
                .Index(t => t.Skill_SkillId)
                .Index(t => t.Resource_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SkillResources", "Resource_UserId", "dbo.Users");
            DropForeignKey("dbo.SkillResources", "Skill_SkillId", "dbo.Skills");
            DropForeignKey("dbo.HolidayResources", "Resource_UserId", "dbo.Users");
            DropForeignKey("dbo.HolidayResources", "Holiday_HolidayId", "dbo.Holidays");
            DropForeignKey("dbo.ResourceDayOffs", "DayOff_DayoffId", "dbo.DayOffs");
            DropForeignKey("dbo.ResourceDayOffs", "Resource_UserId", "dbo.Users");
            DropForeignKey("dbo.Projects", "Client_UserId", "dbo.Users");
            DropIndex("dbo.SkillResources", new[] { "Resource_UserId" });
            DropIndex("dbo.SkillResources", new[] { "Skill_SkillId" });
            DropIndex("dbo.HolidayResources", new[] { "Resource_UserId" });
            DropIndex("dbo.HolidayResources", new[] { "Holiday_HolidayId" });
            DropIndex("dbo.ResourceDayOffs", new[] { "DayOff_DayoffId" });
            DropIndex("dbo.ResourceDayOffs", new[] { "Resource_UserId" });
            DropIndex("dbo.Projects", new[] { "Client_UserId" });
            DropTable("dbo.SkillResources");
            DropTable("dbo.HolidayResources");
            DropTable("dbo.ResourceDayOffs");
            DropTable("dbo.Messages");
            DropTable("dbo.Skills");
            DropTable("dbo.Holidays");
            DropTable("dbo.DayOffs");
            DropTable("dbo.Projects");
            DropTable("dbo.Users");
        }
    }
}
