using Raccord.API.ViewModels.Callsheets.CallTypes;
using Raccord.Application.Core.Services.Callsheets.CharacterCalls;

namespace Raccord.API.ViewModels.Callsheets.CharacterCalls
{
    public static class Utilities
    {
        public static CharacterCallCallTypeViewModel Translate(this CharacterCallCallTypeDto dto)
        {
            return new CharacterCallCallTypeViewModel
            {
                ID = dto.ID,
                CallTime = dto.CallTime,
                CallType = dto.CallType.Translate(),
            };
        }
    }
}