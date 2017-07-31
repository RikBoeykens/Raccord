using Raccord.Application.Core.Services.Callsheets.CallTypes;
using Raccord.Domain.Model.Callsheets.CallTypes;

namespace Raccord.Application.Services.Callsheets.CallTypes
{
    public static class Utilities
    {
        public static CallTypeDto Translate(this CallType callType)
        {
            return new CallTypeDto
            {
                ID = callType.ID,
                ShortName = callType.ShortName,
                Name = callType.Name,
                Description = callType.Description,
            };
        }
    }
}