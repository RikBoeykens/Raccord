using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Callsheets.Scenes;
using Raccord.Application.Core.Services.Callsheets.CallsheetScenes;
using Raccord.Data.EntityFramework.Repositories.Callsheets.Scenes;
using Raccord.Data.EntityFramework.Repositories.CharacterScenes;
using Raccord.Domain.Model.Images;
using Raccord.Application.Core.Common.Sorting;
using Raccord.Data.EntityFramework.Repositories.Callsheets;
using Raccord.Domain.Model.ShootingDays.Scenes;
using Raccord.Data.EntityFramework.Repositories.ShootingDays.Scenes;

namespace Raccord.Application.Services.Callsheets.CallsheetScenes
{
    // Service used for callsheet scene functionality
    public class CallsheetSceneService : ICallsheetSceneService
    {
        private readonly ICallsheetSceneRepository _callsheetSceneRepository;
        private readonly ICharacterSceneRepository _characterSceneRepository;
        private readonly ICallsheetRepository _callsheetRepository;
        private readonly IShootingDaySceneRepository _shootingDaySceneRepository;

        // Initialises a new CallsheetSceneService
        public CallsheetSceneService(ICallsheetSceneRepository callsheetSceneRepository,
                                    ICharacterSceneRepository characterSceneRepository,
                                    ICallsheetRepository callsheetRepository,
                                    IShootingDaySceneRepository shootingDaySceneRepository)
        {
            if(callsheetSceneRepository == null)
                throw new ArgumentNullException(nameof(callsheetSceneRepository));
            if(characterSceneRepository == null)
                throw new ArgumentNullException(nameof(characterSceneRepository));
            if(callsheetRepository == null)
                throw new ArgumentNullException(nameof(callsheetRepository));
            if(shootingDaySceneRepository == null)
                throw new ArgumentNullException(nameof(shootingDaySceneRepository));
            
            _callsheetSceneRepository = callsheetSceneRepository;
            _characterSceneRepository = characterSceneRepository;
            _callsheetRepository = callsheetRepository;
            _shootingDaySceneRepository = shootingDaySceneRepository;
        }

        // Gets all callsheet scenes for a scene
        public IEnumerable<CallsheetSceneCallsheetDto> GetCallsheets(long sceneID)
        {
            var callsheetScenes = _callsheetSceneRepository.GetAllForScene(sceneID);

            var dtos = callsheetScenes.Select(l => l.TranslateCallsheet());

            return dtos;
        }

        // Gets all callsheet scenes for a day
        public IEnumerable<CallsheetSceneSceneDto> GetScenes(long dayID)
        {
            var callsheetScenes = _callsheetSceneRepository.GetAllForCallsheet(dayID);

            var dtos = callsheetScenes.Select(l => l.TranslateScene());

            return dtos;
        }

        // Gets all callsheet scenes for a day
        public IEnumerable<CallsheetSceneLocationDto> GetLocations(long dayID)
        {
            var callsheetScenes = _callsheetSceneRepository.GetAllForCallsheetWithLocation(dayID);

            var dtos = callsheetScenes.Select(l => l.TranslateLocation());

            return dtos;
        }

        // Gets all callsheet scenes for a day
        public IEnumerable<CallsheetSceneCharactersDto> GetCharacters(long dayID)
        {
            var callsheetScenes = _callsheetSceneRepository.GetAllForCallsheetWithCharacters(dayID);

            var dtos = callsheetScenes.Select(l => l.TranslateCharacters());

            return dtos;
        }

        // Gets a single callsheet scene by id
        public FullCallsheetSceneDto Get(long ID)
        {
            var callsheetScene = _callsheetSceneRepository.GetFull(ID);

            var dto = callsheetScene.TranslateFull();

            return dto;
        }

        // Adds a callsheet scene
        public long Add(CallsheetSceneDto dto)
        {
            var callsheet = _callsheetRepository.GetSingle(dto.CallsheetID);

            var callsheetScene = new CallsheetScene
            {
                PageLength = dto.PageLength,
                CallsheetID = dto.CallsheetID,
                SceneID = dto.SceneID,
                LocationSetID = dto.LocationSetID,
                ShootingDayScene = new ShootingDayScene
                {
                    ShootingDayID = callsheet.ShootingDayID,
                    SceneID = dto.SceneID,
                },
            };

            // add all characters in the scene by default
            var characterScenes = _characterSceneRepository.GetAllForScene(dto.SceneID);
            foreach(var characterScene in characterScenes)
            {
                callsheetScene.Characters.Add(new CallsheetSceneCharacter
                {
                    CharacterSceneID = characterScene.ID
                });
            }

            _callsheetSceneRepository.Add(callsheetScene);
            _callsheetSceneRepository.Commit();

            return callsheetScene.ID;
        }

        // Updates a callsheet scene
        public long Update(CallsheetSceneDto dto)
        {
            var callsheetScene = _callsheetSceneRepository.GetSingle(dto.ID);

            callsheetScene.PageLength = dto.PageLength;
            callsheetScene.LocationSetID = dto.LocationSetID;

            _callsheetSceneRepository.Edit(callsheetScene);
            _callsheetSceneRepository.Commit();

            return callsheetScene.ID;
        }

        // Deletes a callsheet scene
        public void Delete(Int64 ID)
        {
            var callsheetScene = _callsheetSceneRepository.GetSingle(ID);

            _callsheetSceneRepository.Delete(callsheetScene);

            _callsheetSceneRepository.Commit();
        }

        // Sorts scenes
        public void Sort(SortOrderDto order)
        {
            var scenes = _callsheetSceneRepository.GetAllForCallsheet(order.ParentID);

            foreach(var scene in scenes)
            {
                var orderedIndex = Array.IndexOf(order.SortIDs, scene.ID);
                scene.SortingOrder = orderedIndex != -1 ? orderedIndex : scenes.Count();
                _callsheetSceneRepository.Edit(scene);
            }

            _callsheetSceneRepository.Commit();
        }
    }
}