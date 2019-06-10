namespace Ecommerce_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.produto", "nome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.produto", "nome");
        }
    }
}
