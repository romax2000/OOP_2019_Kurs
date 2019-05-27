namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class errorkill8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Supplies", "ShipperName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Supplies", "ShipperName");
        }
    }
}
