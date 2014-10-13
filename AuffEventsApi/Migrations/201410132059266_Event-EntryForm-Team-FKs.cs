namespace AuffEventsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventEntryFormTeamFKs : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.EntryForms", "EventId");
            CreateIndex("dbo.EntryForms", "TeamId");
            AddForeignKey("dbo.EntryForms", "EventId", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EntryForms", "TeamId", "dbo.Teams", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntryForms", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.EntryForms", "EventId", "dbo.Events");
            DropIndex("dbo.EntryForms", new[] { "TeamId" });
            DropIndex("dbo.EntryForms", new[] { "EventId" });
        }
    }
}
