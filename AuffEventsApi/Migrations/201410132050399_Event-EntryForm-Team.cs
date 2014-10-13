namespace AuffEventsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventEntryFormTeam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntryForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        DateBirth = c.DateTime(nullable: false),
                        LocationID = c.Int(nullable: false),
                        ManagerID = c.Int(nullable: false),
                        LogoID = c.Int(nullable: false),
                        IsArchived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Events", "Description", c => c.String());
            AddColumn("dbo.Events", "DateStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "DateEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "DateEntryStop", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "LocationID", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "ParentEventID", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "PosterID", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "IsPublished", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "IsPublished");
            DropColumn("dbo.Events", "PosterID");
            DropColumn("dbo.Events", "ParentEventID");
            DropColumn("dbo.Events", "LocationID");
            DropColumn("dbo.Events", "DateEntryStop");
            DropColumn("dbo.Events", "DateEnd");
            DropColumn("dbo.Events", "DateStart");
            DropColumn("dbo.Events", "Description");
            DropTable("dbo.Teams");
            DropTable("dbo.EntryForms");
        }
    }
}
