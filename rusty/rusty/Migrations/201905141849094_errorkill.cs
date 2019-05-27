namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class errorkill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Storages", "Cost", c => c.Single(nullable: false));
            DropColumn("dbo.Storages", "Cast");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Storages", "Cast", c => c.Int(nullable: false));
            DropColumn("dbo.Storages", "Cost");
        }
    }
}
