using System;

namespace Raccord.API.ViewModels.Callsheets.CallsheetScenes
{
    // Dto to represent a scene on a callsheet
    public class CallsheetSceneViewModel
    {
        // ID of the schedule scene
        public long ID { get; set; }

        // Length in eights
        public int PageLength { get; set; }

        // ID of the linked callsheet
        public long CallsheetID { get; set; }

        // ID of the linked scene
        public long SceneID { get; set; }

        // ID of the linked location Set
        public long? LocationSetID { get; set; }
    }
}