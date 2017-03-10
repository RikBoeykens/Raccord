using System.Collections.Generic;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.Scenes;

namespace Raccord.Application.Core.Services.Breakdowns.BreakdownItemScenes
{
    // Interface for breakdown item scene functionality
    public interface IBreakdownItemSceneService
    {
        IEnumerable<LinkedBreakdownItemDto> GetItems(long ID);
        IEnumerable<LinkedSceneDto> GetScenes(long ID);

        // Links a breakdown item to a scene
        void AddLink(long breakdownItemID, long sceneID);

        // Removes link between breakdown item and scene
        void RemoveLink(long ID);
    }
}