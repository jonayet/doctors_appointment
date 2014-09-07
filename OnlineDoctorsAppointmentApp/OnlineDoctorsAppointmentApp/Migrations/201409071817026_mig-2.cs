namespace OnlineDoctorsAppointmentApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisitingSessions", "TotalNoOfAppointments", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VisitingSessions", "TotalNoOfAppointments");
        }
    }
}
