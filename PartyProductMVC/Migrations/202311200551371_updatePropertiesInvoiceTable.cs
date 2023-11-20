namespace PartyProductMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePropertiesInvoiceTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "PartyId", "dbo.Parties");
            DropForeignKey("dbo.Invoices", "ProductId", "dbo.Products");
            DropIndex("dbo.Invoices", new[] { "PartyId" });
            DropIndex("dbo.Invoices", new[] { "ProductId" });
            AddColumn("dbo.Invoices", "PartyName", c => c.String());
            AddColumn("dbo.Invoices", "ProductName", c => c.String());
            DropColumn("dbo.Invoices", "PartyId");
            DropColumn("dbo.Invoices", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "PartyId", c => c.Int(nullable: false));
            DropColumn("dbo.Invoices", "ProductName");
            DropColumn("dbo.Invoices", "PartyName");
            CreateIndex("dbo.Invoices", "ProductId");
            CreateIndex("dbo.Invoices", "PartyId");
            AddForeignKey("dbo.Invoices", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.Invoices", "PartyId", "dbo.Parties", "PartyId", cascadeDelete: true);
        }
    }
}
