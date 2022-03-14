namespace PaperHelp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationToOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "ClientId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "ClientId");
            AddForeignKey("dbo.Orders", "ClientId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ClientId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "ClientId" });
            AlterColumn("dbo.Orders", "ClientId", c => c.String());
        }
    }
}
