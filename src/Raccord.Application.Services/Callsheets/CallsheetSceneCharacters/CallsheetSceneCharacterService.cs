using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Callsheets.CallsheetSceneCharacters;
using Raccord.Application.Core.Services.Callsheets.CallsheetScenes;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Services.Callsheets.CallsheetScenes;
using Raccord.Application.Services.Characters;
using Raccord.Data.EntityFramework.Repositories.Callsheets.Scenes;
using Raccord.Domain.Model.Callsheets.Scenes;

namespace Raccord.Application.Services.Callsheets.CallsheetSceneCharacters
{
    public class CallsheetSceneCharacterService: ICallsheetSceneCharacterService
    {
        private readonly ICallsheetSceneCharacterRepository _callsheetSceneCharacterRepository;
        public CallsheetSceneCharacterService(ICallsheetSceneCharacterRepository callsheetSceneCharacterRepository)
        {
            if(callsheetSceneCharacterRepository == null)
                throw new ArgumentNullException(nameof(callsheetSceneCharacterRepository));
            
            _callsheetSceneCharacterRepository = callsheetSceneCharacterRepository;
        }

        // Gets all characters for a callsheet scene
        public IEnumerable<LinkedCharacterDto> GetCharacters(long ID)
        {
            var callsheetSceneCharacters = _callsheetSceneCharacterRepository.GetAllForCallsheetScene(ID);

            var dtos = callsheetSceneCharacters.Select(i=> i.TranslateCharacter());

            return dtos;
        }

        // Gets all scenes for a character
        public IEnumerable<LinkedCallsheetSceneDto> GetCallsheetScenes(long ID)
        {
            var callsheetSceneCharacters = _callsheetSceneCharacterRepository.GetAllForCharacter(ID);

            var dtos = callsheetSceneCharacters.Select(i=> i.TranslateCallsheetScene());

            return dtos;
        }

        public long AddLink(long callsheetSceneID, long characterSceneID)
        {
            var callsheetSceneCharacter = _callsheetSceneCharacterRepository.FindBy(i=> i.CharacterSceneID == characterSceneID && i.CallsheetSceneID==callsheetSceneID);

            if(callsheetSceneCharacter.Any()){
                return callsheetSceneCharacter.First().ID;
            }

            var newCharacter = new CallsheetSceneCharacter
            {
                CharacterSceneID = characterSceneID,
                CallsheetSceneID = callsheetSceneID
            };
            _callsheetSceneCharacterRepository.Add(newCharacter);

            _callsheetSceneCharacterRepository.Commit();

            return newCharacter.ID;
        }

        public void RemoveLink(long ID)
        {
            var callsheetSceneCharacter = _callsheetSceneCharacterRepository.GetSingle(ID);

            _callsheetSceneCharacterRepository.Delete(callsheetSceneCharacter);

            _callsheetSceneCharacterRepository.Commit();
        }
    }
}