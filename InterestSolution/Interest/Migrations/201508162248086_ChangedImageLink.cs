namespace Interest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedImageLink : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pins", "ImageLink");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pins", "ImageLink", c => c.String());
        }
    }
}
