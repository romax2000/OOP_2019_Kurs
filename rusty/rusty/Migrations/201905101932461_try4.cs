namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class try4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Supplies", "Storage_StorageId", c => c.Int());
            CreateIndex("dbo.Supplies", "Storage_StorageId");
            AddForeignKey("dbo.Supplies", "Storage_StorageId", "dbo.Storages", "StorageId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supplies", "Storage_StorageId", "dbo.Storages");
            DropIndex("dbo.Supplies", new[] { "Storage_StorageId" });
            DropColumn("dbo.Supplies", "Storage_StorageId");
        }
    }
}
