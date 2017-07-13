using System.Collections.Generic;

namespace Raccord.Application.Core.Services.Callsheets.CallsheetScenes
{
    // Interface for location functionality
    public interface ICallsheetSceneService
    {
        IEnumerable<CallsheetSceneCallsheetDto> GetCallsheets(long sceneID);

        IEnumerable<CallsheetSceneSceneDto> GetScenes(long dayID);

        FullCallsheetSceneDto Get(long ID);

        long Add(CallsheetSceneDto dto);

        long Update(CallsheetSceneDto dto);

        void Delete(long ID);
    }
}