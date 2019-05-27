namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ShipperId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ShipperId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shippers");
        }
    }
}
