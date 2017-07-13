namespace Raccord.Application.Core.Services.Callsheets.CallsheetScenes
{
    // Dto to represent a scene on a schedule day
    public class CallsheetSceneDto
    {
        // ID of the schedule scene
        public long ID { get; set; }

        // Length in eights
        public int PageLength { get; set; }

        // ID of the linked schedule day
        public long CallsheetID { get; set; }

        // ID of the linked scene
        public long SceneID { get; set; }

        // ID of the location set
        public long? LocationSetID { get; set; }
    }
}