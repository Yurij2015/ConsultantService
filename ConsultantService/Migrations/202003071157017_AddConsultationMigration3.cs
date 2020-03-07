namespace ConsultantService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConsultationMigration3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Consultations");
            AlterColumn("dbo.Consultations", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Consultations", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Consultations", "Email", c => c.String());
            AlterColumn("dbo.Consultations", "Phone", c => c.String());
            AddPrimaryKey("dbo.Consultations", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Consultations");
            AlterColumn("dbo.Consultations", "Phone", c => c.String(maxLength: 20));
            AlterColumn("dbo.Consultations", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.Consultations", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Consultations", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Consultations", "Id");
        }
    }
}
