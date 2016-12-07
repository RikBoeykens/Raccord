namespace Raccord.API.ViewModels.SceneProperties
{
    // Viewmodel to represent summary of int/ext
    public class IntExtSummaryViewModel
    {
        // ID of the Int/Ext
        public long ID { get; set; }

        /// Name of the int/ext
        public string Name { get; set; }

        /// Description of the int/ext
        public string Description { get; set; }

        // ID of the project
        public long ProjectID { get; set; }
    }
}