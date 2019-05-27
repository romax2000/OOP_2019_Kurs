namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lonin = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Lonin, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Lonin" });
            DropTable("dbo.Users");
        }
    }
}
