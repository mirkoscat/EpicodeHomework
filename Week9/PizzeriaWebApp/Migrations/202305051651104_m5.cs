namespace PizzeriaWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Ordine_Id", "dbo.Orders");
            DropIndex("dbo.Carts", new[] { "Ordine_Id" });
            AddColumn("dbo.Carts", "IsEvaso", c => c.Boolean(nullable: false));
            AddColumn("dbo.Carts", "DataOrdine", c => c.DateTime(nullable: false));
            AddColumn("dbo.Carts", "Address", c => c.String());
            AddColumn("dbo.Carts", "AdditionalNote", c => c.String());
            DropColumn("dbo.Carts", "Ordine_Id");
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 50),
                        AdditionalNote = c.String(maxLength: 200),
                        Evaso = c.Boolean(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Carts", "Ordine_Id", c => c.Int());
            DropColumn("dbo.Carts", "AdditionalNote");
            DropColumn("dbo.Carts", "Address");
            DropColumn("dbo.Carts", "DataOrdine");
            DropColumn("dbo.Carts", "IsEvaso");
            CreateIndex("dbo.Carts", "Ordine_Id");
            AddForeignKey("dbo.Carts", "Ordine_Id", "dbo.Orders", "Id");
        }
    }
}
