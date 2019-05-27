namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Car : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        CarMark = c.String(),
                        CarModel = c.String(),
                        Year = c.Int(nullable: false),
                        Engine = c.String(),
                        Body = c.String(),
                        Color = c.String(),
                        RegNummber = c.String(),
                    })
                .PrimaryKey(t => t.CarId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cars");
        }
    }
}
