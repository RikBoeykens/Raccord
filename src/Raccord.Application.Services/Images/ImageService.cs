using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Raccord.Domain.Model.Images;
using Raccord.Application.Core.Services.Images;
using Raccord.Data.EntityFramework.Repositories.Images;
using Raccord.Core.Enums;

namespace Raccord.Application.Services.Images
{
    // Service used for image functionality
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        // Initialises a new ImageService
        public ImageService(IImageRepository imageRepository)
        {
            if(imageRepository == null)
                throw new ArgumentNullException(nameof(imageRepository));
            
            _imageRepository = imageRepository;
        }

        // Gets all images
        public IEnumerable<ImageSummaryDto> GetAllForProject(long projectID)
        {
            var images = _imageRepository.GetAllForProject(projectID);

            var dtos = images.Select(l => l.TranslateSummary());

            return dtos;
        }

        // Gets a single image by id
        public FullImageDto Get(long ID)
        {
            var image = _imageRepository.GetFull(ID);

            var dto = image.TranslateFull();

            return dto;
        }

        // Gets a summary of a single image
        public ImageSummaryDto GetSummary(long ID)
        {
            var image = _imageRepository.GetSingle(ID);

            var dto = image.TranslateSummary();

            return dto;
        }

        // Adds images
        public IEnumerable<long> Add(AddImageContentDto dto)
        {
            var ids = new List<long>();

            foreach(var newImageDto in dto.Images)
            {
                using(var imageContent = newImageDto.FileContent)
                {
                    var image = new Image
                    {
                        Title = newImageDto.FileName,
                        FileContent = imageContent.GetBytes(),
                        FileName = newImageDto.FileName,
                        ProjectID = dto.ProjectID
                    };

                    if(newImageDto.SelectedEntity.EntityID!=default(long))
                    {
                        if(newImageDto.SelectedEntity.Type==EntityType.Scene)
                            image.ImageScenes.Add(new ImageScene{ SceneID = newImageDto.SelectedEntity.EntityID });
                        else if(newImageDto.SelectedEntity.Type==EntityType.Location)
                            image.ImageLocations.Add(new ImageLocation{ LocationID = newImageDto.SelectedEntity.EntityID });
                        else if(newImageDto.SelectedEntity.Type==EntityType.Character)
                            image.ImageCharacters.Add(new ImageCharacter{ CharacterID = newImageDto.SelectedEntity.EntityID });
                    }

                    _imageRepository.Add(image);

                    ids.Add(image.ID);
                }
            }
            
            _imageRepository.Commit();

            return ids;
        }

        // Updates a image
        public long Update(ImageDto dto)
        {
            var image = _imageRepository.GetSingle(dto.ID);

            image.Title = dto.Title;
            image.Description = dto.Description;

            _imageRepository.Edit(image);
            _imageRepository.Commit();

            return image.ID;
        }

        // Deletes a image
        public void Delete(Int64 ID)
        {
            var image = _imageRepository.GetSingle(ID);

            _imageRepository.Delete(image);

            _imageRepository.Commit();
        }

        public ImageContentDto GetContent(long ID)
        {
            var image = _imageRepository.GetSingle(ID);

            var dto = new ImageContentDto
            {
                FileContent = image.FileContent,
                FileName = image.FileName,
            };

            return dto;
        }

        public void SetAsPrimary(long ID)
        {
            ClearPrimaryImages();

            var image = _imageRepository.GetSingle(ID);
            image.IsPrimaryImage = true;
            _imageRepository.Edit(image);
            _imageRepository.Commit();
        }

        public void RemoveAsPrimary(long ID)
        {
            var image = _imageRepository.GetSingle(ID);
            image.IsPrimaryImage = false;
            _imageRepository.Edit(image);
            _imageRepository.Commit();
        }

        // Clears previous primary images
        private void ClearPrimaryImages()
        {
            var primaryImages = _imageRepository.FindBy(i=> i.IsPrimaryImage);

            foreach(var image in primaryImages)
            {
                image.IsPrimaryImage = false;
                _imageRepository.Edit(image);
            }

            _imageRepository.Commit();
        }
    }
}