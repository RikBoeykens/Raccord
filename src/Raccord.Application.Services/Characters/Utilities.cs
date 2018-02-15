using Raccord.Application.Core.Services.Characters;
using Raccord.Domain.Model.Characters;
using Raccord.Domain.Model.Images;
using Raccord.Application.Core.Services.SearchEngine;
using Raccord.Core.Enums;
using System.Linq;
using Raccord.Application.Services.Images;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Services.Scheduling.ScheduleScenes;
using Raccord.Domain.Model.Scheduling;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Scheduling.ScheduleDays;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Services.Scheduling.ScheduleDays;
using Raccord.Domain.Model.Callsheets.Scenes;
using Raccord.Application.Services.Profile;

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
                ScheduleDays = character.GetCharacterScheduleDays(),
                User = character.ProjectUser.User.Translate(),
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

        public static LinkedCharacterDto TranslateCharacter(this ScheduleCharacter scheduleCharacter)
        {
            var dto = new LinkedCharacterDto
            {
                ID = scheduleCharacter.CharacterScene.Character.ID,
                Number = scheduleCharacter.CharacterScene.Character.Number,
                Name = scheduleCharacter.CharacterScene.Character.Name,
                Description = scheduleCharacter.CharacterScene.Character.Description,
                ProjectID = scheduleCharacter.CharacterScene.Character.ProjectID,
                PrimaryImage = scheduleCharacter.CharacterScene.Character.ImageCharacters.FirstOrDefault(i=> i.IsPrimaryImage)?.Image.Translate(),
                LinkID = scheduleCharacter.ID,
            };

            return dto;
        }

        public static LinkedCharacterDto TranslateCharacter(this CallsheetSceneCharacter callsheetSceneCharacter)
        {
            var dto = new LinkedCharacterDto
            {
                ID = callsheetSceneCharacter.CharacterScene.Character.ID,
                Number = callsheetSceneCharacter.CharacterScene.Character.Number,
                Name = callsheetSceneCharacter.CharacterScene.Character.Name,
                Description = callsheetSceneCharacter.CharacterScene.Character.Description,
                ProjectID = callsheetSceneCharacter.CharacterScene.Character.ProjectID,
                PrimaryImage = callsheetSceneCharacter.CharacterScene.Character.ImageCharacters.FirstOrDefault(i=> i.IsPrimaryImage)?.Image.Translate(),
                LinkID = callsheetSceneCharacter.ID,
            };

            return dto;
        }

        public static string GetDisplaySummary(this Character character)
        {
            return $"{character.Number}. {character.Name}";
        }
    }
}