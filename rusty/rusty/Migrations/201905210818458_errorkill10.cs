namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class errorkill10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "ImagieOn", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "ImagieOn");
        }
    }
}
