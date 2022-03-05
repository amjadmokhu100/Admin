namespace test3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableAssFileToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssFiles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FilePath = c.String(),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssFiles", "OrderId", "dbo.Orders");
            DropIndex("dbo.AssFiles", new[] { "OrderId" });
            DropTable("dbo.AssFiles");
        }
    }
}
