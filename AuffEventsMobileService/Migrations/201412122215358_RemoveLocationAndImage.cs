namespace AuffEventsMobileService.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveLocationAndImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Country", c => c.String());
            AddColumn("dbo.Events", "City", c => c.String());
            AddColumn("dbo.Events", "Address", c => c.String());
            AddColumn("dbo.Events", "ImageUrl", c => c.String());
            AddColumn("dbo.Teams", "Country", c => c.String());
            AddColumn("dbo.Teams", "City", c => c.String());
            AddColumn("dbo.Teams", "Address", c => c.String());
            AddColumn("dbo.Teams", "ImageUrl", c => c.String());
            AddColumn("dbo.Members", "ImageUrl", c => c.String());
            Sql(@"UPDATE [dbo].[Events]
                   SET [Country] = L.[Country]
                      ,[City] = L.[City]
                      ,[Address] = L.[Address]
                   FROM dbo.[Locations] as L
                 WHERE [dbo].[Events].LocationId = L.Id
                UPDATE [dbo].[Teams]
                   SET [Country] = L.[Country]
                      ,[City] = L.[City]
                      ,[Address] = L.[Address]
                   FROM dbo.[Locations] as L
                 WHERE [dbo].[Teams].LocationId = L.Id");
            DropForeignKey("dbo.Events", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Events", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Teams", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Teams", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Members", "ImageId", "dbo.Images");
            DropIndex("dbo.Events", new[] { "LocationId" });
            DropIndex("dbo.Events", new[] { "ImageId" });
            DropIndex("dbo.Teams", new[] { "LocationId" });
            DropIndex("dbo.Teams", new[] { "ImageId" });
            DropIndex("dbo.Members", new[] { "ImageId" });
            DropColumn("dbo.Events", "LocationId");
            DropColumn("dbo.Events", "ImageId");
            DropColumn("dbo.Teams", "LocationId");
            DropColumn("dbo.Teams", "ImageId");
            DropColumn("dbo.Members", "ImageId");
            DropTable("dbo.Images",
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
            DropTable("dbo.Locations",
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
        
        public override void Down()
        {
            CreateTable(
                "dbo.Locations",
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
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7,
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
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
                        BlobUrl = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Version")
                                },
                            }),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7,
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Members", "ImageId", c => c.String(maxLength: 128));
            AddColumn("dbo.Teams", "ImageId", c => c.String(maxLength: 128));
            AddColumn("dbo.Teams", "LocationId", c => c.String(maxLength: 128));
            AddColumn("dbo.Events", "ImageId", c => c.String(maxLength: 128));
            AddColumn("dbo.Events", "LocationId", c => c.String(maxLength: 128));
            DropColumn("dbo.Members", "ImageUrl");
            DropColumn("dbo.Teams", "ImageUrl");
            DropColumn("dbo.Teams", "Address");
            DropColumn("dbo.Teams", "City");
            DropColumn("dbo.Teams", "Country");
            DropColumn("dbo.Events", "ImageUrl");
            DropColumn("dbo.Events", "Address");
            DropColumn("dbo.Events", "City");
            DropColumn("dbo.Events", "Country");
            CreateIndex("dbo.Members", "ImageId");
            CreateIndex("dbo.Teams", "ImageId");
            CreateIndex("dbo.Teams", "LocationId");
            CreateIndex("dbo.Locations", "CreatedAt", clustered: true);
            CreateIndex("dbo.Images", "CreatedAt", clustered: true);
            CreateIndex("dbo.Events", "ImageId");
            CreateIndex("dbo.Events", "LocationId");
            AddForeignKey("dbo.Members", "ImageId", "dbo.Images", "Id");
            AddForeignKey("dbo.Teams", "LocationId", "dbo.Locations", "Id");
            AddForeignKey("dbo.Teams", "ImageId", "dbo.Images", "Id");
            AddForeignKey("dbo.Events", "LocationId", "dbo.Locations", "Id");
            AddForeignKey("dbo.Events", "ImageId", "dbo.Images", "Id");
        }
    }
}
