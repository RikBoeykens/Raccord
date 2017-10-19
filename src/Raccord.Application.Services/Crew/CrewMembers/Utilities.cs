using System.Linq;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Application.Core.Services.Crew.CrewMembers;
using Raccord.Application.Services.Crew.CrewMembers;
using Raccord.Core.Enums;
using Raccord.Domain.Model.Crew.CrewMembers;
using Raccord.Application.Services.Crew.Departments;

namespace Raccord.Application.Services.Crew.CrewMembers
{
    public static class Utilities
    {
        public static FullCrewMemberDto TranslateFull(this CrewMember crewMember)
        {
            return new FullCrewMemberDto
            {
                ID = crewMember.ID,
                FirstName = crewMember.FirstName,
                LastName = crewMember.LastName,
                JobTitle = crewMember.JobTitle,
                Telephone = crewMember.Telephone,
                Email = crewMember.Email,
                Department = crewMember.Department.Translate(),
            };
        }
        public static CrewMemberSummaryDto TranslateSummary(this CrewMember crewMember)
        {
            return new CrewMemberSummaryDto
            {
                ID = crewMember.ID,
                FirstName = crewMember.FirstName,
                LastName = crewMember.LastName,
                JobTitle = crewMember.JobTitle,
                Telephone = crewMember.Telephone,
                Email = crewMember.Email,
                Department = crewMember.Department.Translate(),
            };
        }
        public static CrewMemberDto Translate(this CrewMember crewMember)
        {
            return new CrewMemberDto
            {
                ID = crewMember.ID,
                FirstName = crewMember.FirstName,
                LastName = crewMember.LastName,
                JobTitle = crewMember.JobTitle,
                Telephone = crewMember.Telephone,
                Email = crewMember.Email,
                Department = crewMember.Department.Translate(),
            };
        }

        public static SearchResultDto TranslateToSearchResult(this CrewMember crewMember)
        {
            return new SearchResultDto
            {
                ID = crewMember.ID,
                RouteIDs = new long[]{crewMember.Department.ProjectID, crewMember.DepartmentID, crewMember.ID},
                DisplayName = $"{crewMember.GetDisplayName()} - {crewMember.Department.Name}",
                Info = $"Project: {crewMember.Department.Project.Title}",
                Type = EntityType.CrewMember,  
            };
        }

        public static string GetDisplayName(this CrewMember crewMember)
        {
            return $"{crewMember.FirstName} {crewMember.LastName}";
        }
    }
}