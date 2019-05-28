namespace TFAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Surcharge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Currencies", "Surcharge", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Currencies", "Surcharge");
        }
    }
}
