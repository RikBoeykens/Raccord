using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Images;
using Raccord.Application.Core.Services.Images;
using Raccord.Data.EntityFramework.Repositories.ImageScriptLocations;
using Raccord.Application.Services.Images;
using Raccord.Application.Core.Services.ImageLocations;

namespace Raccord.Application.Services.ImageLocations
{
    // Service used for image location functionality
    public class ImageLocationService : IImageLocationService
    {
        private readonly IImageScriptLocationRepository _imageScriptLocationRepository;

        // Initialises a new ImageLocationService
        public ImageLocationService(IImageScriptLocationRepository imagescriptLocationRepository)
        {
            if(imagescriptLocationRepository == null)
                throw new ArgumentNullException(nameof(imagescriptLocationRepository));
            
            _imageScriptLocationRepository = imagescriptLocationRepository;
        }

        // Gets all images
        public IEnumerable<LinkedImageDto> GetImages(long ID)
        {
            var imageLocations = _imageScriptLocationRepository.GetAllForScriptLocation(ID);

            var dtos = imageLocations.Select(i=> i.TranslateImage());

            return dtos;
        }

        public void AddLink(long imageID, long locationID)
        {
            var imageLocation = _imageScriptLocationRepository.FindBy(i=> i.ImageID == imageID && i.LocationID==locationID);

            if(!imageLocation.Any()){
                _imageScriptLocationRepository.Add(new ImageScriptLocation
                {
                    ImageID = imageID,
                    LocationID = locationID
                });

                _imageScriptLocationRepository.Commit();
            }     
        }

        public void RemoveLink(long ID)
        {
            var imageLocation = _imageScriptLocationRepository.GetSingle(ID);

            _imageScriptLocationRepository.Delete(imageLocation);

            _imageScriptLocationRepository.Commit();
        }
        public void SetAsPrimary(long ID)
        {
            var imageLocation = _imageScriptLocationRepository.GetSingle(ID);
            ClearPrimaryImages(imageLocation.LocationID);

            imageLocation.IsPrimaryImage = true;

            _imageScriptLocationRepository.Edit(imageLocation);
            _imageScriptLocationRepository.Commit();
        }

        public void RemoveAsPrimary(long ID)
        {
            var imageLocation = _imageScriptLocationRepository.GetSingle(ID);

            imageLocation.IsPrimaryImage = false;

            _imageScriptLocationRepository.Edit(imageLocation);
            _imageScriptLocationRepository.Commit();
        }

        private void ClearPrimaryImages(long locationID)
        {
            var primaryImages = _imageScriptLocationRepository.FindBy(i=> i.LocationID == locationID && i.IsPrimaryImage);

            foreach(var imageLocation in primaryImages)
            {
                imageLocation.IsPrimaryImage = false;
                _imageScriptLocationRepository.Edit(imageLocation);
            }

            _imageScriptLocationRepository.Commit();
        }
    }
}