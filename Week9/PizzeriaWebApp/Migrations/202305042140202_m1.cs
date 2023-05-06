namespace PizzeriaWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Orders", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Ingredients", new[] { "Product_Id" });
            DropIndex("dbo.Orders", new[] { "Cart_Id" });
            CreateTable(
                "dbo.IngredientProducts",
                c => new
                    {
                        Ingredient_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ingredient_Id, t.Product_Id })
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Ingredient_Id)
                .Index(t => t.Product_Id);
            
            AddColumn("dbo.ProductInCarts", "Order_Id", c => c.Int());
            CreateIndex("dbo.ProductInCarts", "Order_Id");
            AddForeignKey("dbo.ProductInCarts", "Order_Id", "dbo.Orders", "Id");
            DropColumn("dbo.Ingredients", "Product_Id");
            DropColumn("dbo.Orders", "Cart_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Cart_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Ingredients", "Product_Id", c => c.Int());
            DropForeignKey("dbo.ProductInCarts", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.IngredientProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.IngredientProducts", "Ingredient_Id", "dbo.Ingredients");
            DropIndex("dbo.IngredientProducts", new[] { "Product_Id" });
            DropIndex("dbo.IngredientProducts", new[] { "Ingredient_Id" });
            DropIndex("dbo.ProductInCarts", new[] { "Order_Id" });
            DropColumn("dbo.ProductInCarts", "Order_Id");
            DropTable("dbo.IngredientProducts");
            CreateIndex("dbo.Orders", "Cart_Id");
            CreateIndex("dbo.Ingredients", "Product_Id");
            AddForeignKey("dbo.Orders", "Cart_Id", "dbo.Carts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Ingredients", "Product_Id", "dbo.Products", "Id");
        }
    }
}
