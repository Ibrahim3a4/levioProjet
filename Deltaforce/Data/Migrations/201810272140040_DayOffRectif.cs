namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DayOffRectif : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "SenderId", "dbo.Users");
            DropForeignKey("dbo.ResourceDayOffs", "DayOff_DayoffId", "dbo.DayOffs");
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropIndex("dbo.ResourceDayOffs", new[] { "DayOff_DayoffId" });
            DropPrimaryKey("dbo.DayOffs");
            DropPrimaryKey("dbo.ResourceDayOffs");
            AddColumn("dbo.DayOffs", "DayDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Messages", "Sender", c => c.String());
            AlterColumn("dbo.DayOffs", "DayoffId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ResourceDayOffs", "DayOff_DayoffId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.DayOffs", "DayoffId");
            AddPrimaryKey("dbo.ResourceDayOffs", new[] { "Resource_UserId", "DayOff_DayoffId" });
            CreateIndex("dbo.ResourceDayOffs", "DayOff_DayoffId");
            AddForeignKey("dbo.ResourceDayOffs", "DayOff_DayoffId", "dbo.DayOffs", "DayoffId", cascadeDelete: true);
            DropColumn("dbo.DayOffs", "StartDate");
            DropColumn("dbo.Messages", "SenderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "SenderId", c => c.Int(nullable: false));
            AddColumn("dbo.DayOffs", "StartDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.ResourceDayOffs", "DayOff_DayoffId", "dbo.DayOffs");
            DropIndex("dbo.ResourceDayOffs", new[] { "DayOff_DayoffId" });
            DropPrimaryKey("dbo.ResourceDayOffs");
            DropPrimaryKey("dbo.DayOffs");
            AlterColumn("dbo.ResourceDayOffs", "DayOff_DayoffId", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DayOffs", "DayoffId", c => c.DateTime(nullable: false));
            DropColumn("dbo.Messages", "Sender");
            DropColumn("dbo.DayOffs", "DayDate");
            AddPrimaryKey("dbo.ResourceDayOffs", new[] { "Resource_UserId", "DayOff_DayoffId" });
            AddPrimaryKey("dbo.DayOffs", "DayoffId");
            CreateIndex("dbo.ResourceDayOffs", "DayOff_DayoffId");
            CreateIndex("dbo.Messages", "SenderId");
            AddForeignKey("dbo.ResourceDayOffs", "DayOff_DayoffId", "dbo.DayOffs", "DayoffId", cascadeDelete: true);
            AddForeignKey("dbo.Messages", "SenderId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
