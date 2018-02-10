namespace Raccord.Application.Core.Services.Callsheets
{
    // Interface for location functionality
    public interface ICallsheetService : IAllForParentService<CallsheetSummaryDto>
    {
        // Returns a single full instance
        FullCallsheetDto Get(long ID, string userID);

        // Returns the summary of a single instance
        CallsheetSummaryDto GetSummary(long ID);

        // Adds a single instance
        long Add(CallsheetDto dto);
        
        // Updates a single instance
        long Update(CallsheetDto dto);

        // Deletes a single instance
        void Delete(long ID);
    }
}