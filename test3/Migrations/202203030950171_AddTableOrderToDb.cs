namespace PaperHelp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableOrderToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.String(),
                        ServiceId = c.Int(nullable: false),
                        IsNormal = c.Boolean(),
                        NoOfPaper = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        duration = c.Byte(),
                        startDate = c.DateTime(),
                        finishedDate = c.DateTime(),
                        ClientNote = c.String(),
                        Description = c.String(),
                        writerId = c.String(),
                        ProfreaderId = c.String(),
                        FinalFilePath = c.String(),
                        ProfraderNotes = c.String(),
                        OrderStatus = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ServiceId", "dbo.Services");
            DropIndex("dbo.Orders", new[] { "ServiceId" });
            DropTable("dbo.Orders");
        }
    }
}
