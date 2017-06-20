namespace Raccord.Application.Core.Services.ScriptLocations
{
    // Dto to represent a location that's linked to something
    public class LinkedScriptLocationDto: ScriptLocationDto
    {
        // ID of the link
        public long LinkID { get; set; }
    }
}