﻿namespace ARSM___Avtobusi_R.S.Makedonija.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTextRoute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routes", "Text", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Routes", "Text");
        }
    }
}
