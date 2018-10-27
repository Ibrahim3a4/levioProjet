namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Messagemimi : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
