namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDbSupply : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        SupplyId = c.Int(nullable: false, identity: true),
                        Product = c.String(),
                        NumberProduct = c.String(),
                        DateOrder = c.DateTime(nullable: false),
                        ShipperId = c.Int(nullable: false),
                        Cost = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.SupplyId)
                .ForeignKey("dbo.Shippers", t => t.ShipperId, cascadeDelete: true)
                .Index(t => t.ShipperId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supplies", "ShipperId", "dbo.Shippers");
            DropIndex("dbo.Supplies", new[] { "ShipperId" });
            DropTable("dbo.Supplies");
        }
    }
}
