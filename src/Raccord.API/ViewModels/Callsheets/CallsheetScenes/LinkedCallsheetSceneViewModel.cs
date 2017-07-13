namespace Raccord.API.ViewModels.Callsheets.CallsheetScenes
{
    // ViewModel to represent a callsheet scene that's linked to something
    public class LinkedCallsheetSceneViewModel: CallsheetSceneSummaryViewModel
    {
        // ID of the link
        public long LinkID { get; set; }
    }
}