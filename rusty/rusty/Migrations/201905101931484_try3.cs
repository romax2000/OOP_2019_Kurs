namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class try3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Supplies", "ShipperId");
            AddForeignKey("dbo.Supplies", "ShipperId", "dbo.Shippers", "ShipperId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supplies", "ShipperId", "dbo.Shippers");
            DropIndex("dbo.Supplies", new[] { "ShipperId" });
        }
    }
}
