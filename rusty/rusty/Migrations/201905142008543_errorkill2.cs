namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class errorkill2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Supplies", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Supplies", "Cost", c => c.Single(nullable: false));
            DropColumn("dbo.Supplies", "NumberProduct");
            DropColumn("dbo.Supplies", "Cast");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Supplies", "Cast", c => c.Single(nullable: false));
            AddColumn("dbo.Supplies", "NumberProduct", c => c.String());
            DropColumn("dbo.Supplies", "Cost");
            DropColumn("dbo.Supplies", "Number");
        }
    }
}
