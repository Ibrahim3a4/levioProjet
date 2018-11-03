namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ResourceDayOffs", newName: "DayOffResources");
            DropForeignKey("dbo.Users", "Mandate_MandateId", "dbo.Mandates");
            DropForeignKey("dbo.Users", "InterMandate_InterMandateId", "dbo.InterMandates");
            DropForeignKey("dbo.Mandates", "IdMandateHistory", "dbo.MandateHistories");
            DropIndex("dbo.Users", new[] { "Mandate_MandateId" });
            DropIndex("dbo.Mandates", new[] { "IdMandateHistory" });
            RenameColumn(table: "dbo.Users", name: "InterMandate_InterMandateId", newName: "InterMandateId");
            RenameIndex(table: "dbo.Users", name: "IX_InterMandate_InterMandateId", newName: "IX_InterMandateId");
            DropPrimaryKey("dbo.Mandates");
            DropPrimaryKey("dbo.DayOffResources");
            AddColumn("dbo.Mandates", "IdResource", c => c.Int(nullable: false));
            AddColumn("dbo.Mandates", "IdProject", c => c.Int(nullable: false));
            AlterColumn("dbo.Mandates", "MandateId", c => c.Int(nullable: false));
            AlterColumn("dbo.Mandates", "IdMandateHistory", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Mandates", new[] { "IdResource", "IdProject" });
            AddPrimaryKey("dbo.DayOffResources", new[] { "DayOff_DayoffId", "Resource_Id" });
            CreateIndex("dbo.Mandates", "IdResource");
            CreateIndex("dbo.Mandates", "IdProject");
            CreateIndex("dbo.Mandates", "IdMandateHistory");
            AddForeignKey("dbo.Mandates", "IdProject", "dbo.Projects", "Project_id", cascadeDelete: true);
            AddForeignKey("dbo.Mandates", "IdResource", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "InterMandateId", "dbo.InterMandates", "InterMandateId", cascadeDelete: true);
            AddForeignKey("dbo.Mandates", "IdMandateHistory", "dbo.MandateHistories", "IdMandateHistory", cascadeDelete: true);
            DropColumn("dbo.Users", "Mandate_MandateId");
            DropColumn("dbo.Mandates", "Project_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mandates", "Project_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Mandate_MandateId", c => c.Int());
            DropForeignKey("dbo.Mandates", "IdMandateHistory", "dbo.MandateHistories");
            DropForeignKey("dbo.Users", "InterMandateId", "dbo.InterMandates");
            DropForeignKey("dbo.Mandates", "IdResource", "dbo.Users");
            DropForeignKey("dbo.Mandates", "IdProject", "dbo.Projects");
            DropIndex("dbo.Mandates", new[] { "IdMandateHistory" });
            DropIndex("dbo.Mandates", new[] { "IdProject" });
            DropIndex("dbo.Mandates", new[] { "IdResource" });
            DropPrimaryKey("dbo.DayOffResources");
            DropPrimaryKey("dbo.Mandates");
            AlterColumn("dbo.Mandates", "IdMandateHistory", c => c.Int());
            AlterColumn("dbo.Mandates", "MandateId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Mandates", "IdProject");
            DropColumn("dbo.Mandates", "IdResource");
            AddPrimaryKey("dbo.DayOffResources", new[] { "Resource_Id", "DayOff_DayoffId" });
            AddPrimaryKey("dbo.Mandates", "MandateId");
            RenameIndex(table: "dbo.Users", name: "IX_InterMandateId", newName: "IX_InterMandate_InterMandateId");
            RenameColumn(table: "dbo.Users", name: "InterMandateId", newName: "InterMandate_InterMandateId");
            CreateIndex("dbo.Mandates", "IdMandateHistory");
            CreateIndex("dbo.Users", "Mandate_MandateId");
            AddForeignKey("dbo.Mandates", "IdMandateHistory", "dbo.MandateHistories", "IdMandateHistory");
            AddForeignKey("dbo.Users", "InterMandate_InterMandateId", "dbo.InterMandates", "InterMandateId");
            AddForeignKey("dbo.Users", "Mandate_MandateId", "dbo.Mandates", "MandateId");
            RenameTable(name: "dbo.DayOffResources", newName: "ResourceDayOffs");
        }
    }
}
