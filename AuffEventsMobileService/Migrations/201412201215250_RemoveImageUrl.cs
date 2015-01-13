namespace AuffEventsMobileService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveImageUrl : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "ImageUrl");
            DropColumn("dbo.Teams", "ImageUrl");
            DropColumn("dbo.Members", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "ImageUrl", c => c.String());
            AddColumn("dbo.Teams", "ImageUrl", c => c.String());
            AddColumn("dbo.Events", "ImageUrl", c => c.String());
        }
    }
}
