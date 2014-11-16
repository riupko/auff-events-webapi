namespace AuffEventsMobileService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Required : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EntryForms", "EventId", "dbo.Events");
            DropForeignKey("dbo.EntryForms", "TeamId", "dbo.Teams");
            DropIndex("dbo.EntryForms", new[] { "EventId" });
            DropIndex("dbo.EntryForms", new[] { "TeamId" });
            AlterColumn("dbo.EntryForms", "EventId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EntryForms", "TeamId", c => c.String(nullable: false, maxLength: 128));
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
            AlterColumn("dbo.EntryForms", "TeamId", c => c.String(maxLength: 128));
            AlterColumn("dbo.EntryForms", "EventId", c => c.String(maxLength: 128));
            CreateIndex("dbo.EntryForms", "TeamId");
            CreateIndex("dbo.EntryForms", "EventId");
            AddForeignKey("dbo.EntryForms", "TeamId", "dbo.Teams", "Id");
            AddForeignKey("dbo.EntryForms", "EventId", "dbo.Events", "Id");
        }
    }
}
