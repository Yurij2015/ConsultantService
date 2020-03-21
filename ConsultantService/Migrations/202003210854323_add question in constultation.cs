namespace ConsultantService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addquestioninconstultation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consultations", "Question", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Consultations", "Question");
        }
    }
}
