using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Images;
using Raccord.Application.Core.Services.Images;
using Raccord.Data.EntityFramework.Repositories.ImageLocations;
using Raccord.Application.Services.Images;
using Raccord.Application.Core.Services.ImageLocations;

namespace Raccord.Application.Services.ImageLocations
{
    // Service used for image location functionality
    public class ImageLocationService : IImageLocationService
    {
        private readonly IImageLocationRepository _imageLocationRepository;

        // Initialises a new ImageLocationService
        public ImageLocationService(IImageLocationRepository imageLocationRepository)
        {
            if(imageLocationRepository == null)
                throw new ArgumentNullException(nameof(imageLocationRepository));
            
            _imageLocationRepository = imageLocationRepository;
        }

        // Gets all images
        public IEnumerable<LinkedImageDto> GetImages(long ID)
        {
            var imageLocations = _imageLocationRepository.GetAllForLocation(ID);

            var dtos = imageLocations.Select(i=> i.TranslateImage());

            return dtos;
        }

        public void AddLink(long imageID, long locationID)
        {
            var imageLocation = _imageLocationRepository.FindBy(i=> i.ImageID == imageID && i.LocationID==locationID);

            if(!imageLocation.Any()){
                _imageLocationRepository.Add(new ImageLocation
                {
                    ImageID = imageID,
                    LocationID = locationID
                });

                _imageLocationRepository.Commit();
            }     
        }

        public void RemoveLink(long ID)
        {
            var imageLocation = _imageLocationRepository.GetSingle(ID);

            _imageLocationRepository.Delete(imageLocation);

            _imageLocationRepository.Commit();
        }
        public void SetAsPrimary(long ID)
        {
            var imageLocation = _imageLocationRepository.GetSingle(ID);
            ClearPrimaryImages(imageLocation.LocationID);

            imageLocation.IsPrimaryImage = true;

            _imageLocationRepository.Edit(imageLocation);
            _imageLocationRepository.Commit();
        }

        public void RemoveAsPrimary(long ID)
        {
            var imageLocation = _imageLocationRepository.GetSingle(ID);

            imageLocation.IsPrimaryImage = false;

            _imageLocationRepository.Edit(imageLocation);
            _imageLocationRepository.Commit();
        }

        private void ClearPrimaryImages(long locationID)
        {
            var primaryImages = _imageLocationRepository.FindBy(i=> i.LocationID == locationID && i.IsPrimaryImage);

            foreach(var imageLocation in primaryImages)
            {
                imageLocation.IsPrimaryImage = false;
                _imageLocationRepository.Edit(imageLocation);
            }

            _imageLocationRepository.Commit();
        }
    }
}