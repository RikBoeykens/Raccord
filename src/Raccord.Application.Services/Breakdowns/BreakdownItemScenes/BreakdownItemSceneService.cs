using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Data.EntityFramework.Repositories.Breakdowns.BreakdownItemScenes;
using Raccord.Application.Services.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItemScenes;
using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Services.Scenes;

namespace Raccord.Application.Services.Breakdowns.BreakdownItemScenes
{
    // Service used for breakdown item scene functionality
    public class BreakdownItemSceneService : IBreakdownItemSceneService
    {
        private readonly IBreakdownItemSceneRepository _itemSceneRepository;

        // Initialises a new BreakdownItemSceneService
        public BreakdownItemSceneService(IBreakdownItemSceneRepository itemSceneRepository)
        {
            if(itemSceneRepository == null)
                throw new ArgumentNullException(nameof(itemSceneRepository));
            
            _itemSceneRepository = itemSceneRepository;
        }

        // Gets all breakdown items for a scene
        public IEnumerable<LinkedBreakdownItemDto> GetItems(long ID)
        {
            var itemScenes = _itemSceneRepository.GetAllForScene(ID);

            var dtos = itemScenes.Select(i=> i.TranslateBreakdownItem());

            return dtos;
        }

        // Gets all scenes for a breakdown item
        public IEnumerable<LinkedSceneDto> GetScenes(long ID)
        {
            var itemScenes = _itemSceneRepository.GetAllForBreakdownItem(ID);

            var dtos = itemScenes.Select(i=> i.TranslateScene());

            return dtos;
        }

        public void AddLink(long itemID, long sceneID)
        {
            var itemScene = _itemSceneRepository.FindBy(i=> i.BreakdownItemID == itemID && i.SceneID==sceneID);

            if(!itemScene.Any()){
                _itemSceneRepository.Add(new BreakdownItemScene
                {
                    BreakdownItemID = itemID,
                    SceneID = sceneID
                });

                _itemSceneRepository.Commit();
            }     
        }

        public void RemoveLink(long ID)
        {
            var itemScene = _itemSceneRepository.GetSingle(ID);

            _itemSceneRepository.Delete(itemScene);

            _itemSceneRepository.Commit();
        }
    }
}