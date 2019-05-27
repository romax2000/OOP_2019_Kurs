namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class try5 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Requests", "StorageId");
            AddForeignKey("dbo.Requests", "StorageId", "dbo.Storages", "StorageId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "StorageId", "dbo.Storages");
            DropIndex("dbo.Requests", new[] { "StorageId" });
        }
    }
}
