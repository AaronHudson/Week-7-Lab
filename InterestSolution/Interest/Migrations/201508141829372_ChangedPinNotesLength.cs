namespace Interest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPinNotesLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pins", "Notes", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pins", "Notes", c => c.String(maxLength: 1000));
        }
    }
}
