namespace AuffEventsMobileService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamMember_Required : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeamMembers", "MemberId", "dbo.Members");
            DropForeignKey("dbo.TeamMembers", "TeamRoleId", "dbo.TeamRoles");
            DropIndex("dbo.TeamMembers", new[] { "TeamRoleId" });
            DropIndex("dbo.TeamMembers", new[] { "MemberId" });
            AlterColumn("dbo.TeamMembers", "TeamRoleId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TeamMembers", "MemberId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.TeamMembers", "TeamRoleId");
            CreateIndex("dbo.TeamMembers", "MemberId");
            AddForeignKey("dbo.TeamMembers", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TeamMembers", "TeamRoleId", "dbo.TeamRoles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamMembers", "TeamRoleId", "dbo.TeamRoles");
            DropForeignKey("dbo.TeamMembers", "MemberId", "dbo.Members");
            DropIndex("dbo.TeamMembers", new[] { "MemberId" });
            DropIndex("dbo.TeamMembers", new[] { "TeamRoleId" });
            AlterColumn("dbo.TeamMembers", "MemberId", c => c.String(maxLength: 128));
            AlterColumn("dbo.TeamMembers", "TeamRoleId", c => c.String(maxLength: 128));
            CreateIndex("dbo.TeamMembers", "MemberId");
            CreateIndex("dbo.TeamMembers", "TeamRoleId");
            AddForeignKey("dbo.TeamMembers", "TeamRoleId", "dbo.TeamRoles", "Id");
            AddForeignKey("dbo.TeamMembers", "MemberId", "dbo.Members", "Id");
        }
    }
}
