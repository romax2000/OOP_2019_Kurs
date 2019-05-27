namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Storage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        StorageId = c.Int(nullable: false, identity: true),
                        NumberProduct = c.Int(nullable: false),
                        Product = c.String(),
                        Number = c.Int(nullable: false),
                        SupplyId = c.Int(nullable: false),
                        Cast = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StorageId)
                .ForeignKey("dbo.Supplies", t => t.SupplyId, cascadeDelete: true)
                .Index(t => t.SupplyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Storages", "SupplyId", "dbo.Supplies");
            DropIndex("dbo.Storages", new[] { "SupplyId" });
            DropTable("dbo.Storages");
        }
    }
}
