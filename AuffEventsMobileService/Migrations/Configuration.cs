namespace AuffEventsMobileService.Migrations
{
    using AuffEventsMobileService.DataObjects;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DtoMember = AuffEventsMobileService.DataObjects.Member;

    internal sealed class Configuration : DbMigrationsConfiguration<AuffEventsMobileService.Models.MobileServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
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

            if (context.Members.Count() == 0)
            {
                List<DtoMember> members = new List<DtoMember>
                {
                    new DtoMember { Id = "1", FirstName = "FirstName1", LastName = "LastName1", Patronymic = "Patronimic1", DateBirth = new DateTime(1987, 1, 1), Height = 187, Grip = 1 },
                    new DtoMember { Id = "2", FirstName = "FirstName2", LastName = "LastName2", Patronymic = "Patronimic2", DateBirth = new DateTime(1988, 1, 1), Height = 177, Grip = 2 },
                };

                foreach (DtoMember @member in members)
                {
                    context.Set<DtoMember>().Add(@member);
                }

                var teamMembers = context.TeamMembers.Where(m => m.MemberId == null);
                foreach (var tm in  teamMembers)
                {
                    tm.MemberId = "1";
                }
            }

            if (context.TeamRoles.Count() == 0)
            {
                List<TeamRole> teamRoles = new List<TeamRole>
                {
                    new TeamRole{ Id = "1", Name = "Coach" },
                    new TeamRole{ Id = "2", Name = "Goalkeeper" },
                    new TeamRole{ Id = "3", Name = "Defender" },
                    new TeamRole{ Id = "4", Name = "Forward" },
                };

                foreach (TeamRole @teamRole in teamRoles)
                {
                    context.Set<TeamRole>().Add(@teamRole);
                }

                var teamMembers = context.TeamMembers.Where(m => m.TeamRoleId == null);
                foreach (var tm in teamMembers)
                {
                    tm.TeamRoleId = "4";
                }
            }

            if (context.TeamMembers.Count() == 0)
            {
                List<TeamMember> teamMembers = new List<TeamMember>
                {
                      new TeamMember {
                                                    Id = "1",
                                                    Number = 2,
                                                    TeamId = "1",
                                                    TeamRoleId = "3",
                                                    MemberId = "1"
                                                },
                                                 new TeamMember {
                                                    Id = "2",
                                                    Number = 2,
                                                    TeamId = "1",
                                                    TeamRoleId = "4",
                                                    MemberId = "2"
                                                }

                };

                foreach (TeamMember @teamMember in teamMembers)
                {
                    context.Set<TeamMember>().Add(@teamMember);
                }
            }

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
                                                Number = 2,
                                                TeamId = "1",
                                                TeamRoleId = "3",
                                                MemberId = "1"
                                            },
                                             new TeamMember {
                                                Id = "2",
                                                Number = 2,
                                                TeamId = "1",
                                                TeamRoleId = "4",
                                                MemberId = "2"
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
