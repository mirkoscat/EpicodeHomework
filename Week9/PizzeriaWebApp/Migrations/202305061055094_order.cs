namespace PizzeriaWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carts", "IsOpen");
            DropColumn("dbo.Carts", "DataApertura");
            DropColumn("dbo.Carts", "IsEvaso");
            DropColumn("dbo.Carts", "DataOrdine");
            DropColumn("dbo.Carts", "Address");
            DropColumn("dbo.Carts", "AdditionalNote");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "AdditionalNote", c => c.String());
            AddColumn("dbo.Carts", "Address", c => c.String());
            AddColumn("dbo.Carts", "DataOrdine", c => c.DateTime(nullable: false));
            AddColumn("dbo.Carts", "IsEvaso", c => c.Boolean(nullable: false));
            AddColumn("dbo.Carts", "DataApertura", c => c.DateTime(nullable: false));
            AddColumn("dbo.Carts", "IsOpen", c => c.Boolean(nullable: false));
        }
    }
}
