using System.Linq;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Crew.CrewMembers;
using Raccord.API.ViewModels.Images;
using Raccord.API.ViewModels.Users.Invitations.Project;
using Raccord.API.ViewModels.Users.Projects;
using Raccord.Application.Core.Services.Projects;

namespace Raccord.API.ViewModels.Projects
{
    public static class Utilities
    {
        // Translates a project dto to a project viewmodel
        public static FullProjectViewModel Translate(this FullProjectDto dto)
        {
            return new FullProjectViewModel
            {
                ID = dto.ID,
                Title = dto.Title,
                PrimaryImage = dto.PrimaryImage.Translate(),
            };
        }
        // Translates a project dto to a project viewmodel
        public static AdminFullProjectViewModel Translate(this AdminFullProjectDto dto)
        {
            return new AdminFullProjectViewModel
            {
                ID = dto.ID,
                Title = dto.Title,
                Users = dto.Users.Select(u => u.Translate()),
                Invitations = dto.Invitations.Select(u => u.Translate()),
                PrimaryImage = dto.PrimaryImage.Translate(),
            };
        }
        // Translates a project summary dto to a project summary viewmodel
        public static ProjectSummaryViewModel Translate(this ProjectSummaryDto dto)
        {
            return new ProjectSummaryViewModel
            {
                ID = dto.ID,
                Title = dto.Title,
                PrimaryImage = dto.PrimaryImage.Translate(),
            };
        }
        // Translates a project summary dto to a project summary viewmodel
        public static AdminProjectSummaryViewModel Translate(this AdminProjectSummaryDto dto)
        {
            return new AdminProjectSummaryViewModel
            {
                ID = dto.ID,
                Title = dto.Title,
                UserCount = dto.UserCount,
                InvitationCount = dto.InvitationCount,
                PrimaryImage = dto.PrimaryImage.Translate(),
            };
        }
        // Translates a project summary dto to a project summary viewmodel
        public static UserProjectViewModel Translate(this UserProjectDto dto)
        {
            return new UserProjectViewModel
            {
                ID = dto.ID,
                Title = dto.Title,
                PrimaryImage = dto.PrimaryImage.Translate(),
                CrewMembers = dto.CrewMembers.Select(cm=> cm.Translate()),
                Characters = dto.Characters.Select(c => c.Translate())
            };
        }
        // Translates a project summary dto to a project summary viewmodel
        public static UserProjectSummaryViewModel Translate(this UserProjectSummaryDto dto)
        {
            return new UserProjectSummaryViewModel
            {
                ID = dto.ID,
                Title = dto.Title,
                PrimaryImage = dto.PrimaryImage.Translate(),
                HasCrew = dto.HasCrew,
                HasCast = dto.HasCast
            };
        }

        // Translates a project dto to a project viewmodel
        public static ProjectViewModel Translate(this ProjectDto dto)
        {
            return new ProjectViewModel
            {
                ID = dto.ID,
                Title = dto.Title,
            };
        }

        // Translates a project viewmodel to a dto
        public static ProjectDto Translate(this ProjectViewModel vm)
        {
            return new ProjectDto
            {
                ID = vm.ID,
                Title = vm.Title,
            };
        }
    }
}