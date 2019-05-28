namespace TFAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Surcharge_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "SurchargeAmount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "SurchargeAmount");
        }
    }
}
