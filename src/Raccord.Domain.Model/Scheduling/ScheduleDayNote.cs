namespace Raccord.Domain.Model.Scheduling
{
    /// Represents schedule scene on a day
    public class ScheduleDayNote : Entity
    {
        // Content of the note
        public string Content { get; set; }

        // The sorting order of the scene within the project
        public int SortingOrder { get; set; }

        // ID of the linked schedule day
        public long ScheduleDayID { get; set; }

        // Linked image
        public virtual ScheduleDay ScheduleDay { get; set; }
    }
}