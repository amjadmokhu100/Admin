namespace test3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnUserIdToEmployees : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "UserId");
        }
    }
}
