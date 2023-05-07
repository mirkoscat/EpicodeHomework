namespace PizzeriaWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(maxLength: 50),
                        AdditionalNote = c.String(maxLength: 200),
                        Evaso = c.Boolean(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProductInCarts", "Order_Id", c => c.Int());
            CreateIndex("dbo.ProductInCarts", "Order_Id");
            AddForeignKey("dbo.ProductInCarts", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductInCarts", "Order_Id", "dbo.Orders");
            DropIndex("dbo.ProductInCarts", new[] { "Order_Id" });
            DropColumn("dbo.ProductInCarts", "Order_Id");
            DropTable("dbo.Orders");
        }
    }
}
