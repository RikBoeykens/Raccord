using Raccord.API.ViewModels.Crew.CrewUnits;
using Raccord.API.ViewModels.Crew.Departments;
using Raccord.Application.Core.Services.Crew.CrewMembers;

namespace Raccord.API.ViewModels.Crew.CrewMembers
{
    public static class Utilities
    {
        public static FullCrewMemberViewModel Translate(this FullCrewMemberDto dto)
        {
            return new FullCrewMemberViewModel
            {
                ID = dto.ID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                JobTitle = dto.JobTitle,
                Email = dto.Email,
                Telephone = dto.Telephone,
                Department = dto.Department.Translate(),
                UserID = dto.UserID,
                HasImage = dto.HasImage,
                CrewUnit = dto.CrewUnit.Translate(),
            };
        }

        public static CrewMemberSummaryViewModel Translate(this CrewMemberSummaryDto dto)
        {
            return new CrewMemberSummaryViewModel
            {
                ID = dto.ID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                JobTitle = dto.JobTitle,
                Email = dto.Email,
                Telephone = dto.Telephone,
                Department = dto.Department.Translate(),
                UserID = dto.UserID,
                HasImage = dto.HasImage,
            };
        }

        public static CrewMemberUnitViewModel Translate(this CrewMemberUnitDto dto)
        {
            return new CrewMemberUnitViewModel
            {
                ID = dto.ID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                JobTitle = dto.JobTitle,
                Email = dto.Email,
                Telephone = dto.Telephone,
                Department = dto.Department.Translate(),
                CrewUnit = dto.CrewUnit.Translate(),
            };
        }

        public static CrewMemberViewModel Translate(this CrewMemberDto dto)
        {
            return new CrewMemberViewModel
            {
                ID = dto.ID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                JobTitle = dto.JobTitle,
                Email = dto.Email,
                Telephone = dto.Telephone,
                Department = dto.Department.Translate(),
            };
        }

        public static CrewMemberDto Translate(this CrewMemberViewModel vm)
        {
            return new CrewMemberDto
            {
                ID = vm.ID,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                JobTitle = vm.JobTitle,
                Email = vm.Email,
                Telephone = vm.Telephone,
                Department = vm.Department.Translate(),
            };
        }
    }
}