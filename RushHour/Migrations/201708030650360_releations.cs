namespace RushHour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class releations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppointmentActivities",
                c => new
                    {
                        Appointment_Id = c.Int(nullable: false),
                        Activity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Appointment_Id, t.Activity_Id })
                .ForeignKey("dbo.Appointments", t => t.Appointment_Id, cascadeDelete: true)
                .ForeignKey("dbo.Activities", t => t.Activity_Id, cascadeDelete: true)
                .Index(t => t.Appointment_Id)
                .Index(t => t.Activity_Id);
            
            CreateIndex("dbo.Appointments", "UserId");
            AddForeignKey("dbo.Appointments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "UserId", "dbo.Users");
            DropForeignKey("dbo.AppointmentActivities", "Activity_Id", "dbo.Activities");
            DropForeignKey("dbo.AppointmentActivities", "Appointment_Id", "dbo.Appointments");
            DropIndex("dbo.AppointmentActivities", new[] { "Activity_Id" });
            DropIndex("dbo.AppointmentActivities", new[] { "Appointment_Id" });
            DropIndex("dbo.Appointments", new[] { "UserId" });
            DropTable("dbo.AppointmentActivities");
        }
    }
}
