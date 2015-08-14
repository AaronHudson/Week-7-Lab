namespace Interest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NothingHasChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pins", "Notes", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pins", "Notes", c => c.String(maxLength: 50));
        }
    }
}
