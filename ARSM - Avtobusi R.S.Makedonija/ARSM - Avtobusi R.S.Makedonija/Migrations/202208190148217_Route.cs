namespace ARSM___Avtobusi_R.S.Makedonija.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Route : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Routes", "Company_Id", "dbo.Companies");
            AddColumn("dbo.Companies", "Route_Id", c => c.Int());
            AddColumn("dbo.Routes", "Company_Id1", c => c.Int());
            CreateIndex("dbo.Companies", "Route_Id");
            CreateIndex("dbo.Routes", "Company_Id1");
            AddForeignKey("dbo.Companies", "Route_Id", "dbo.Routes", "Id");
            AddForeignKey("dbo.Routes", "Company_Id1", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routes", "Company_Id1", "dbo.Companies");
            DropForeignKey("dbo.Companies", "Route_Id", "dbo.Routes");
            DropIndex("dbo.Routes", new[] { "Company_Id1" });
            DropIndex("dbo.Companies", new[] { "Route_Id" });
            DropColumn("dbo.Routes", "Company_Id1");
            DropColumn("dbo.Companies", "Route_Id");
            AddForeignKey("dbo.Routes", "Company_Id", "dbo.Companies", "Id");
        }
    }
}
