using Raccord.Domain.Model.Callsheets.Scenes;
using System.Collections.Generic;
using System;

namespace Raccord.Data.EntityFramework.Repositories.Callsheets.Scenes
{
    // Interface defining a repository for callsheet
    public interface ICallsheetSceneRepository : IBaseRepository<CallsheetScene>
    {
        IEnumerable<CallsheetScene> GetAllForCallsheet(long callshet);
        IEnumerable<CallsheetScene> GetAllForScene(long sceneID);
        CallsheetScene GetFull(long ID);
        CallsheetScene GetSummary(long ID);
    }
}