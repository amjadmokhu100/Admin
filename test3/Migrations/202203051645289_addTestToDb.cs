namespace test3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTestToDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.AssFiles", "OrderId", "dbo.Orders");
            DropIndex("dbo.AssFiles", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "ServiceId" });
            DropTable("dbo.AssFiles");
            DropTable("dbo.Orders");
            DropTable("dbo.Services");
            DropTable("dbo.Employees");
            DropTable("dbo.TestClassMs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestClassMs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Employeekind = c.Byte(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        NormalPrice = c.Double(),
                        NormalHour = c.Int(),
                        FastPrice = c.Double(),
                        FastHour = c.Int(),
                        Photo = c.String(),
                        Sale = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssFiles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FilePath = c.String(),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.Orders", "ServiceId");
            CreateIndex("dbo.AssFiles", "OrderId");
            AddForeignKey("dbo.AssFiles", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ServiceId", "dbo.Services", "Id", cascadeDelete: true);
        }
    }
}
