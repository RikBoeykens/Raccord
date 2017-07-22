using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Callsheets.Characters;
using Raccord.Data.EntityFramework.Repositories.Callsheets.CallTypes;
using Raccord.Data.EntityFramework.Repositories.Callsheets.Characters;
using Raccord.Data.EntityFramework.Repositories.Callsheets.Scenes;
using Raccord.Domain.Model.Callsheets.Characters;

namespace Raccord.Application.Services.Callsheets.Characters
{
    public class CallsheetCharacterService : ICallsheetCharacterService
    {
        private ICallsheetCharacterRepository _callsheetCharacterRepository;
        private ICallsheetSceneCharacterRepository _callsheetSceneCharacterRepository;
        private ICallTypeRepository _callTypeRepository;
        private ICharacterCallRepository _characterCallRepository;

        public CallsheetCharacterService(
            ICallsheetCharacterRepository callsheetCharacterRepository,
            ICallsheetSceneCharacterRepository callsheetSceneCharacterRepository,
            ICallTypeRepository callTypeRepository,
            ICharacterCallRepository characterCallRepository
        ){
            if(callsheetCharacterRepository==null)
                throw new ArgumentNullException(nameof(callsheetCharacterRepository));
            if(callsheetSceneCharacterRepository==null)
                throw new ArgumentNullException(nameof(callsheetSceneCharacterRepository));
            if(callTypeRepository==null)
                throw new ArgumentNullException(nameof(callTypeRepository));
            if(characterCallRepository==null)
                throw new ArgumentNullException(nameof(characterCallRepository));

            _callsheetCharacterRepository = callsheetCharacterRepository;
            _callsheetSceneCharacterRepository = callsheetSceneCharacterRepository;
            _callTypeRepository = callTypeRepository;
            _characterCallRepository = characterCallRepository;
        }

        public IEnumerable<CallsheetCharacterCharacterDto> GetCharacters(long callsheetID)
        {
            var characters = _callsheetCharacterRepository.GetAllForCallsheet(callsheetID);

            var dtos = characters.Select(c=> c.TranslateCharacter());

            return dtos;
        }

        public void SetCharacters(long callsheetID, long projectID)
        {
            var currentCharacters = _callsheetCharacterRepository.GetAllForCallsheet(callsheetID);
            var callsheetSceneCharacters = _callsheetSceneCharacterRepository.GetAllForCallsheet(callsheetID).GroupBy(csc=> csc.CharacterScene.Character, csc=> csc, (character, csc)=>character);
            var callTypes = _callTypeRepository.GetAllForProject(projectID);

            // remove characters no longer on the callsheet and add new calltypes
            foreach(var character in currentCharacters)
            {
                if(!callsheetSceneCharacters.Any(csc=> csc.ID == character.Character.ID))
                {
                    _callsheetCharacterRepository.Delete(character);
                    _callsheetCharacterRepository.Commit();
                }
                else
                {
                    foreach(var callType in callTypes)
                    {
                        if(!character.CharacterCalls.Any(cc=> cc.CallTypeID==callType.ID))
                        {
                            _characterCallRepository.Add(new CharacterCall
                            {
                                CallTypeID = callType.ID,
                                CallsheetCharacterID = character.ID,
                            });
                            _characterCallRepository.Commit();
                        }
                    }
                }
            }

            foreach(var character in callsheetSceneCharacters)
            {
                if(!currentCharacters.Any(csc=> csc.CharacterID == character.ID))
                {
                    var newCallsheetCharacter = new CallsheetCharacter
                    {
                        CharacterID = character.ID,
                        CallsheetID = callsheetID,
                    };

                    _callsheetCharacterRepository.Add(newCallsheetCharacter);
                    _callsheetCharacterRepository.Commit();

                    foreach(var callType in callTypes)
                    {
                        _characterCallRepository.Add(new CharacterCall
                        {
                            CallTypeID = callType.ID,
                            CallsheetCharacterID = newCallsheetCharacter.ID,
                        });
                        _characterCallRepository.Commit();
                    }
                }
            }
        }
    }
}