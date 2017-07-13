using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Callsheets.Scenes;
using Raccord.Application.Core.Services.Callsheets.CallsheetScenes;
using Raccord.Data.EntityFramework.Repositories.Callsheets.Scenes;
using Raccord.Data.EntityFramework.Repositories.CharacterScenes;
using Raccord.Domain.Model.Images;

namespace Raccord.Application.Services.Callsheets.CallsheetScenes
{
    // Service used for callsheet scene functionality
    public class CallsheetSceneService : ICallsheetSceneService
    {
        private readonly ICallsheetSceneRepository _callsheetSceneRepository;
        private readonly ICharacterSceneRepository _characterSceneRepository;

        // Initialises a new CallsheetSceneService
        public CallsheetSceneService(ICallsheetSceneRepository callsheetSceneRepository,
                                    ICharacterSceneRepository characterSceneRepository)
        {
            if(callsheetSceneRepository == null)
                throw new ArgumentNullException(nameof(callsheetSceneRepository));
            if(characterSceneRepository == null)
                throw new ArgumentNullException(nameof(characterSceneRepository));
            
            _callsheetSceneRepository = callsheetSceneRepository;
            _characterSceneRepository = characterSceneRepository;
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
            var callsheetScene = new CallsheetScene
            {
                PageLength = dto.PageLength,
                CallsheetID = dto.CallsheetID,
                SceneID = dto.SceneID,
                LocationSetID = dto.LocationSetID,
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
    }
}