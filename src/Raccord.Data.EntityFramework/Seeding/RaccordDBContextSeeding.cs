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
using Raccord.Domain.Model.Users.ProjectRoles;
using Raccord.Core.Enums;
using Raccord.Domain.Model.Breakdowns;
using Raccord.Domain.Model.Crew.CrewUnits;
using Raccord.Domain.Model.Characters;

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
            SeedProjectRolesAndPermissions();
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
                    new CrewDepartmentDefinition{ SortingOrder = 1, Name = "Director" },
                    new CrewDepartmentDefinition{ SortingOrder = 2, Name = "Producers" },
                    new CrewDepartmentDefinition{ SortingOrder = 3, Name = "Production" },
                    new CrewDepartmentDefinition{ SortingOrder = 4, Name = "Art Department" },
                    new CrewDepartmentDefinition{ SortingOrder = 5, Name = "Assistant Directors" },
                    new CrewDepartmentDefinition{ SortingOrder = 6, Name = "Camera" },
                    new CrewDepartmentDefinition{ SortingOrder = 7, Name = "Costume" },
                    new CrewDepartmentDefinition{ SortingOrder = 8, Name = "Electrical" },
                    new CrewDepartmentDefinition{ SortingOrder = 9, Name = "Locations" },
                    new CrewDepartmentDefinition{ SortingOrder = 10, Name = "Make Up & Hair" },
                    new CrewDepartmentDefinition{ SortingOrder = 11, Name = "Props" }
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
                _userManager.CreateAsync(new ApplicationUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true, FirstName = "Rik", LastName = "Boeykens" }, adminPassword).Result.ToString();
                _userManager.AddToRoleAsync(_userManager.FindByNameAsync(adminEmail).GetAwaiter().GetResult(), "admin").Result.ToString();
            }
        }
        private void SeedProjectRolesAndPermissions()
        {
            var permissionsToAdd = new List<ProjectPermissionDefinition>
            {
                new ProjectPermissionDefinition{ Permission = ProjectPermissionEnum.CanEditUsers, Name = "Can Edit Users"},
                new ProjectPermissionDefinition{ Permission = ProjectPermissionEnum.CanEditGeneral, Name = "Can Edit"},
                new ProjectPermissionDefinition{ Permission = ProjectPermissionEnum.CanReadGeneral, Name = "Can Read"},
                new ProjectPermissionDefinition{ Permission = ProjectPermissionEnum.CanReadCallsheet, Name = "Can Read Callsheet"},
                new ProjectPermissionDefinition{ Permission = ProjectPermissionEnum.CanComment, Name = "Can Comment"},
            };
            foreach(var permission in permissionsToAdd)
            {
                if(!_context.ProjectPermissionDefinitions.Any(p=> p.Permission == permission.Permission))
                {
                    _context.Add(permission);
                }
            }

            var projectRolesToAdd = new List<ProjectRoleDefinition>
            {
                new ProjectRoleDefinition{ Role = ProjectRoleEnum.Admin, Name = "Project Admin", },
                new ProjectRoleDefinition{ Role = ProjectRoleEnum.Editor, Name = "Editor", },
                new ProjectRoleDefinition{ Role = ProjectRoleEnum.User, Name = "User", },
                new ProjectRoleDefinition{ Role = ProjectRoleEnum.CallsheetUser, Name = "Callsheet User", },
            };
            
            foreach(var projectRole in projectRolesToAdd)
            {
                if(!_context.ProjectRoleDefinitions.Any(p=> p.Role == projectRole.Role))
                {
                    _context.Add(projectRole);
                }
            }
            
            _context.SaveChanges();

            var canEditUserPermissionId = _context.ProjectPermissionDefinitions.Single(p=> p.Permission == ProjectPermissionEnum.CanEditUsers).ID;
            var canEditGeneralPermissionId = _context.ProjectPermissionDefinitions.Single(p=> p.Permission == ProjectPermissionEnum.CanEditGeneral).ID;
            var canReadGeneralPermissionId = _context.ProjectPermissionDefinitions.Single(p=> p.Permission == ProjectPermissionEnum.CanReadGeneral).ID;
            var canReadCallsheetPermissionId = _context.ProjectPermissionDefinitions.Single(p=> p.Permission == ProjectPermissionEnum.CanReadCallsheet).ID;
            var canCommentPermissionId = _context.ProjectPermissionDefinitions.Single(p=> p.Permission == ProjectPermissionEnum.CanComment).ID;

            var projectAdminRoleId = _context.ProjectRoleDefinitions.Single(p=> p.Role == ProjectRoleEnum.Admin).ID;
            var editorRoleId = _context.ProjectRoleDefinitions.Single(p=> p.Role == ProjectRoleEnum.Editor).ID;
            var userRoleId = _context.ProjectRoleDefinitions.Single(p=> p.Role == ProjectRoleEnum.User).ID;
            var callsheetUserRoleId = _context.ProjectRoleDefinitions.Single(p=> p.Role == ProjectRoleEnum.CallsheetUser).ID;

            var permissionRoles = new List<ProjectPermissionRoleDefinition>
            {
                // Project Admin
                new ProjectPermissionRoleDefinition { ProjectRoleID = projectAdminRoleId, ProjectPermissionID = canEditUserPermissionId },
                new ProjectPermissionRoleDefinition { ProjectRoleID = projectAdminRoleId, ProjectPermissionID = canEditGeneralPermissionId },
                new ProjectPermissionRoleDefinition { ProjectRoleID = projectAdminRoleId, ProjectPermissionID = canReadGeneralPermissionId },
                new ProjectPermissionRoleDefinition { ProjectRoleID = projectAdminRoleId, ProjectPermissionID = canReadCallsheetPermissionId },
                new ProjectPermissionRoleDefinition { ProjectRoleID = projectAdminRoleId, ProjectPermissionID = canCommentPermissionId },
                // Editor
                new ProjectPermissionRoleDefinition { ProjectRoleID = editorRoleId, ProjectPermissionID = canEditGeneralPermissionId },
                new ProjectPermissionRoleDefinition { ProjectRoleID = editorRoleId, ProjectPermissionID = canReadGeneralPermissionId },
                new ProjectPermissionRoleDefinition { ProjectRoleID = editorRoleId, ProjectPermissionID = canReadCallsheetPermissionId },
                new ProjectPermissionRoleDefinition { ProjectRoleID = editorRoleId, ProjectPermissionID = canCommentPermissionId },
                // User
                new ProjectPermissionRoleDefinition { ProjectRoleID = userRoleId, ProjectPermissionID = canReadGeneralPermissionId },
                new ProjectPermissionRoleDefinition { ProjectRoleID = userRoleId, ProjectPermissionID = canReadCallsheetPermissionId },
                new ProjectPermissionRoleDefinition { ProjectRoleID = userRoleId, ProjectPermissionID = canCommentPermissionId },
                // CallsheetUser
                new ProjectPermissionRoleDefinition { ProjectRoleID = callsheetUserRoleId, ProjectPermissionID = canReadCallsheetPermissionId },
            };
            
            foreach(var permissionRole in permissionRoles)
            {
                if(!_context.ProjectPermissionRoleDefinitions.Any(p=> p.ProjectRoleID == permissionRole.ProjectRoleID && p.ProjectPermissionID == permissionRole.ProjectPermissionID))
                {
                    _context.Add(permissionRole);
                }
            }

            _context.SaveChanges();
        }
        private void TestSeeding()
        {
            SeedProjects();
            SeedSceneIntros();
            SeedTimeOfDays();
            SeedScriptLocations();
            SeedScenes();
            SeedCharacters();
            SeedCallTypes();
            SeedCrew();
            SeedCrewUnits();
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

        private void SeedSceneIntros()
        {
            if(!_context.SceneIntros.Any())
            {
                var entities = new List<SceneIntro>
                {
                    new SceneIntro { ProjectID = 1, Name = "INT" },
                    new SceneIntro { ProjectID = 1, Name = "EXT" },
                    new SceneIntro { ProjectID = 2, Name = "INT" },
                    new SceneIntro { ProjectID = 2, Name = "EXT" },
                };

                _context.SceneIntros.AddRange(entities);

                _context.SaveChanges();
            }
        }

        private void SeedTimeOfDays()
        {
            if(!_context.TimeOfDays.Any())
            {
                var entities = new List<TimeOfDay>
                {
                    new TimeOfDay { ProjectID = 1, Name = "DAY" },
                    new TimeOfDay { ProjectID = 1, Name = "NIGHT" },
                    new TimeOfDay { ProjectID = 2, Name = "DAY" },
                    new TimeOfDay { ProjectID = 2, Name = "NIGHT" },
                };

                _context.TimeOfDays.AddRange(entities);

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
                    new Scene { ProjectID = 1, SceneIntroID = 2, ScriptLocationID = 1, TimeOfDayID = 1, PageLength = 1, Number = "1", Summary = "Establishing shot" },
                    new Scene { ProjectID = 1, SceneIntroID = 1, ScriptLocationID = 2, TimeOfDayID = 1, PageLength = 9, Number = "2", Summary = "Janice gets ready to go out." },
                    new Scene { ProjectID = 1, SceneIntroID = 1, ScriptLocationID = 3, TimeOfDayID = 1, PageLength = 2, Number = "2A", Summary = "Janice picks up her lunch." },
                    new Scene { ProjectID = 1, SceneIntroID = 2, ScriptLocationID = 5, TimeOfDayID = 2, PageLength = 8, Number = "3", Summary = "Janice goes home through the park." },

                    new Scene { ProjectID = 2, SceneIntroID = 3, ScriptLocationID = 6, TimeOfDayID = 4, PageLength = 2, Number = "1", Summary = "A dark forest" },                    
                    new Scene { ProjectID = 2, SceneIntroID = 4, ScriptLocationID = 7, TimeOfDayID = 4, PageLength = 10, Number = "2", Summary = "Freddy in his little cottage" },                    
                    new Scene { ProjectID = 2, SceneIntroID = 3, ScriptLocationID = 6, TimeOfDayID = 4, PageLength = 6, Number = "3", Summary = "Freddy goes for a walk in the forest" },                    
                    new Scene { ProjectID = 2, SceneIntroID = 3, ScriptLocationID = 8, TimeOfDayID = 3, PageLength = 2, Number = "4", Summary = "Freddy walks through a meadow" },                    
                    new Scene { ProjectID = 2, SceneIntroID = 3, ScriptLocationID = 9, TimeOfDayID = 3, PageLength = 3, Number = "5", Summary = "Freddy takes a bath in a river" },                    
                };

                _context.Scenes.AddRange(entities);

                _context.SaveChanges();
            }
        }

        private void SeedCharacters()
        {
            if(!_context.Characters.Any())
            {
                var entities = new List<Character>
                {
                    new Character { ProjectID = 1, Name = "Alice", Number = 1, },
                    new Character { ProjectID = 1, Name = "Bob", Number = 2, },
                    new Character { ProjectID = 1, Name = "Carol", Number = 3, },
                    new Character { ProjectID = 1, Name = "Janice", Number = 4, },

                    new Character { ProjectID = 2, Name = "Freddy", Number = 1 }
                };

                _context.Characters.AddRange(entities);

                _context.SaveChanges();
            }
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

        private void SeedCrewUnits()
        {
            var definitions = _context.CrewDepartmentDefinitions.ToArray();
            foreach(var project in _context.Projects.Include(p=> p.CrewUnits))
            {
                if(!project.CrewUnits.Any())
                {
                    project.CrewUnits.Add(new CrewUnit
                    {
                        Name = "Main Unit",
                        Description = string.Empty,
                        CrewDepartments = definitions.Select(definition => new CrewDepartment
                        {
                            Name = definition.Name,
                            Description = definition.Description,
                            SortingOrder = definition.SortingOrder,
                        }).ToList()
                    });
                }
            }

            _context.SaveChanges();
        }
    }
}