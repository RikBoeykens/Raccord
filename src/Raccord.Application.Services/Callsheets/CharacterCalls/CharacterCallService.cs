using System;
using Raccord.Application.Core.Services.Callsheets.CharacterCalls;
using Raccord.Data.EntityFramework.Repositories.Callsheets.Characters;

namespace Raccord.Application.Services.Callsheets.Characters
{
    public class CharacterCallService : ICharacterCallService
    {
        private ICharacterCallRepository _characterCallRepository;

        public CharacterCallService(
            ICharacterCallRepository characterCallRepository
        ){
            if(characterCallRepository==null)
                throw new ArgumentNullException(nameof(characterCallRepository));

            _characterCallRepository = characterCallRepository;
        }

        public void Update(CharacterCallDto dto)
        {
            var call = _characterCallRepository.GetSingle(dto.ID);

            call.CallTime = dto.CallTime;

            _characterCallRepository.Edit(call);
            _characterCallRepository.Commit();
        }
    }
}