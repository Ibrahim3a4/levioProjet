namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sabrine : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mandates", "IdProject", "dbo.Projects");
            DropForeignKey("dbo.Mandates", "Resource_Id", "dbo.Users");
            DropIndex("dbo.Mandates", new[] { "Resource_Id" });
            RenameColumn(table: "dbo.Mandates", name: "Resource_Id", newName: "IdResource");
            DropPrimaryKey("dbo.Mandates");
            AddColumn("dbo.Users", "InterMandate_InterMandateId", c => c.Int());
            AddColumn("dbo.Mandates", "Disponibility", c => c.String());
            AddColumn("dbo.InterMandates", "IdResource", c => c.String(maxLength: 128));
            AlterColumn("dbo.Mandates", "Fees", c => c.Int());
            AlterColumn("dbo.Mandates", "IdResource", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Mandates", new[] { "IdResource", "IdProject" });
            CreateIndex("dbo.Users", "InterMandate_InterMandateId");
            CreateIndex("dbo.Mandates", "IdResource");
            CreateIndex("dbo.InterMandates", "IdResource");
            AddForeignKey("dbo.InterMandates", "IdResource", "dbo.Users", "Id");
            AddForeignKey("dbo.Users", "InterMandate_InterMandateId", "dbo.InterMandates", "InterMandateId");
            AddForeignKey("dbo.Mandates", "IdProject", "dbo.Projects", "Project_id", cascadeDelete: true);
            AddForeignKey("dbo.Mandates", "IdResource", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mandates", "IdResource", "dbo.Users");
            DropForeignKey("dbo.Mandates", "IdProject", "dbo.Projects");
            DropForeignKey("dbo.Users", "InterMandate_InterMandateId", "dbo.InterMandates");
            DropForeignKey("dbo.InterMandates", "IdResource", "dbo.Users");
            DropIndex("dbo.InterMandates", new[] { "IdResource" });
            DropIndex("dbo.Mandates", new[] { "IdResource" });
            DropIndex("dbo.Users", new[] { "InterMandate_InterMandateId" });
            DropPrimaryKey("dbo.Mandates");
            AlterColumn("dbo.Mandates", "IdResource", c => c.String(maxLength: 128));
            AlterColumn("dbo.Mandates", "Fees", c => c.Single(nullable: false));
            DropColumn("dbo.InterMandates", "IdResource");
            DropColumn("dbo.Mandates", "Disponibility");
            DropColumn("dbo.Users", "InterMandate_InterMandateId");
            AddPrimaryKey("dbo.Mandates", "IdProject");
            RenameColumn(table: "dbo.Mandates", name: "IdResource", newName: "Resource_Id");
            CreateIndex("dbo.Mandates", "Resource_Id");
            AddForeignKey("dbo.Mandates", "Resource_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Mandates", "IdProject", "dbo.Projects", "Project_id");
        }
    }
}
