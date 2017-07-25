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
        public static CharacterCallViewModel Translate(this CharacterCallDto dto)
        {
            return new CharacterCallViewModel
            {
                ID = dto.ID,
                CallTime = dto.CallTime,
            };
        }
        public static CharacterCallDto Translate(this CharacterCallViewModel vm)
        {
            return new CharacterCallDto
            {
                ID = vm.ID,
                CallTime = vm.CallTime,
            };
        }
    }
}