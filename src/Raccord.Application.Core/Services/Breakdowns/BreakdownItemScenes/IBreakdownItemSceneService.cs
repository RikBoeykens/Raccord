using System.Collections.Generic;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.Scenes;

namespace Raccord.Application.Core.Services.Breakdowns.BreakdownItemScenes
{
    // Interface for breakdown item scene functionality
    public interface IBreakdownItemSceneService
    {
        IEnumerable<SceneBreakdownItemDto> GetItems(long ID, long breakdownID);
        IEnumerable<LinkedSceneDto> GetScenes(long ID);

        // Links a breakdown item to a scene
        void AddLink(long breakdownItemID, long sceneID);

        // Removes link between breakdown item and scene
        void RemoveLink(long ID);
    }
}