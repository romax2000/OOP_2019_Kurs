namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class try6 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Requests", "CarId");
            AddForeignKey("dbo.Requests", "CarId", "dbo.Cars", "CarId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "CarId", "dbo.Cars");
            DropIndex("dbo.Requests", new[] { "CarId" });
        }
    }
}
