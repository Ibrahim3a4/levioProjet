namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastOne : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Users", "InterMandate_InterMandateId", c => c.Int());
            AddColumn("dbo.Users", "Mandate_MandateId", c => c.Int());
            CreateIndex("dbo.Users", "InterMandate_InterMandateId");
            CreateIndex("dbo.Users", "Mandate_MandateId");
            AddForeignKey("dbo.Users", "InterMandate_InterMandateId", "dbo.InterMandates", "InterMandateId");
            AddForeignKey("dbo.Users", "Mandate_MandateId", "dbo.Mandates", "MandateId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mandates", "IdMandateHistory", "dbo.MandateHistories");
            DropForeignKey("dbo.Users", "Mandate_MandateId", "dbo.Mandates");
            DropForeignKey("dbo.Users", "InterMandate_InterMandateId", "dbo.InterMandates");
            DropIndex("dbo.Mandates", new[] { "IdMandateHistory" });
            DropIndex("dbo.Users", new[] { "Mandate_MandateId" });
            DropIndex("dbo.Users", new[] { "InterMandate_InterMandateId" });
            DropColumn("dbo.Users", "Mandate_MandateId");
            DropColumn("dbo.Users", "InterMandate_InterMandateId");
            DropTable("dbo.MandateHistories");
            DropTable("dbo.Mandates");
            DropTable("dbo.InterMandates");
        }
    }
}
