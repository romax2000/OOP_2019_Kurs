namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class try7 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Requests", "CustomerId");
            AddForeignKey("dbo.Requests", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Requests", new[] { "CustomerId" });
        }
    }
}
