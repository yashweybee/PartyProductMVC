namespace PartyProductMVC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EditPartyModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parties", "PartyName", c => c.String(nullable: false, maxLength: 255));
        }

        public override void Down()
        {
            AlterColumn("dbo.Parties", "PartyName", c => c.String());
        }
    }
}
