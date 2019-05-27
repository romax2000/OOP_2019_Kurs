namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class try8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Requests", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Requests", "StorageId", "dbo.Storages");
            DropForeignKey("dbo.Supplies", "ShipperId", "dbo.Shippers");
            DropForeignKey("dbo.Supplies", "Storage_StorageId", "dbo.Storages");
            DropIndex("dbo.Requests", new[] { "CustomerId" });
            DropIndex("dbo.Requests", new[] { "CarId" });
            DropIndex("dbo.Requests", new[] { "StorageId" });
            DropIndex("dbo.Supplies", new[] { "ShipperId" });
            DropIndex("dbo.Supplies", new[] { "Storage_StorageId" });
            DropColumn("dbo.Supplies", "Storage_StorageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Supplies", "Storage_StorageId", c => c.Int());
            CreateIndex("dbo.Supplies", "Storage_StorageId");
            CreateIndex("dbo.Supplies", "ShipperId");
            CreateIndex("dbo.Requests", "StorageId");
            CreateIndex("dbo.Requests", "CarId");
            CreateIndex("dbo.Requests", "CustomerId");
            AddForeignKey("dbo.Supplies", "Storage_StorageId", "dbo.Storages", "StorageId");
            AddForeignKey("dbo.Supplies", "ShipperId", "dbo.Shippers", "ShipperId", cascadeDelete: true);
            AddForeignKey("dbo.Requests", "StorageId", "dbo.Storages", "StorageId", cascadeDelete: true);
            AddForeignKey("dbo.Requests", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Requests", "CarId", "dbo.Cars", "CarId", cascadeDelete: true);
        }
    }
}
