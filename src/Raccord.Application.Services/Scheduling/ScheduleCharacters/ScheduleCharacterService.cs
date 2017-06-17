using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.Scheduling.ScheduleCharacters;
using Raccord.Application.Core.Services.Scheduling.ScheduleScenes;
using Raccord.Application.Services.Characters;
using Raccord.Application.Services.Scheduling.ScheduleScenes;
using Raccord.Data.EntityFramework.Repositories.Scheduling.ScheduleCharacters;
using Raccord.Domain.Model.Scheduling;

namespace Raccord.Application.Services.Scheduling.ScheduleCharacters
{
    public class ScheduleCharacterService: IScheduleCharacterService
    {
        private readonly IScheduleCharacterRepository _scheduleCharacterRepository;
        public ScheduleCharacterService(IScheduleCharacterRepository scheduleCharacterRepository)
        {
            if(scheduleCharacterRepository == null)
                throw new ArgumentNullException(nameof(scheduleCharacterRepository));
            
            _scheduleCharacterRepository = scheduleCharacterRepository;
        }

        // Gets all characters for a schedule scene
        public IEnumerable<LinkedCharacterDto> GetCharacters(long ID)
        {
            var scheduleCharacters = _scheduleCharacterRepository.GetAllForScheduleScene(ID);

            var dtos = scheduleCharacters.Select(i=> i.TranslateCharacter());

            return dtos;
        }

        // Gets all scenes for a character
        public IEnumerable<LinkedScheduleSceneDto> GetScheduleScenes(long ID)
        {
            var scheduleCharacters = _scheduleCharacterRepository.GetAllForCharacter(ID);

            var dtos = scheduleCharacters.Select(i=> i.TranslateScheduleScene());

            return dtos;
        }

        public void AddLink(long scheduleSceneID, long characterSceneID)
        {
            var scheduleCharacter = _scheduleCharacterRepository.FindBy(i=> i.CharacterSceneID == characterSceneID && i.ScheduleSceneID==scheduleSceneID);

            if(!scheduleCharacter.Any()){
                _scheduleCharacterRepository.Add(new ScheduleCharacter
                {
                    CharacterSceneID = characterSceneID,
                    ScheduleSceneID = scheduleSceneID
                });

                _scheduleCharacterRepository.Commit();
            }     
        }

        public void RemoveLink(long ID)
        {
            var characterScene = _scheduleCharacterRepository.GetSingle(ID);

            _scheduleCharacterRepository.Delete(characterScene);

            _scheduleCharacterRepository.Commit();
        }
    }
}