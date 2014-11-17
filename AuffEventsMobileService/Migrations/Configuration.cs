namespace AuffEventsMobileService.Migrations
{
    using AuffEventsMobileService.DataObjects;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuffEventsMobileService.Models.MobileServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AuffEventsMobileService.Models.MobileServiceContext context)
        {
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

            SeedThis(context);
        }

        private void SeedThis(Models.MobileServiceContext context)
        {
            if (context.TodoItems.Count() > 0)
                return;

            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = "1", Text = "First item", Complete = false },
                new TodoItem { Id = "2", Text = "Second item", Complete = false },
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            List<Team> teams = new List<Team>
            {
                new Team { Id = "1", Name = "KFC", Description = "Kyiv Floorball Club", DateBirth= new DateTime(2007, 1, 1) },
                new Team { Id = "2", Name = "Скала", Description = "Скала бла бла бла", DateBirth= new DateTime(2004, 1, 1) }
            };

            List<TeamMember> teamMembers = new List<TeamMember>
            {
                  new TeamMember {
                                                Id = "1",
                                                FirstName = "PlayerFirstName",
                                                LastName = "PlayerLastName",
                                                Patronymic= "PlayerPatronimic",
                                                DateBirth = new DateTime(1988,1,1),
                                                Number = 2,
                                                TeamId = "1"
                                            },
                                             new TeamMember {
                                                Id = "2",
                                                FirstName = "PlayerFirstName",
                                                LastName = "PlayerLastName",
                                                Patronymic= "PlayerPatronimic",
                                                DateBirth = new DateTime(1987,1,1),
                                                Number = 2,
                                                TeamId = "2"
                                            }

            };

            List<Event> events = new List<Event>
            {
                new Event 
                { 
                    Id = "1", 
                    Name = "Чемпионат Украины 1 тур", 
                    Description = "", 
                    DateStart = new DateTime(2014, 11, 28),
                    DateEnd = new DateTime(2014, 11, 30),
                    DateEntryStop = new DateTime(2014, 11, 21),
                    IsPublished = true,
                }
            };

            List<EntryForm> forms = new List<EntryForm>()
            {
                new EntryForm { Id = "1", EventId = "1", TeamId = "1", IsApproved = true },
                new EntryForm { Id = "2", EventId = "1", TeamId = "2", IsApproved = false }
            };

            foreach (Team @team in teams)
            {
                context.Set<Team>().Add(@team);
            }

            foreach (TeamMember @teamMember in teamMembers)
            {
                context.Set<TeamMember>().Add(@teamMember);
            }

            foreach (Event @event in events)
            {
                context.Set<Event>().Add(@event);
            }

            foreach (EntryForm @form in forms)
            {
                context.Set<EntryForm>().Add(@form);
            }
        }
    }
}
