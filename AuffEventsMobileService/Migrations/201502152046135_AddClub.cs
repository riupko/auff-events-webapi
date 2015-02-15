namespace AuffEventsMobileService.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddClub : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clubs",
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
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        DateBirth = c.DateTime(nullable: false),
                        Country = c.String(),
                        City = c.String(),
                        Address = c.String(),
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
            
            CreateTable(
                "dbo.MemberLicenses",
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
                        MemberId = c.String(nullable: false, maxLength: 128),
                        ClubId = c.String(nullable: false, maxLength: 128),
                        LicenseId = c.String(),
                        DateExpired = c.DateTime(nullable: false),
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
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Clubs", t => t.ClubId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.ClubId)
                .Index(t => t.CreatedAt, clustered: true);
            
            CreateTable(
                "dbo.MemberTransfers",
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
                        MemberId = c.String(nullable: false, maxLength: 128),
                        ClubId = c.String(nullable: false, maxLength: 128),
                        DocumentId = c.String(),
                        Date = c.DateTime(nullable: false),
                        Notes = c.String(),
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
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Clubs", t => t.ClubId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.ClubId)
                .Index(t => t.CreatedAt, clustered: true);
            
            AddColumn("dbo.Teams", "ClubId", c => c.String(maxLength: 128));
            AddColumn("dbo.Members", "ClubId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Teams", "ClubId");
            CreateIndex("dbo.Members", "ClubId");
            AddForeignKey("dbo.Teams", "ClubId", "dbo.Clubs", "Id");
            AddForeignKey("dbo.Members", "ClubId", "dbo.Clubs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemberTransfers", "ClubId", "dbo.Clubs");
            DropForeignKey("dbo.MemberTransfers", "MemberId", "dbo.Members");
            DropForeignKey("dbo.MemberLicenses", "ClubId", "dbo.Clubs");
            DropForeignKey("dbo.MemberLicenses", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Members", "ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Teams", "ClubId", "dbo.Clubs");
            DropIndex("dbo.MemberTransfers", new[] { "CreatedAt" });
            DropIndex("dbo.MemberTransfers", new[] { "ClubId" });
            DropIndex("dbo.MemberTransfers", new[] { "MemberId" });
            DropIndex("dbo.MemberLicenses", new[] { "CreatedAt" });
            DropIndex("dbo.MemberLicenses", new[] { "ClubId" });
            DropIndex("dbo.MemberLicenses", new[] { "MemberId" });
            DropIndex("dbo.Members", new[] { "ClubId" });
            DropIndex("dbo.Teams", new[] { "ClubId" });
            DropIndex("dbo.Clubs", new[] { "CreatedAt" });
            DropColumn("dbo.Members", "ClubId");
            DropColumn("dbo.Teams", "ClubId");
            DropTable("dbo.MemberTransfers",
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
            DropTable("dbo.MemberLicenses",
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
            DropTable("dbo.Clubs",
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
        }
    }
}
