namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "SenderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Messages", "SenderId");
            AddForeignKey("dbo.Messages", "SenderId", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Messages", "Sender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Sender", c => c.String());
            DropForeignKey("dbo.Messages", "SenderId", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropColumn("dbo.Messages", "SenderId");
        }
    }
}
