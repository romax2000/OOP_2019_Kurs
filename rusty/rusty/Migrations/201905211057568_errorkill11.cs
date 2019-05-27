namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class errorkill11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(),
                        Cost = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceId);
            
            AddColumn("dbo.Requests", "ServiceId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "ServiceId");
            DropTable("dbo.Services");
        }
    }
}
