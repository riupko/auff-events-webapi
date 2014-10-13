namespace AuffEventsApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuffEventsApi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AuffEventsApi.Models.ApplicationDbContext context)
        {
            context.Users.AddOrUpdate(u => u.Id,
                new Models.ApplicationUser()
                {
                    Id = "6433339c-8c6d-4bfc-95a8-8d9373e58003",
                    Email = "riupko@outlook.com",
                    EmailConfirmed = true,
                    UserName = "riupko@outlook.com",
                    PasswordHash = "AEt5P6+d2tz2zRGhg4wPj4vwV6Cn5IJuZSURaSd8ba9njQqD47L+cobVBCmxkb8GXw==", //Password@1
                    SecurityStamp = "6cb1698b-8f16-4e82-a3f0-4f4bd8702ee9"
                });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
