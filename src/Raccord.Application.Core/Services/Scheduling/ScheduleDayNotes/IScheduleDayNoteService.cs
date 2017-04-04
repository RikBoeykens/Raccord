namespace Raccord.Application.Core.Services.Scheduling.ScheduleDayNotes
{
    // Interface for schedule day note functionality
    public interface IScheduleDayNoteService : IService<ScheduleDayNoteDto, ScheduleDayNoteSummaryDto, FullScheduleDayNoteDto>, IAllForParentService<ScheduleDayNoteSummaryDto>
    {
    }
}