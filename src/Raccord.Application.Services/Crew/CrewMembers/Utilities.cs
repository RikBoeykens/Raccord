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
                FirstName = crewMember.GetFirstName(),
                LastName = crewMember.GetLastName(),
                JobTitle = crewMember.JobTitle,
                Telephone = crewMember.GetTelephone(),
                Email = crewMember.GetEmail(),
                Department = crewMember.Department.Translate(),
                UserID = crewMember.ProjectUserID.HasValue ? crewMember.ProjectUser.UserID : string.Empty,
                HasImage = crewMember.ProjectUserID.HasValue ? crewMember.ProjectUser.User.ImageContent != null : false,
            };
        }
        public static CrewMemberSummaryDto TranslateSummary(this CrewMember crewMember)
        {
            return new CrewMemberSummaryDto
            {
                ID = crewMember.ID,
                FirstName = crewMember.GetFirstName(),
                LastName = crewMember.GetLastName(),
                JobTitle = crewMember.JobTitle,
                Telephone = crewMember.GetTelephone(),
                Email = crewMember.GetEmail(),
                Department = crewMember.Department.Translate(),
                UserID = crewMember.ProjectUserID.HasValue ? crewMember.ProjectUser.UserID : string.Empty,
                HasImage = crewMember.ProjectUserID.HasValue ? crewMember.ProjectUser.User.ImageContent != null : false,
            };
        }
        public static CrewMemberDto Translate(this CrewMember crewMember)
        {
            return new CrewMemberDto
            {
                ID = crewMember.ID,
                FirstName = crewMember.GetFirstName(),
                LastName = crewMember.GetLastName(),
                JobTitle = crewMember.JobTitle,
                Telephone = crewMember.GetTelephone(),
                Email = crewMember.GetEmail(),
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
            return $"{crewMember.GetFirstName()} {crewMember.GetLastName()}";
        }

        private static string GetFirstName(this CrewMember crewMember)
        {
            if(crewMember.ProjectUserID.HasValue)
            {
                return crewMember.ProjectUser.User.FirstName;
            }
            return crewMember.FirstName;
        }

        private static string GetLastName(this CrewMember crewMember)
        {
            if(crewMember.ProjectUserID.HasValue)
            {
                return crewMember.ProjectUser.User.LastName;
            }
            return crewMember.LastName;
        }

        private static string GetTelephone(this CrewMember crewMember)
        {
            if(crewMember.ProjectUserID.HasValue)
            {
                return crewMember.ProjectUser.User.Telephone;
            }
            return crewMember.Telephone;
        }

        private static string GetEmail(this CrewMember crewMember)
        {
            if(crewMember.ProjectUserID.HasValue)
            {
                return crewMember.ProjectUser.User.PreferredEmail;
            }
            return crewMember.Email;
        }
    }
}