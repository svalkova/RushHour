namespace RushHour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeProperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
