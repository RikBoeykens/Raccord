using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Images;
using Raccord.Application.Core.Services.Images;
using Raccord.Data.EntityFramework.Repositories.ImageSlates;
using Raccord.Application.Services.Images;
using Raccord.Application.Core.Services.ImageSlates;

namespace Raccord.Application.Services.ImageSlates
{
    // Service used for image slate functionality
    public class ImageSlateService : IImageSlateService
    {
        private readonly IImageSlateRepository _imageSlateRepository;

        // Initialises a new ImageSlateService
        public ImageSlateService(IImageSlateRepository imageSlateRepository)
        {
            if(imageSlateRepository == null)
                throw new ArgumentNullException(nameof(imageSlateRepository));
            
            _imageSlateRepository = imageSlateRepository;
        }

        // Gets all images
        public IEnumerable<LinkedImageDto> GetImages(long ID)
        {
            var imageCharacters = _imageSlateRepository.GetAllForSlate(ID);

            var dtos = imageCharacters.Select(i=> i.TranslateImage());

            return dtos;
        }

        public void AddLink(long imageID, long slateID)
        {
            var imageSlate = _imageSlateRepository.FindBy(i=> i.ImageID == imageID && i.SlateID==slateID);

            if(!imageSlate.Any()){
                _imageSlateRepository.Add(new ImageSlate
                {
                    ImageID = imageID,
                    SlateID = slateID
                });

                _imageSlateRepository.Commit();
            }     
        }

        public void RemoveLink(long ID)
        {
            var imageSlate = _imageSlateRepository.GetSingle(ID);

            _imageSlateRepository.Delete(imageSlate);

            _imageSlateRepository.Commit();
        }
        public void SetAsPrimary(long ID)
        {
            var imageSlate = _imageSlateRepository.GetSingle(ID);
            ClearPrimaryImages(imageSlate.SlateID);

            imageSlate.IsPrimaryImage = true;

            _imageSlateRepository.Edit(imageSlate);
            _imageSlateRepository.Commit();
        }

        public void RemoveAsPrimary(long ID)
        {
            var imageSlate = _imageSlateRepository.GetSingle(ID);

            imageSlate.IsPrimaryImage = false;

            _imageSlateRepository.Edit(imageSlate);
            _imageSlateRepository.Commit();
        }

        private void ClearPrimaryImages(long slateID)
        {
            var primaryImages = _imageSlateRepository.FindBy(i=> i.SlateID == slateID && i.IsPrimaryImage);

            foreach(var imageSlate in primaryImages)
            {
                imageSlate.IsPrimaryImage = false;
                _imageSlateRepository.Edit(imageSlate);
            }

            _imageSlateRepository.Commit();
        }
    }
}