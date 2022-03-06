namespace test3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "UsersId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "UsersId");
            AddForeignKey("dbo.Employees", "UsersId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Employees", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "UserId", c => c.String());
            DropForeignKey("dbo.Employees", "UsersId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "UsersId" });
            DropColumn("dbo.Employees", "UsersId");
        }
    }
}
