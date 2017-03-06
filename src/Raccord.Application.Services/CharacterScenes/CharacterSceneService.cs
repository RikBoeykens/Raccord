using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Characters;
using Raccord.Application.Core.Services.Characters;
using Raccord.Data.EntityFramework.Repositories.CharacterScenes;
using Raccord.Application.Services.Characters;
using Raccord.Application.Core.Services.CharacterScenes;

namespace Raccord.Application.Services.CharacterScenes
{
    // Service used for character scene functionality
    public class CharacterSceneService : ICharacterSceneService
    {
        private readonly ICharacterSceneRepository _imageSceneRepository;

        // Initialises a new CharacterSceneService
        public CharacterSceneService(ICharacterSceneRepository imageSceneRepository)
        {
            if(imageSceneRepository == null)
                throw new ArgumentNullException(nameof(imageSceneRepository));
            
            _imageSceneRepository = imageSceneRepository;
        }

        // Gets all characters
        public IEnumerable<LinkedCharacterDto> GetCharacters(long ID)
        {
            var characterScenes = _imageSceneRepository.GetAllForScene(ID);

            var dtos = characterScenes.Select(i=> i.TranslateCharacter());

            return dtos;
        }

        public void AddLink(long imageID, long sceneID)
        {
            var imageScene = _imageSceneRepository.FindBy(i=> i.CharacterID == imageID && i.SceneID==sceneID);

            if(!imageScene.Any()){
                _imageSceneRepository.Add(new CharacterScene
                {
                    CharacterID = imageID,
                    SceneID = sceneID
                });

                _imageSceneRepository.Commit();
            }     
        }

        public void RemoveLink(long ID)
        {
            var imageScene = _imageSceneRepository.GetSingle(ID);

            _imageSceneRepository.Delete(imageScene);

            _imageSceneRepository.Commit();
        }
    }
}