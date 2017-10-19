using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.SceneProperties;
using Raccord.Domain.Model.ScriptLocations;
using Raccord.Domain.Model.Scenes;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Breakdowns.BreakdownTypes;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using Raccord.Domain.Model.Callsheets.CallTypes;
using Microsoft.EntityFrameworkCore;
using Raccord.Domain.Model.Crew.Departments;

namespace Raccord.Data.EntityFramework.Seeding
{
    public class RaccordDBContextSeeding
    {
        private RaccordDBContext _context;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private const string adminEmail = "rikboeykens@gmail.com";
        private const string adminPassword = "P@ssw0rd!";

        public RaccordDBContextSeeding(
            RaccordDBContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void EnsureSeedData()
        {
            SystemSeeding();
            TestSeeding();
        }

        private void SystemSeeding()
        {
            SeedBreakdownTypeDefinitions();
            SeedCallTypeDefinitions();
            SeedDepartmentDefinitions();
            SeedRolesAndAdminUser();
        }

        private void SeedBreakdownTypeDefinitions()
        {
            if(!_context.BreakdownTypeDefinitions.Any())
            {
                var definitions = new List<BreakdownTypeDefinition>
                {
                    new BreakdownTypeDefinition{ Name = "Costume" },
                    new BreakdownTypeDefinition{ Name = "Hair / Make Up" },
                    new BreakdownTypeDefinition{ Name = "Props" },
                    new BreakdownTypeDefinition{ Name = "Vehicles" },
                };

                _context.BreakdownTypeDefinitions.AddRange(definitions);

                _context.SaveChanges();
            }
        }
        
        public void SeedCallTypeDefinitions()
        {
            if(!_context.CallTypeDefinitions.Any())
            {
                var definitions = new List<CallTypeDefinition>
                {
                    new CallTypeDefinition{ SortingOrder = 1, ShortName = "CO", Name = "Costume" },
                    new CallTypeDefinition{ SortingOrder = 2, ShortName = "MU", Name = "Hair / Make Up" },
                    new CallTypeDefinition{ SortingOrder = 3, ShortName = "S", Name = "Set" },
                };

                _context.CallTypeDefinitions.AddRange(definitions);

                _context.SaveChanges();
            }
        }
        
        public void SeedDepartmentDefinitions()
        {
            if(!_context.CrewDepartmentDefinitions.Any())
            {
                var definitions = new List<CrewDepartmentDefinition>
                {
                    new CrewDepartmentDefinition{ SortingOrder = 1, Name = "Directorial Department" },
                    new CrewDepartmentDefinition{ SortingOrder = 2, Name = "Camera Department" },
                    new CrewDepartmentDefinition{ SortingOrder = 3, Name = "Sound Department" },
                    new CrewDepartmentDefinition{ SortingOrder = 4, Name = "Hair and Make Up Department" },
                    new CrewDepartmentDefinition{ SortingOrder = 5, Name = "Costume Department" },
                };

                _context.CrewDepartmentDefinitions.AddRange(definitions);

                _context.SaveChanges();
            }
        }

        private void SeedRolesAndAdminUser()
        {
            var rolesToAdd = new List<IdentityRole>(){
                new IdentityRole { Name= "admin"},
                new IdentityRole { Name= "user"}
            };
            foreach (var role in rolesToAdd)
            {
                if (!_roleManager.RoleExistsAsync(role.Name).Result)
                {
                     _roleManager.CreateAsync(role).Result.ToString();
                }
            }

            if (!_context.Users.Any())
            {
                _userManager.CreateAsync(new ApplicationUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true }, adminEmail).Result.ToString();
                _userManager.AddToRoleAsync(_userManager.FindByNameAsync(adminEmail).GetAwaiter().GetResult(), "admin").Result.ToString();
            }
        }
        private void TestSeeding()
        {
            SeedProjects();
            SeedIntExts();
            SeedDayNights();
            SeedScriptLocations();
            SeedScenes();
            SeedBreakdownTypes();
            SeedCallTypes();
            SeedCrewDepartments();
            SeedCrew();
        }

        private void SeedProjects()
        {
            if(!_context.Projects.Any())
            {
                var projects = new List<Project>
                {
                    new Project { Title = "The Dying Dead" },
                    new Project { Title = "Hitler Needs Woman" },
                    new Project { Title = "It Came From the Planet" },
                    new Project { Title = "Color Me Crazy" },
                    new Project { Title = "Monstro!" },
                };

                _context.Projects.AddRange(projects);

                _context.SaveChanges();
            }
        }

        private void SeedIntExts()
        {
            if(!_context.IntExts.Any())
            {
                var entities = new List<IntExt>
                {
                    new IntExt { ProjectID = 1, Name = "INT" },
                    new IntExt { ProjectID = 1, Name = "EXT" },
                    new IntExt { ProjectID = 2, Name = "INT" },
                    new IntExt { ProjectID = 2, Name = "EXT" },
                };

                _context.IntExts.AddRange(entities);

                _context.SaveChanges();
            }
        }

        private void SeedDayNights()
        {
            if(!_context.DayNights.Any())
            {
                var entities = new List<DayNight>
                {
                    new DayNight { ProjectID = 1, Name = "DAY" },
                    new DayNight { ProjectID = 1, Name = "NIGHT" },
                    new DayNight { ProjectID = 2, Name = "DAY" },
                    new DayNight { ProjectID = 2, Name = "NIGHT" },
                };

                _context.DayNights.AddRange(entities);

                _context.SaveChanges();
            }
        }

