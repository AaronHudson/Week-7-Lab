namespace Interest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pins", "ImageLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pins", "ImageLink");
        }
    }
}
