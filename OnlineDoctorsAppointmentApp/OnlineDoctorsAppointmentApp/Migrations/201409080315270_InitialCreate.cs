namespace OnlineDoctorsAppointmentApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        ChamberId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        VisitingSessionId = c.Int(nullable: false),
                        PatientName = c.String(nullable: false),
                        Problems = c.String(),
                        PatientPhone = c.String(nullable: false),
                        PatientEmail = c.String(),
                        PatientAddress = c.String(),
                        AppointmentTime = c.DateTime(nullable: false),
                        IsNotificationSubscribed = c.Boolean(nullable: false),
                        IsAppointmentConfirm = c.Boolean(nullable: false),
                        IsAppointmentComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentId);
            
            CreateTable(
                "dbo.Chambers",
                c => new
                    {
                        ChamberId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Zone = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ChamberId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ImagePath = c.String(),
                        Degree = c.String(),
                        Specialization = c.String(nullable: false),
                        Email = c.String(),
                        Phone = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Fee = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorId);
            
            CreateTable(
                "dbo.LoginInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RememberMe = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VisitingSessions",
                c => new
                    {
                        VisitingSessionId = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        ChamberId = c.Int(nullable: false),
                        AppointmentId = c.Int(nullable: false),
                        MaxNoOfAppointments = c.Int(nullable: false),
                        TotalNoOfAppointments = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VisitingSessionId)
                .ForeignKey("dbo.Chambers", t => t.ChamberId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.ChamberId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VisitingSessions", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.VisitingSessions", "ChamberId", "dbo.Chambers");
            DropIndex("dbo.VisitingSessions", new[] { "DoctorId" });
            DropIndex("dbo.VisitingSessions", new[] { "ChamberId" });
            DropTable("dbo.VisitingSessions");
            DropTable("dbo.LoginInfoes");
            DropTable("dbo.Doctors");
            DropTable("dbo.Chambers");
            DropTable("dbo.Appointments");
        }
    }
}
