using System.Linq;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Application.Core.Services.Crew.CrewMembers;
using Raccord.Application.Services.Crew.CrewMembers;
using Raccord.Core.Enums;
using Raccord.Domain.Model.Crew.CrewMembers;
using Raccord.Application.Services.Crew.Departments;
using Raccord.Application.Services.Crew.CrewUnits;

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
                CrewUnit = crewMember.Department.CrewUnit.Translate(),
                UserID = crewMember.GetUserID(),
                HasImage = crewMember.GetHasImage(),
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
                UserID = crewMember.GetUserID(),
                HasImage = crewMember.GetHasImage(),
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
        public static CrewMemberUnitDto TranslateUnit(this CrewMember crewMember)
        {
            return new CrewMemberUnitDto
            {
                ID = crewMember.ID,
                FirstName = crewMember.GetFirstName(),
                LastName = crewMember.GetLastName(),
                JobTitle = crewMember.JobTitle,
                Telephone = crewMember.GetTelephone(),
                Email = crewMember.GetEmail(),
                Department = crewMember.Department.Translate(),
                CrewUnit = crewMember.Department.CrewUnit.Translate(),
            };
        }

        public static SearchResultDto TranslateToSearchResult(this CrewMember crewMember)
        {
            return new SearchResultDto
            {
                ID = crewMember.ID,
                RouteIDs = new long[]
                {
                    crewMember.Department.CrewUnit.ProjectID,
                    crewMember.Department.CrewUnitID,
                    crewMember.DepartmentID,
                    crewMember.ID
                },
                DisplayName = $"{crewMember.GetDisplayName()} - {crewMember.Department.Name}",
                Info = $"Project: {crewMember.Department.CrewUnit.Project.Title}",
                Type = EntityType.CrewMember,  
            };
        }

        public static string GetDisplayName(this CrewMember crewMember)
        {
            return $"{crewMember.GetFirstName()} {crewMember.GetLastName()}";
        }

        private static string GetFirstName(this CrewMember crewMember)
        {
            if(crewMember.GetHasUser())
            {
                return crewMember.CrewUnitMember.ProjectUser.User.FirstName;
            }
            return crewMember.FirstName;
        }

        private static string GetLastName(this CrewMember crewMember)
        {
            if(crewMember.GetHasUser())
            {
                return crewMember.CrewUnitMember.ProjectUser.User.LastName;
            }
            return crewMember.LastName;
        }

        private static string GetTelephone(this CrewMember crewMember)
        {
            if(crewMember.GetHasUser())
            {
                return crewMember.CrewUnitMember.ProjectUser.User.Telephone;
            }
            return crewMember.Telephone;
        }

        private static string GetEmail(this CrewMember crewMember)
        {
            if(crewMember.GetHasUser())
            {
                return crewMember.CrewUnitMember.ProjectUser.User.PreferredEmail;
            }
            return crewMember.Email;
        }

        private static string GetUserID(this CrewMember crewMember)
        {
            if(crewMember.GetHasUser())
            {
                return crewMember.CrewUnitMember.ProjectUser.UserID;
            }
            return string.Empty;
        }

        private static bool GetHasImage(this CrewMember crewMember)
        {
            return crewMember.GetHasUser() && crewMember.CrewUnitMember.ProjectUser.User.ImageContent != null;
        }

        private static bool GetHasUser(this CrewMember crewMember)
        {
            return crewMember.CrewUnitMemberID.HasValue;
        }
    }
}