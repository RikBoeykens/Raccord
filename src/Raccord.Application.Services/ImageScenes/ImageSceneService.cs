using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Images;
using Raccord.Application.Core.Services.Images;
using Raccord.Data.EntityFramework.Repositories.ImageScenes;
using Raccord.Application.Services.Images;
using Raccord.Application.Core.Services.ImageScenes;

namespace Raccord.Application.Services.ImageScenes
{
    // Service used for image scene functionality
    public class ImageSceneService : IImageSceneService
    {
        private readonly IImageSceneRepository _imageSceneRepository;

        // Initialises a new ImageSceneService
        public ImageSceneService(IImageSceneRepository imageSceneRepository)
        {
            if(imageSceneRepository == null)
                throw new ArgumentNullException(nameof(imageSceneRepository));
            
            _imageSceneRepository = imageSceneRepository;
        }

        // Gets all images
        public IEnumerable<LinkedImageDto> GetImages(long ID)
        {
            var imageScenes = _imageSceneRepository.GetAllForScene(ID);

            var dtos = imageScenes.Select(i=> i.TranslateImage());

            return dtos;
        }

        public void AddLink(long imageID, long sceneID)
        {
            var imageScene = _imageSceneRepository.FindBy(i=> i.ImageID == imageID && i.SceneID==sceneID);

            if(!imageScene.Any()){
                _imageSceneRepository.Add(new ImageScene
                {
                    ImageID = imageID,
                    SceneID = sceneID
                });

                _imageSceneRepository.Commit();
            }     
        }

        public void RemoveLink(long ID)
        {
            var imageScene = _imageSceneRepository.GetSingle(ID);

            _imageSceneRepository.Delete(imageScene);

            _imageSceneRepository.Commit();
        }
        public void SetAsPrimary(long ID)
        {
            var imageScene = _imageSceneRepository.GetSingle(ID);
            ClearPrimaryImages(imageScene.SceneID);

            imageScene.IsPrimaryImage = true;

            _imageSceneRepository.Edit(imageScene);
            _imageSceneRepository.Commit();
        }

        public void RemoveAsPrimary(long ID)
        {
            var imageScene = _imageSceneRepository.GetSingle(ID);

            imageScene.IsPrimaryImage = false;

            _imageSceneRepository.Edit(imageScene);
            _imageSceneRepository.Commit();
        }

        private void ClearPrimaryImages(long sceneID)
        {
            var primaryImages = _imageSceneRepository.FindBy(i=> i.SceneID == sceneID && i.IsPrimaryImage);

            foreach(var imageScene in primaryImages)
            {
                imageScene.IsPrimaryImage = false;
                _imageSceneRepository.Edit(imageScene);
            }

            _imageSceneRepository.Commit();
        }
    }
}