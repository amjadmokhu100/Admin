namespace PaperHelp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewRelationToOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "writerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Orders", "ProfreaderId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "writerId");
            CreateIndex("dbo.Orders", "ProfreaderId");
            AddForeignKey("dbo.Orders", "ProfreaderId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Orders", "writerId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "writerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "ProfreaderId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "ProfreaderId" });
            DropIndex("dbo.Orders", new[] { "writerId" });
            AlterColumn("dbo.Orders", "ProfreaderId", c => c.String());
            AlterColumn("dbo.Orders", "writerId", c => c.String());
        }
    }
}
