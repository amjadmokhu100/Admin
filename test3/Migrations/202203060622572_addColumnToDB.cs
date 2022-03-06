namespace test3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnToDB : DbMigration
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
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Employeekind = c.Byte(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssFiles", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ServiceId", "dbo.Services");
            DropIndex("dbo.Orders", new[] { "ServiceId" });
            DropIndex("dbo.AssFiles", new[] { "OrderId" });
            DropColumn("dbo.AspNetUsers", "IsActive");
            DropTable("dbo.Employees");
            DropTable("dbo.Services");
            DropTable("dbo.Orders");
            DropTable("dbo.AssFiles");
        }
    }
}
