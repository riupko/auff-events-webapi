namespace AuffEventsMobileService.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Member : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeamMembers", "ImageId", "dbo.Images");
            DropIndex("dbo.TeamMembers", new[] { "ImageId" });
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Id")
                                },
                            }),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Patronymic = c.String(nullable: false, maxLength: 50),
                        Height = c.Int(nullable: false),
                        Grip = c.Int(nullable: false),
                        DateBirth = c.DateTime(nullable: false),
                        ImageId = c.String(maxLength: 128),
                        OriginalTeam = c.String(maxLength: 128),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Version")
                                },
                            }),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7, defaultValue: DateTimeOffset.UtcNow,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "CreatedAt")
                                },
                            }),
                        UpdatedAt = c.DateTimeOffset(precision: 7,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "UpdatedAt")
                                },
                            }),
                        Deleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Deleted")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id, clustered: false)
                .ForeignKey("dbo.Images", t => t.ImageId)
                .Index(t => t.ImageId)
                .Index(t => t.CreatedAt, clustered: true);
            
            CreateTable(
                "dbo.TeamRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Id")
                                },
                            }),
                        Name = c.String(nullable: false),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Version")
                                },
                            }),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7, defaultValue: DateTimeOffset.UtcNow,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "CreatedAt")
                                },
                            }),
                        UpdatedAt = c.DateTimeOffset(precision: 7,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "UpdatedAt")
                                },
                            }),
                        Deleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Deleted")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id, clustered: false)
                .Index(t => t.CreatedAt, clustered: true);
            
            AddColumn("dbo.TeamMembers", "TeamRoleId", c => c.String(maxLength: 128));
            AddColumn("dbo.TeamMembers", "MemberId", c => c.String(maxLength: 128));
            CreateIndex("dbo.TeamMembers", "TeamRoleId");
            CreateIndex("dbo.TeamMembers", "MemberId");
            AddForeignKey("dbo.TeamMembers", "MemberId", "dbo.Members", "Id");
            AddForeignKey("dbo.TeamMembers", "TeamRoleId", "dbo.TeamRoles", "Id");
            DropColumn("dbo.TeamMembers", "FirstName");
            DropColumn("dbo.TeamMembers", "LastName");
            DropColumn("dbo.TeamMembers", "Patronymic");
            DropColumn("dbo.TeamMembers", "DateBirth");
            DropColumn("dbo.TeamMembers", "ImageId");
            DropColumn("dbo.TeamMembers", "OriginalTeam");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TeamMembers", "OriginalTeam", c => c.String(maxLength: 128));
            AddColumn("dbo.TeamMembers", "ImageId", c => c.String(maxLength: 128));
            AddColumn("dbo.TeamMembers", "DateBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.TeamMembers", "Patronymic", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.TeamMembers", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.TeamMembers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.TeamMembers", "TeamRoleId", "dbo.TeamRoles");
            DropForeignKey("dbo.TeamMembers", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Members", "ImageId", "dbo.Images");
            DropIndex("dbo.TeamRoles", new[] { "CreatedAt" });
            DropIndex("dbo.Members", new[] { "CreatedAt" });
            DropIndex("dbo.Members", new[] { "ImageId" });
            DropIndex("dbo.TeamMembers", new[] { "MemberId" });
            DropIndex("dbo.TeamMembers", new[] { "TeamRoleId" });
            DropColumn("dbo.TeamMembers", "MemberId");
            DropColumn("dbo.TeamMembers", "TeamRoleId");
            DropTable("dbo.TeamRoles",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreatedAt",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "CreatedAt" },
                        }
                    },
                    {
                        "Deleted",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Deleted" },
                        }
                    },
                    {
                        "Id",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Id" },
                        }
                    },
                    {
                        "UpdatedAt",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "UpdatedAt" },
                        }
                    },
                    {
                        "Version",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Version" },
                        }
                    },
                });
            DropTable("dbo.Members",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreatedAt",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "CreatedAt" },
                        }
                    },
                    {
                        "Deleted",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Deleted" },
                        }
                    },
                    {
                        "Id",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Id" },
                        }
                    },
                    {
                        "UpdatedAt",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "UpdatedAt" },
                        }
                    },
                    {
                        "Version",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Version" },
                        }
                    },
                });
            CreateIndex("dbo.TeamMembers", "ImageId");
            AddForeignKey("dbo.TeamMembers", "ImageId", "dbo.Images", "Id");
        }
    }
}
