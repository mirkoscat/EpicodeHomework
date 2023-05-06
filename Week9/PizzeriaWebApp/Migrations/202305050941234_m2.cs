namespace PizzeriaWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductInCarts", "Order_Id", "dbo.Orders");
            DropIndex("dbo.ProductInCarts", new[] { "Order_Id" });
            AddColumn("dbo.Carts", "IsOpen", c => c.Boolean(nullable: false));
            AddColumn("dbo.Carts", "DataApertura", c => c.DateTime(nullable: false));
            AddColumn("dbo.Carts", "Ordine_Id", c => c.Int());
            AddColumn("dbo.ProductInCarts", "IdProdotto", c => c.Int(nullable: false));
            AddColumn("dbo.ProductInCarts", "IdCarrello", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "Ordine_Id");
            AddForeignKey("dbo.Carts", "Ordine_Id", "dbo.Orders", "Id");
            DropColumn("dbo.Carts", "TotalPrice");
            DropColumn("dbo.Carts", "Username");
            DropColumn("dbo.ProductInCarts", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductInCarts", "Order_Id", c => c.Int());
            AddColumn("dbo.Carts", "Username", c => c.String(nullable: false));
            AddColumn("dbo.Carts", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Carts", "Ordine_Id", "dbo.Orders");
            DropIndex("dbo.Carts", new[] { "Ordine_Id" });
            DropColumn("dbo.ProductInCarts", "IdCarrello");
            DropColumn("dbo.ProductInCarts", "IdProdotto");
            DropColumn("dbo.Carts", "Ordine_Id");
            DropColumn("dbo.Carts", "DataApertura");
            DropColumn("dbo.Carts", "IsOpen");
            CreateIndex("dbo.ProductInCarts", "Order_Id");
            AddForeignKey("dbo.ProductInCarts", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
