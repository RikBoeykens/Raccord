using Raccord.Application.Core.Services.Characters;
using Raccord.Domain.Model.Characters;
using Raccord.Domain.Model.Images;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using System.Linq;
using Raccord.Application.Services.Images;
using Raccord.Application.Services.Scenes;

namespace Raccord.Application.Services.Characters
{
    // Utilities and helper methods for Characters
    public static class Utilities
    {
        public static FullCharacterDto TranslateFull(this Character character)
        {
            var dto = new FullCharacterDto
            {
                ID = character.ID,
                Number = character.Number,
                Name = character.Name,
                Description = character.Description,
                Images = character.ImageCharacters.Select(i=> i.TranslateImage()),
                Scenes = character.CharacterScenes.OrderBy(s=> s.Scene.Number).Select(s=> s.TranslateScene()),
                ProjectID = character.ProjectID,
            };

            return dto;
        }

        public static CharacterSummaryDto TranslateSummary(this Character character)
        {
            var dto = new CharacterSummaryDto
            {
                ID = character.ID,
                Number = character.Number,
                Name = character.Name,
                Description = character.Description,
                PrimaryImage = character.ImageCharacters.FirstOrDefault(i=> i.IsPrimaryImage)?.Image.Translate(),
                SceneCount = character.CharacterScenes.Count(),
                ProjectID = character.ProjectID,
            };

            return dto;
        }

        public static CharacterDto Translate(this Character character)
        {
            var dto = new CharacterDto
            {
                ID = character.ID,
                Number = character.Number,
                Name = character.Name,
                Description = character.Description,
                ProjectID = character.ProjectID,
            };

            return dto;
        }

        public static LinkedCharacterDto TranslateCharacter(this ImageCharacter imageCharacter)
        {
            var dto = new LinkedCharacterDto
            {
                ID = imageCharacter.Character.ID,
                Number = imageCharacter.Character.Number,
                Name = imageCharacter.Character.Name,
                Description = imageCharacter.Character.Description,
                ProjectID = imageCharacter.Character.ProjectID,
                LinkID = imageCharacter.ID,
            };

            return dto;
        }

        public static LinkedCharacterDto TranslateCharacter(this CharacterScene characterScene)
        {
            var dto = new LinkedCharacterDto
            {
                ID = characterScene.Character.ID,
                Number = characterScene.Character.Number,
                Name = characterScene.Character.Name,
                Description = characterScene.Character.Description,
                ProjectID = characterScene.Character.ProjectID,
                PrimaryImage = characterScene.Character.ImageCharacters.FirstOrDefault(i=> i.IsPrimaryImage)?.Image.Translate(),
                LinkID = characterScene.ID,
            };

            return dto;
        }

        public static SearchResultDto TranslateToSearchResult(this Character character)
        {
            var dto = new SearchResultDto
            {
                ID = character.ID,
                RouteIDs = new long[]{character.ProjectID, character.ID},
                DisplayName = character.Name,
                Info = $"Project: {character.Project.Title}",
                Type = EntityType.Character,
            };

            return dto;
        }

        public static string GetDisplaySummary(this Character character)
        {
            return $"{character.Number}. {character.Name}";
        }
    }
}