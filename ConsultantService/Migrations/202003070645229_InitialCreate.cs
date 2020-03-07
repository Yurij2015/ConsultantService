namespace ConsultantService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consultation",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Consultation");
        }
    }
}
