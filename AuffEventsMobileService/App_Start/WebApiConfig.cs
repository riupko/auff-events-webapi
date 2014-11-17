using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Http;
using AuffEventsMobileService.DataObjects;
using AuffEventsMobileService.Models;
using Microsoft.WindowsAzure.Mobile.Service;
using AuffEventsMobileService.Migrations;
using System.Data.Entity.Migrations;


namespace AuffEventsMobileService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));
            config.SetIsHosted(true);
            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            //config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            //config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            //Database.SetInitializer(new MobileServiceInitializer());
            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
        }
    }

    public class MobileServiceInitializer : DropCreateDatabaseIfModelChanges<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
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

            base.Seed(context);
        }
    }
}