        private void SeedScriptLocations()
        {
            if(!_context.ScriptLocations.Any())
            {
                var entities = new List<ScriptLocation>
                {
                    new ScriptLocation { ProjectID = 1, Name = "HOUSE" },
                    new ScriptLocation { ProjectID = 1, Name = "HOUSE - KITCHEN" },
                    new ScriptLocation { ProjectID = 1, Name = "HOUSE - LIVING ROOM" },
                    new ScriptLocation { ProjectID = 1, Name = "STREET" },
                    new ScriptLocation { ProjectID = 1, Name = "PARK" },

                    new ScriptLocation { ProjectID = 2, Name = "FOREST" },
                    new ScriptLocation { ProjectID = 2, Name = "COTTAGE" },
                    new ScriptLocation { ProjectID = 2, Name = "MEADOW" },
                    new ScriptLocation { ProjectID = 2, Name = "RIVER" },
                };

                _context.ScriptLocations.AddRange(entities);

                _context.SaveChanges();
            }
        }

        private void SeedScenes()
        {
            if(!_context.Scenes.Any())
            {
                var entities = new List<Scene>
                {
                    new Scene { ProjectID = 1, IntExtID = 2, ScriptLocationID = 1, DayNightID = 1, PageLength = 1, Number = "1", Summary = "Establishing shot" },
                    new Scene { ProjectID = 1, IntExtID = 1, ScriptLocationID = 2, DayNightID = 1, PageLength = 9, Number = "2", Summary = "Janice gets ready to go out." },
                    new Scene { ProjectID = 1, IntExtID = 1, ScriptLocationID = 3, DayNightID = 1, PageLength = 2, Number = "2A", Summary = "Janice picks up her lunch." },
                    new Scene { ProjectID = 1, IntExtID = 2, ScriptLocationID = 5, DayNightID = 2, PageLength = 8, Number = "3", Summary = "Janice goes home through the park." },

                    new Scene { ProjectID = 2, IntExtID = 3, ScriptLocationID = 6, DayNightID = 4, PageLength = 2, Number = "1", Summary = "A dark forest" },                    
                    new Scene { ProjectID = 2, IntExtID = 4, ScriptLocationID = 7, DayNightID = 4, PageLength = 10, Number = "2", Summary = "Freddy in his little cottage" },                    
                    new Scene { ProjectID = 2, IntExtID = 3, ScriptLocationID = 6, DayNightID = 4, PageLength = 6, Number = "3", Summary = "Freddy goes for a walk in the forest" },                    
                    new Scene { ProjectID = 2, IntExtID = 3, ScriptLocationID = 8, DayNightID = 3, PageLength = 2, Number = "4", Summary = "Freddy walks through a meadow" },                    
                    new Scene { ProjectID = 2, IntExtID = 3, ScriptLocationID = 9, DayNightID = 3, PageLength = 3, Number = "5", Summary = "Freddy takes a bath in a river" },                    
                };

                _context.Scenes.AddRange(entities);

                _context.SaveChanges();
            }
        }

        private void SeedBreakdownTypes()
        {
            var definitions = _context.BreakdownTypeDefinitions.ToArray();

            foreach(var project in _context.Projects.Include(p=> p.BreakdownTypes))
            {
                if(!project.BreakdownTypes.Any())
                {
                    foreach(var definition in definitions)
                    {
                        project.BreakdownTypes.Add(new BreakdownType
                        {
                            Name = definition.Name,
                            Description = definition.Description,
                        });
                    }
                }
            }

            _context.SaveChanges();
        }

        private void SeedCallTypes()
        {
            var definitions = _context.CallTypeDefinitions.ToArray();

            foreach(var project in _context.Projects.Include(p=> p.CallTypes))
            {
                if(!project.CallTypes.Any())
                {
                    foreach(var definition in definitions)
                    {
                        project.CallTypes.Add(new CallType
                        {
                            ShortName = definition.ShortName,
                            Name = definition.Name,
                            Description = definition.Description,
                            SortingOrder = definition.SortingOrder,
                        });
                    }
                }
            }

            _context.SaveChanges();
        }

        private void SeedCrewDepartments()
        {
            var definitions = _context.CrewDepartmentDefinitions.ToArray();

            foreach(var project in _context.Projects.Include(p=> p.CrewDepartments))
            {
                if(!project.CrewDepartments.Any())
                {
                    foreach(var definition in definitions)
                    {
                        project.CrewDepartments.Add(new CrewDepartment
                        {
                            Name = definition.Name,
                            Description = definition.Description,
                            SortingOrder = definition.SortingOrder,
                        });
                    }
                }
            }

            _context.SaveChanges();
        }

        private void SeedCrew()
        {
            var adminUser = _context.Users.FirstOrDefault(u=> u.Email == adminEmail);

            if(adminUser!= null)
            {
                foreach(var project in _context.Projects.Include(p=> p.ProjectUsers).ThenInclude(c=> c.User))
                {
                    if(!project.ProjectUsers.Any())
                    {
                        project.ProjectUsers.Add(new ProjectUser
                        {
                            UserID = adminUser.Id
                        });
                    }
                }
            }


            _context.SaveChanges();
        }
    }
}