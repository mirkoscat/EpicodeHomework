namespace PizzeriaWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductInCarts", "IdProdotto");
            DropColumn("dbo.ProductInCarts", "IdCarrello");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductInCarts", "IdCarrello", c => c.Int(nullable: false));
            AddColumn("dbo.ProductInCarts", "IdProdotto", c => c.Int(nullable: false));
        }
    }
}
