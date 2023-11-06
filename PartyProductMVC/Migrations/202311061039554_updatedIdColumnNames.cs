namespace PartyProductMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class updatedIdColumnNames : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Parties");
            DropColumn("dbo.Parties", "Id");
            DropPrimaryKey("dbo.Products");
            DropColumn("dbo.Products", "Id");
            AddColumn("dbo.Parties", "PartyId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Products", "ProductId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Parties", "PartyId");
            AddPrimaryKey("dbo.Products", "ProductId");
        }

        public override void Down()
        {
            AddColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Parties", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Parties");
            DropColumn("dbo.Products", "ProductId");
            DropColumn("dbo.Parties", "PartyId");
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.Parties", "Id");
        }
    }
}
