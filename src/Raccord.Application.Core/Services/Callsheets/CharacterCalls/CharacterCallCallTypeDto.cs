using System;
using Raccord.Application.Core.Services.Callsheets.CallTypes;

namespace Raccord.Application.Core.Services.Callsheets.CharacterCalls
{
    // Dto to represent a character with call type info
    public class CharacterCallCallTypeDto : CharacterCallDto
    {
        private CallTypeDto _callType;

        // Linked call type
        public CallTypeDto CallType
        {
            get
            {
                return _callType ?? (_callType = new CallTypeDto());
            }
            set
            {
                _callType = value;
            }
        }
    }
}