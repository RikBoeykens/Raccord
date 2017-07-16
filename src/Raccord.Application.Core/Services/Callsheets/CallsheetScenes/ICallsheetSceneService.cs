using System.Collections.Generic;
using Raccord.Application.Core.Common.Sorting;

namespace Raccord.Application.Core.Services.Callsheets.CallsheetScenes
{
    // Interface for location functionality
    public interface ICallsheetSceneService
    {
        IEnumerable<CallsheetSceneCallsheetDto> GetCallsheets(long sceneID);

        IEnumerable<CallsheetSceneSceneDto> GetScenes(long callsheetID);
        IEnumerable<CallsheetSceneLocationDto> GetLocations(long callsheetID);

        FullCallsheetSceneDto Get(long ID);

        long Add(CallsheetSceneDto dto);

        long Update(CallsheetSceneDto dto);

        void Delete(long ID);
        void Sort(SortOrderDto order);
    }
}