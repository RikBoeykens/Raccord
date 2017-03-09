namespace Raccord.Application.Core.Services.Breakdowns.BreakdownTypes
{
    // Dto to represent a breakdown type
    public class BreakdownTypeDto
    {
        // ID of the breakdown type
        public long ID { get; set; }

        /// Name of the breakdown type
        public string Name { get; set; }

        /// Description of the breakdown type
        public string Description { get; set; }

        // ID of the project
        public long ProjectID { get; set; }
    }
}