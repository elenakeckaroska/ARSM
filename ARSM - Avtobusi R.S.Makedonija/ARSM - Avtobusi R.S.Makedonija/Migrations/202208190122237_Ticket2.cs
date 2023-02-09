namespace ARSM___Avtobusi_R.S.Makedonija.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ticket2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        RouteId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .Index(t => t.RouteId)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.Tickets", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Tickets", new[] { "CompanyId" });
            DropIndex("dbo.Tickets", new[] { "RouteId" });
            DropTable("dbo.Tickets");
        }
    }
}
