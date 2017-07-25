using Raccord.API.ViewModels.Callsheets.CallTypes;

namespace Raccord.API.ViewModels.Callsheets.CharacterCalls
{
    // Dto to represent a character with call type info
    public class CharacterCallCallTypeViewModel : CharacterCallViewModel
    {
        private CallTypeViewModel _callType;

        // Linked call type
        public CallTypeViewModel CallType
        {
            get
            {
                return _callType ?? (_callType = new CallTypeViewModel());
            }
            set
            {
                _callType = value;
            }
        }
    }
}