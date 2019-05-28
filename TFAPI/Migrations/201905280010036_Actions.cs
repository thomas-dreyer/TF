namespace TFAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Actions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CurrencyActions", "Key", c => c.String());
            AddColumn("dbo.CurrencyActions", "Value", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CurrencyActions", "Value");
            DropColumn("dbo.CurrencyActions", "Key");
        }
    }
}
