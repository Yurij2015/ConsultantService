namespace ConsultantService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConsultationMigrationFirst : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Consultation", newName: "Consultations");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Consultations", newName: "Consultation");
        }
    }
}
