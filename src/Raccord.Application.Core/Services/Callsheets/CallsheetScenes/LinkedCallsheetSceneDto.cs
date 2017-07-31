namespace Raccord.Application.Core.Services.Callsheets.CallsheetScenes
{
    // Dto to represent a callsheet scene that's linked to something
    public class LinkedCallsheetSceneDto: CallsheetSceneSummaryDto
    {
        // ID of the link
        public long LinkID { get; set; }
    }
}