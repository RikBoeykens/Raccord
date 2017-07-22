using System;
using Raccord.Application.Core.Services.Callsheets.CallTypes;

namespace Raccord.Application.Core.Services.Callsheets.CharacterCalls
{
    // Dto to represent a character with call type info
    public class CharacterCallCallTypeDto
    {
        private CallTypeDto _callType;

        // ID of the character call
        public long ID { get; set; }

        // Time of call
        public DateTime CallTime { get; set; }

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