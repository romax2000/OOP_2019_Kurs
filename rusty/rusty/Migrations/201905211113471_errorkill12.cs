namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class errorkill12 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Requests", "ServiceId");
            AddForeignKey("dbo.Requests", "ServiceId", "dbo.Services", "ServiceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "ServiceId", "dbo.Services");
            DropIndex("dbo.Requests", new[] { "ServiceId" });
        }
    }
}
