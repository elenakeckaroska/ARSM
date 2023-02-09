namespace ARSM___Avtobusi_R.S.Makedonija.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Logo = c.String(nullable: false),
                        OwnerName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Relation = c.String(nullable: false),
                        TimePlace = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routes", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Routes", new[] { "Company_Id" });
            DropTable("dbo.Routes");
            DropTable("dbo.Companies");
        }
    }
}
