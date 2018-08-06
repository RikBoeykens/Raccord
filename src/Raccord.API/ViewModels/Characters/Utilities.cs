using Raccord.Application.Core.Services.Characters;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Images;
using Raccord.API.ViewModels.Scheduling.ScheduleScenes;
using System.Linq;
using Raccord.API.ViewModels.Scheduling.ScheduleDays;
using Raccord.API.ViewModels.Profile;
using Raccord.API.ViewModels.Cast;
using Raccord.API.ViewModels.Comments;

namespace Raccord.API.ViewModels.Characters
{
    public static class Utilities
    {
        // Translates a character dto to a character viewmodel
        public static FullCharacterViewModel Translate(this FullCharacterDto dto)
        {
            return new FullCharacterViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                Scenes = dto.Scenes.Select(s=> s.Translate()),
                Images = dto.Images.Select(s=> s.Translate()),
                ScheduleDays = dto.ScheduleDays.Select(sd=> sd.Translate()),
                Comments = dto.Comments.Select(c => c.Translate()),
                CastMember = dto.CastMember.Translate(),
            };
        }

        // Translates a character summary dto to a character summary viewmodel
        public static CharacterSummaryViewModel Translate(this CharacterSummaryDto dto)
        {
            return new CharacterSummaryViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                SceneCount = dto.SceneCount,
                PrimaryImage = dto.PrimaryImage.Translate(),
            };
        }

        // Translates a character dto to a character viewmodel
        public static CharacterViewModel Translate(this CharacterDto dto)
        {
            return new CharacterViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
            };
        }

        // Translates a linked character dto to a linked character viewmodel
        public static LinkedCharacterViewModel Translate(this LinkedCharacterDto dto)
        {
            return new LinkedCharacterViewModel
            {
                ID = dto.ID,
                Number = dto.Number,
                Name = dto.Name,
                Description = dto.Description,
                ProjectID = dto.ProjectID,
                PrimaryImage = dto.PrimaryImage.Translate(),
                LinkID = dto.LinkID,
            };
        }

        // Translates a character viewmodel to a dto
        public static CharacterDto Translate(this CharacterViewModel vm)
        {
            return new CharacterDto
            {
                ID = vm.ID,
                Number = vm.Number,
                Name = vm.Name,
                Description = vm.Description,
                ProjectID = vm.ProjectID,
            };
        }
    }
}