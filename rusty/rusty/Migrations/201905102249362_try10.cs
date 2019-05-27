namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class try10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        MasterId = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                        Specification = c.String(),
                        Status = c.String(),
                        Start = c.DateTime(nullable: false),
                        Finish = c.DateTime(nullable: false),
                        Cast = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Masters", t => t.MasterId, cascadeDelete: true)
                .ForeignKey("dbo.Requests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.MasterId)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.Masters",
                c => new
                    {
                        MasterId = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        FIO = c.String(),
                        Spec = c.String(),
                        Exp = c.Int(nullable: false),
                        Phone = c.String(),
                        WorkplaceId = c.Int(nullable: false),
                        Salary = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MasterId)
                .ForeignKey("dbo.Workplaces", t => t.WorkplaceId, cascadeDelete: true)
                .Index(t => t.WorkplaceId);
            
            CreateTable(
                "dbo.Workplaces",
                c => new
                    {
                        WorkplaceId = c.Int(nullable: false, identity: true),
                        WorkplaceName = c.String(),
                        Specification = c.String(),
                    })
                .PrimaryKey(t => t.WorkplaceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.Masters", "WorkplaceId", "dbo.Workplaces");
            DropForeignKey("dbo.Orders", "MasterId", "dbo.Masters");
            DropIndex("dbo.Masters", new[] { "WorkplaceId" });
            DropIndex("dbo.Orders", new[] { "RequestId" });
            DropIndex("dbo.Orders", new[] { "MasterId" });
            DropTable("dbo.Workplaces");
            DropTable("dbo.Masters");
            DropTable("dbo.Orders");
        }
    }
}
