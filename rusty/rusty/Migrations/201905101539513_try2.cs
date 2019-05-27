namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class try2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Request_RequestId", "dbo.Requests");
            DropForeignKey("dbo.Customers", "Request_RequestId", "dbo.Requests");
            DropForeignKey("dbo.Storages", "Request_RequestId", "dbo.Requests");
            DropForeignKey("dbo.Supplies", "ShipperId", "dbo.Shippers");
            DropForeignKey("dbo.Storages", "SupplyId", "dbo.Supplies");
            DropIndex("dbo.Cars", new[] { "Request_RequestId" });
            DropIndex("dbo.Customers", new[] { "Request_RequestId" });
            DropIndex("dbo.Storages", new[] { "SupplyId" });
            DropIndex("dbo.Storages", new[] { "Request_RequestId" });
            DropIndex("dbo.Supplies", new[] { "ShipperId" });
            AddColumn("dbo.Requests", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Supplies", "Cast", c => c.Single(nullable: false));
            AlterColumn("dbo.Requests", "StorageId", c => c.Int(nullable: false));
            DropColumn("dbo.Cars", "Request_RequestId");
            DropColumn("dbo.Requests", "CustomId");
            DropColumn("dbo.Customers", "Request_RequestId");
            DropColumn("dbo.Storages", "Request_RequestId");
            DropColumn("dbo.Supplies", "Cost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Supplies", "Cost", c => c.Single(nullable: false));
            AddColumn("dbo.Storages", "Request_RequestId", c => c.Int());
            AddColumn("dbo.Customers", "Request_RequestId", c => c.Int());
            AddColumn("dbo.Requests", "CustomId", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Request_RequestId", c => c.Int());
            AlterColumn("dbo.Requests", "StorageId", c => c.String());
            DropColumn("dbo.Supplies", "Cast");
            DropColumn("dbo.Requests", "CustomerId");
            CreateIndex("dbo.Supplies", "ShipperId");
            CreateIndex("dbo.Storages", "Request_RequestId");
            CreateIndex("dbo.Storages", "SupplyId");
            CreateIndex("dbo.Customers", "Request_RequestId");
            CreateIndex("dbo.Cars", "Request_RequestId");
            AddForeignKey("dbo.Storages", "SupplyId", "dbo.Supplies", "SupplyId", cascadeDelete: true);
            AddForeignKey("dbo.Supplies", "ShipperId", "dbo.Shippers", "ShipperId", cascadeDelete: true);
            AddForeignKey("dbo.Storages", "Request_RequestId", "dbo.Requests", "RequestId");
            AddForeignKey("dbo.Customers", "Request_RequestId", "dbo.Requests", "RequestId");
            AddForeignKey("dbo.Cars", "Request_RequestId", "dbo.Requests", "RequestId");
        }
    }
}
