using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Characters;
using Raccord.Application.Core.Services.Characters;
using Raccord.Data.EntityFramework.Repositories.CharacterScenes;
using Raccord.Application.Services.Characters;
using Raccord.Application.Core.Services.CharacterScenes;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Services.Scenes;

namespace Raccord.Application.Services.CharacterScenes
{
    // Service used for character scene functionality
    public class CharacterSceneService : ICharacterSceneService
    {
        private readonly ICharacterSceneRepository _characterSceneRepository;

        // Initialises a new CharacterSceneService
        public CharacterSceneService(ICharacterSceneRepository characterSceneRepository)
        {
            if(characterSceneRepository == null)
                throw new ArgumentNullException(nameof(characterSceneRepository));
            
            _characterSceneRepository = characterSceneRepository;
        }

        // Gets all characters for a scene
        public IEnumerable<LinkedCharacterDto> GetCharacters(long ID)
        {
            var characterScenes = _characterSceneRepository.GetAllForScene(ID);

            var dtos = characterScenes.Select(i=> i.TranslateCharacter());

            return dtos;
        }

        // Gets all scenes for a character
        public IEnumerable<LinkedSceneDto> GetScenes(long ID)
        {
            var characterScenes = _characterSceneRepository.GetAllForCharacter(ID);

            var dtos = characterScenes.Select(i=> i.TranslateScene());

            return dtos;
        }

        public long AddLink(long characterID, long sceneID)
        {
            var characterScene = _characterSceneRepository.FindBy(i=> i.CharacterID == characterID && i.SceneID==sceneID);

            if(!characterScene.Any()){
                var newCharacterScene = new CharacterScene
                {
                    CharacterID = characterID,
                    SceneID = sceneID
                };
                _characterSceneRepository.Add(newCharacterScene);

                _characterSceneRepository.Commit();

                return newCharacterScene.ID;
            }
            return characterScene.FirstOrDefault().ID; 
        }

        public void RemoveLink(long ID)
        {
            var characterScene = _characterSceneRepository.GetSingle(ID);

            _characterSceneRepository.Delete(characterScene);

            _characterSceneRepository.Commit();
        }
    }
}