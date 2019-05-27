namespace rusty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustReq : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        CustomId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        Specification = c.String(),
                        Imagie = c.String(),
                        StorageId = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.RequestId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        FIO = c.String(),
                        Phone = c.String(),
                        Adres = c.String(),
                        Person = c.String(),
                        Request_RequestId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Requests", t => t.Request_RequestId)
                .Index(t => t.Request_RequestId);
            
            AddColumn("dbo.Cars", "Request_RequestId", c => c.Int());
            AddColumn("dbo.Storages", "Request_RequestId", c => c.Int());
            CreateIndex("dbo.Cars", "Request_RequestId");
            CreateIndex("dbo.Storages", "Request_RequestId");
            AddForeignKey("dbo.Cars", "Request_RequestId", "dbo.Requests", "RequestId");
            AddForeignKey("dbo.Storages", "Request_RequestId", "dbo.Requests", "RequestId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Storages", "Request_RequestId", "dbo.Requests");
            DropForeignKey("dbo.Customers", "Request_RequestId", "dbo.Requests");
            DropForeignKey("dbo.Cars", "Request_RequestId", "dbo.Requests");
            DropIndex("dbo.Storages", new[] { "Request_RequestId" });
            DropIndex("dbo.Customers", new[] { "Request_RequestId" });
            DropIndex("dbo.Cars", new[] { "Request_RequestId" });
            DropColumn("dbo.Storages", "Request_RequestId");
            DropColumn("dbo.Cars", "Request_RequestId");
            DropTable("dbo.Customers");
            DropTable("dbo.Requests");
        }
    }
}
