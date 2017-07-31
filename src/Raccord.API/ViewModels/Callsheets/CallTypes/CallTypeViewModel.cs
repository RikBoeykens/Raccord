namespace Raccord.API.ViewModels.Callsheets.CallTypes
{
    // Viewmodel to represent a call type
    public class CallTypeViewModel
    {
        // ID of the call type
        public long ID { get; set; }

        // Short name of the call type
        public string ShortName { get; set; }

        // Name of the call type
        public string Name { get; set; }

        // Description of the call type
        public string Description { get; set; }

        // ID of the linked project
        public long ProjectID { get; set; }
    }
}