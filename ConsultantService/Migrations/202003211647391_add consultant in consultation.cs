﻿namespace ConsultantService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addconsultantinconsultation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consultations", "Consultant", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Consultations", "Consultant");
        }
    }
}
