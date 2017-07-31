using Raccord.Application.Core.Services.Callsheets.CharacterCalls;
using Raccord.Domain.Model.Callsheets.Characters;
using Raccord.Application.Services.Callsheets.CallTypes;

namespace Raccord.Application.Services.Callsheets.CharacterCalls
{
    public static class Utilities
    {
        public static CharacterCallCallTypeDto TranslateCallType(this CharacterCall characterCall)
        {
            return new CharacterCallCallTypeDto
            {
                ID = characterCall.ID,
                CallTime = characterCall.CallTime,
                CallType = characterCall.CallType.Translate(),
            };
        }
        public static CharacterCallDto Translate(this CharacterCall characterCall)
        {
            return new CharacterCallDto
            {
                ID = characterCall.ID,
                CallTime = characterCall.CallTime,
            };
        }
    }
}