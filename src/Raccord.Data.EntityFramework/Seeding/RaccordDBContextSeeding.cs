using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.SceneProperties;
using Raccord.Domain.Model.Locations;
using Raccord.Domain.Model.Scenes;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Breakdowns.BreakdownTypes;

namespace Raccord.Data.EntityFramework.Seeding
{
    public static class RaccordDBContextSeeding
    {
        public static void EnsureSeedData(this RaccordDBContext context)
        {
            context.SystemSeeding();
            context.TestSeeding();
        }

        public static void SystemSeeding(this RaccordDBContext context)
        {

        }

        public static void SeedBreakdownTypes(this RaccordDBContext context)
        {
            if(!context.BreakdownTypeDefinitions.Any())
            {
                var definitions = new List<BreakdownTypeDefinition>
                {
                    new BreakdownTypeDefinition{ Name = "Costume" },
                    new BreakdownTypeDefinition{ Name = "Hair / Make Up" },
                    new BreakdownTypeDefinition{ Name = "Props" },
                    new BreakdownTypeDefinition{ Name = "Vehicles" },
                };

                context.BreakdownTypeDefinitions.AddRange(definitions);

                context.SaveChanges();
            }
        }

        public static void TestSeeding(this RaccordDBContext context)
        {
            context.SeedProjects();
            context.SeedIntExts();
            context.SeedDayNights();
            context.SeedLocations();
            context.SeedScenes();
        }

        public static void SeedProjects(this RaccordDBContext context)
        {
            if(!context.Projects.Any())
            {
                var projects = new List<Project>
                {
                    new Project { Title = "The Dying Dead" },
                    new Project { Title = "Hitler Needs Woman" },
                    new Project { Title = "It Came From the Planet" },
                    new Project { Title = "Color Me Crazy" },
                    new Project { Title = "Monstro!" },
                };

                context.Projects.AddRange(projects);

                context.SaveChanges();
            }
        }

        public static void SeedIntExts(this RaccordDBContext context)
        {
            if(!context.IntExts.Any())
            {
                var entities = new List<IntExt>
                {
                    new IntExt { ProjectID = 1, Name = "INT" },
                    new IntExt { ProjectID = 1, Name = "EXT" },
                    new IntExt { ProjectID = 2, Name = "INT" },
                    new IntExt { ProjectID = 2, Name = "EXT" },
                };

                context.IntExts.AddRange(entities);

                context.SaveChanges();
            }
        }

        public static void SeedDayNights(this RaccordDBContext context)
        {
            if(!context.DayNights.Any())
            {
                var entities = new List<DayNight>
                {
                    new DayNight { ProjectID = 1, Name = "DAY" },
                    new DayNight { ProjectID = 1, Name = "NIGHT" },
                    new DayNight { ProjectID = 2, Name = "DAY" },
                    new DayNight { ProjectID = 2, Name = "NIGHT" },
                };

                context.DayNights.AddRange(entities);

                context.SaveChanges();
            }
        }

        public static void SeedLocations(this RaccordDBContext context)
        {
            if(!context.Locations.Any())
            {
                var entities = new List<Location>
                {
                    new Location { ProjectID = 1, Name = "HOUSE" },
                    new Location { ProjectID = 1, Name = "HOUSE - KITCHEN" },
                    new Location { ProjectID = 1, Name = "HOUSE - LIVING ROOM" },
                    new Location { ProjectID = 1, Name = "STREET" },
                    new Location { ProjectID = 1, Name = "PARK" },

                    new Location { ProjectID = 2, Name = "FOREST" },
                    new Location { ProjectID = 2, Name = "COTTAGE" },
                    new Location { ProjectID = 2, Name = "MEADOW" },
                    new Location { ProjectID = 2, Name = "RIVER" },
                };

                context.Locations.AddRange(entities);

                context.SaveChanges();
            }
        }

        public static void SeedScenes(this RaccordDBContext context)
        {
            if(!context.Scenes.Any())
            {
                var entities = new List<Scene>
                {
                    new Scene { ProjectID = 1, IntExtID = 2, LocationID = 1, DayNightID = 1, PageLength = 1, Number = "1", Summary = "Establishing shot" },
                    new Scene { ProjectID = 1, IntExtID = 1, LocationID = 2, DayNightID = 1, PageLength = 9, Number = "2", Summary = "Janice gets ready to go out." },
                    new Scene { ProjectID = 1, IntExtID = 1, LocationID = 3, DayNightID = 1, PageLength = 2, Number = "2A", Summary = "Janice picks up her lunch." },
                    new Scene { ProjectID = 1, IntExtID = 2, LocationID = 5, DayNightID = 2, PageLength = 8, Number = "3", Summary = "Janice goes home through the park." },

                    new Scene { ProjectID = 2, IntExtID = 3, LocationID = 6, DayNightID = 4, PageLength = 2, Number = "1", Summary = "A dark forest" },                    
                    new Scene { ProjectID = 2, IntExtID = 4, LocationID = 7, DayNightID = 4, PageLength = 10, Number = "2", Summary = "Freddy in his little cottage" },                    
                    new Scene { ProjectID = 2, IntExtID = 3, LocationID = 6, DayNightID = 4, PageLength = 6, Number = "3", Summary = "Freddy goes for a walk in the forest" },                    
                    new Scene { ProjectID = 2, IntExtID = 3, LocationID = 8, DayNightID = 3, PageLength = 2, Number = "4", Summary = "Freddy walks through a meadow" },                    
                    new Scene { ProjectID = 2, IntExtID = 3, LocationID = 9, DayNightID = 3, PageLength = 3, Number = "5", Summary = "Freddy takes a bath in a river" },                    
                };

                context.Scenes.AddRange(entities);

                context.SaveChanges();
            }
        }
    }
}