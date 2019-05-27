namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class errorkill9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "CustomerName", c => c.String());
            AddColumn("dbo.Requests", "CarName", c => c.String());
            AddColumn("dbo.Requests", "StorageName", c => c.String());
            AddColumn("dbo.Orders", "CustomerName", c => c.String());
            AddColumn("dbo.Orders", "MasterName", c => c.String());
            AddColumn("dbo.Masters", "WorkplaseName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Masters", "WorkplaseName");
            DropColumn("dbo.Orders", "MasterName");
            DropColumn("dbo.Orders", "CustomerName");
            DropColumn("dbo.Requests", "StorageName");
            DropColumn("dbo.Requests", "CarName");
            DropColumn("dbo.Requests", "CustomerName");
        }
    }
}
