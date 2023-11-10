namespace PartyProductMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvoiceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        PartyId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        RateOfProduct = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Parties", t => t.PartyId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.PartyId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Invoices", "PartyId", "dbo.Parties");
            DropIndex("dbo.Invoices", new[] { "ProductId" });
            DropIndex("dbo.Invoices", new[] { "PartyId" });
            DropTable("dbo.Invoices");
        }
    }
}
