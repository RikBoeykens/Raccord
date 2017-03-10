using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Images;
using Raccord.Application.Core.Services.Images;
using Raccord.Data.EntityFramework.Repositories.ImageBreakdownItems;
using Raccord.Application.Services.Images;
using Raccord.Application.Core.Services.ImageBreakdownItems;

namespace Raccord.Application.Services.ImageBreakdownItems
{
    // Service used for image breakdown item functionality
    public class ImageBreakdownItemService : IImageBreakdownItemService
    {
        private readonly IImageBreakdownItemRepository _imageBreakdownItemRepository;

        // Initialises a new ImageBreakdownItemService
        public ImageBreakdownItemService(IImageBreakdownItemRepository imageBreakdownItemRepository)
        {
            if(imageBreakdownItemRepository == null)
                throw new ArgumentNullException(nameof(imageBreakdownItemRepository));
            
            _imageBreakdownItemRepository = imageBreakdownItemRepository;
        }

        // Gets all images
        public IEnumerable<LinkedImageDto> GetImages(long ID)
        {
            var imageBreakdownItems = _imageBreakdownItemRepository.GetAllForBreakdownItem(ID);

            var dtos = imageBreakdownItems.Select(i=> i.TranslateImage());

            return dtos;
        }

        public void AddLink(long imageID, long itemID)
        {
            var imageBreakdownItem = _imageBreakdownItemRepository.FindBy(i=> i.ImageID == imageID && i.BreakdownItemID==itemID);

            if(!imageBreakdownItem.Any()){
                _imageBreakdownItemRepository.Add(new ImageBreakdownItem
                {
                    ImageID = imageID,
                    BreakdownItemID = itemID
                });

                _imageBreakdownItemRepository.Commit();
            }     
        }

        public void RemoveLink(long ID)
        {
            var imageBreakdownItem = _imageBreakdownItemRepository.GetSingle(ID);

            _imageBreakdownItemRepository.Delete(imageBreakdownItem);

            _imageBreakdownItemRepository.Commit();
        }
        public void SetAsPrimary(long ID)
        {
            var imageBreakdownItem = _imageBreakdownItemRepository.GetSingle(ID);
            ClearPrimaryImages(imageBreakdownItem.BreakdownItemID);

            imageBreakdownItem.IsPrimaryImage = true;

            _imageBreakdownItemRepository.Edit(imageBreakdownItem);
            _imageBreakdownItemRepository.Commit();
        }

        public void RemoveAsPrimary(long ID)
        {
            var imageBreakdownItem = _imageBreakdownItemRepository.GetSingle(ID);

            imageBreakdownItem.IsPrimaryImage = false;

            _imageBreakdownItemRepository.Edit(imageBreakdownItem);
            _imageBreakdownItemRepository.Commit();
        }

        private void ClearPrimaryImages(long itemID)
        {
            var primaryImages = _imageBreakdownItemRepository.FindBy(i=> i.BreakdownItemID == itemID && i.IsPrimaryImage);

            foreach(var imageBreakdownItem in primaryImages)
            {
                imageBreakdownItem.IsPrimaryImage = false;
                _imageBreakdownItemRepository.Edit(imageBreakdownItem);
            }

            _imageBreakdownItemRepository.Commit();
        }
    }
}