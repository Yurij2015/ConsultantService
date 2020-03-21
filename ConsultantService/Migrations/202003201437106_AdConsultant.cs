namespace ConsultantService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdConsultant : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consultants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        Portfolio = c.String(),
                        Services = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Consultants");
        }
    }
}
