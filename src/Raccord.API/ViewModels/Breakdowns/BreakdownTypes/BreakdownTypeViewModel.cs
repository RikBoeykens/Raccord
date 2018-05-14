namespace Raccord.API.ViewModels.Breakdowns.BreakdownTypes
{
    // Viewmodel to represents a breakdown type
    public class BreakdownTypeViewModel
    {
        // ID of the breakdown type
        public long ID { get; set; }

        /// Name of the breakdown type
        public string Name { get; set; }

        /// Description of the breakdown type
        public string Description { get; set; }

        // ID of the breakdown
        public long BreakdownID { get; set; }
    }
}