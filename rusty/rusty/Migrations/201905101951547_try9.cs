namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class try9 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Requests", "CustomerId");
            CreateIndex("dbo.Requests", "CarId");
            CreateIndex("dbo.Requests", "StorageId");
            CreateIndex("dbo.Storages", "SupplyId");
            CreateIndex("dbo.Supplies", "ShipperId");
            AddForeignKey("dbo.Requests", "CarId", "dbo.Cars", "CarId", cascadeDelete: true);
            AddForeignKey("dbo.Requests", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Requests", "StorageId", "dbo.Storages", "StorageId", cascadeDelete: true);
            AddForeignKey("dbo.Supplies", "ShipperId", "dbo.Shippers", "ShipperId", cascadeDelete: true);
            AddForeignKey("dbo.Storages", "SupplyId", "dbo.Supplies", "SupplyId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Storages", "SupplyId", "dbo.Supplies");
            DropForeignKey("dbo.Supplies", "ShipperId", "dbo.Shippers");
            DropForeignKey("dbo.Requests", "StorageId", "dbo.Storages");
            DropForeignKey("dbo.Requests", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Requests", "CarId", "dbo.Cars");
            DropIndex("dbo.Supplies", new[] { "ShipperId" });
            DropIndex("dbo.Storages", new[] { "SupplyId" });
            DropIndex("dbo.Requests", new[] { "StorageId" });
            DropIndex("dbo.Requests", new[] { "CarId" });
            DropIndex("dbo.Requests", new[] { "CustomerId" });
        }
    }
}
