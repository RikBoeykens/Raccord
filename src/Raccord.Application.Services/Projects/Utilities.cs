using Raccord.Application.Core.Services.Projects;
using Raccord.Domain.Model.Projects;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using System.Linq;
using Raccord.Application.Services.Images;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Crew.CrewMembers;
using Raccord.Domain.Model.Users;
using Raccord.Application.Services.Crew.CrewMembers;
using Raccord.Application.Services.Characters;

namespace Raccord.Application.Services.Projects
{
    // Utilities and helper methods for Projects
    public static class Utilities
    {
        public static FullProjectDto TranslateFull(this Project project)
        {
            var dto = new FullProjectDto
            {
                ID = project.ID,
                Title = project.Title,
                PrimaryImage = project.Images.FirstOrDefault(i=> i.IsPrimaryImage)?.Translate(),
            };

            return dto;
        }
        public static ProjectSummaryDto TranslateSummary(this Project project)
        {
            var dto = new ProjectSummaryDto
            {
                ID = project.ID,
                Title = project.Title,
                PrimaryImage = project.Images.FirstOrDefault(i=> i.IsPrimaryImage)?.Translate(),
            };

            return dto;
        }
        public static UserProjectDto TranslateUser(this Project project, ApplicationUser user)
        {
            var crewMembers = user.ProjectUsers.Where(pu=> pu.ProjectID == project.ID)
                    .SelectMany(pu=> pu.CrewUnitMembers)
                    .SelectMany(cum => cum.CrewMembers)
                    .Select(cm=> cm.TranslateUnit()).ToList();
            
            var characters = user.ProjectUsers.Where(pu=> pu.ProjectID == project.ID && pu.CastMemberID.HasValue)
                    .Select(pu => pu.CastMember)
                    .SelectMany(cm => cm.Characters)
                    .Select(c => c.Translate()).ToList();

            var dto = new UserProjectDto
            {
                ID = project.ID,
                Title = project.Title,
                PrimaryImage = project.Images.FirstOrDefault(i=> i.IsPrimaryImage)?.Translate(),
                CrewMembers = crewMembers,
                Characters = characters
            };

            return dto;
        }
        public static UserProjectSummaryDto TranslateUserSummary(this Project project, ApplicationUser user)
        {
            var hasCrew = user.ProjectUsers.Where(pu=> pu.ProjectID == project.ID)
                    .Any(pu=> pu.CrewUnitMembers.Any());
            var hasCast = user.ProjectUsers.Where(pu=> pu.ProjectID == project.ID && pu.CastMemberID.HasValue)
                    .Any(pu=> pu.CastMember.Characters.Any());
            
            var characters = user.ProjectUsers.Where(pu=> pu.ProjectID == project.ID && pu.CastMemberID.HasValue)
                    .Select(pu => pu.CastMember)
                    .SelectMany(cm => cm.Characters)
                    .Select(c => c.Translate()).ToList();
            var dto = new UserProjectSummaryDto
            {
                ID = project.ID,
                Title = project.Title,
                PrimaryImage = project.Images.FirstOrDefault(i=> i.IsPrimaryImage)?.Translate(),
                HasCrew = hasCrew,
                HasCast = hasCast
            };

            return dto;
        }
        public static ProjectDto Translate(this Project project)
        {
            var dto = new ProjectDto
            {
                ID = project.ID,
                Title = project.Title,
            };

            return dto;
        }

        public static SearchResultDto TranslateToSearchResult(this Project project)
        {
            var dto = new SearchResultDto
            {
                ID = project.ID,
                RouteIDs = new long[]{project.ID},
                DisplayName = project.Title,
                Type = EntityType.Project,
            };

            return dto;
        }
    }
}