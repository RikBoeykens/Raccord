using System.Collections.Generic;

namespace Raccord.Application.Core.Services
{
    // Interface for general service functionality
    public interface IService<T, TSummary>
    {
        // Returns a single full instance
        T Get(long ID);

        // Returns the summary of a single instance
        TSummary GetSummary(long ID);

        // Adds a single instance
        long Add(TSummary dto);
        
        // Updates a single instance
        long Update(TSummary dto);

        // Deletes a single instance
        void Delete(long ID);
    }
}