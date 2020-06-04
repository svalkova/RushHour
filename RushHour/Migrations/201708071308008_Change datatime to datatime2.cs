namespace RushHour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedatatimetodatatime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "StartDateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Appointments", "EndDateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "EndDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Appointments", "StartDateTime", c => c.DateTime(nullable: false));
        }
    }
}
