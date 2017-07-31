namespace Raccord.Application.Core.Services.Callsheets.CallTypes
{
    // Dto to represent a call type
    public class CallTypeDto
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