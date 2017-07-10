namespace Raccord.Application.Core.Services.Callsheets
{
    // Interface for location functionality
    public interface ICallsheetService : IService<CallsheetDto, CallsheetSummaryDto, FullCallsheetDto>, IAllForParentService<CallsheetSummaryDto>
    {
    }
}