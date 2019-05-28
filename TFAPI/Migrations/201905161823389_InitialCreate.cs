namespace TFAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CurrencyActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrencyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExchangeRates",
                c => new
                    {
                        LocalCurrency = c.Int(nullable: false),
                        ForeignCurrency = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        UpdateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.LocalCurrency, t.ForeignCurrency });
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocalCurrencyAmount = c.Double(nullable: false),
                        ForeignCurrencyAmount = c.Double(nullable: false),
                        Rate = c.Double(nullable: false),
                        Surcharge = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ForeignCurrency_Id = c.Int(),
                        LocalCurrency_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.ForeignCurrency_Id)
                .ForeignKey("dbo.Currencies", t => t.LocalCurrency_Id)
                .Index(t => t.ForeignCurrency_Id)
                .Index(t => t.LocalCurrency_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "LocalCurrency_Id", "dbo.Currencies");
            DropForeignKey("dbo.Orders", "ForeignCurrency_Id", "dbo.Currencies");
            DropIndex("dbo.Orders", new[] { "LocalCurrency_Id" });
            DropIndex("dbo.Orders", new[] { "ForeignCurrency_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.ExchangeRates");
            DropTable("dbo.CurrencyActions");
            DropTable("dbo.Currencies");
        }
    }
}
