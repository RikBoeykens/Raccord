using System;
using System.Collections.Generic;
using System.Linq;
using Raccord.Domain.Model.Images;
using Raccord.Application.Core.Services.Images;
using Raccord.Data.EntityFramework.Repositories.ImageCharacters;
using Raccord.Application.Services.Images;
using Raccord.Application.Core.Services.ImageCharacters;

namespace Raccord.Application.Services.ImageCharacters
{
    // Service used for image character functionality
    public class ImageCharacterService : IImageCharacterService
    {
        private readonly IImageCharacterRepository _imageCharacterRepository;

        // Initialises a new ImageCharacterService
        public ImageCharacterService(IImageCharacterRepository imageCharacterRepository)
        {
            if(imageCharacterRepository == null)
                throw new ArgumentNullException(nameof(imageCharacterRepository));
            
            _imageCharacterRepository = imageCharacterRepository;
        }

        // Gets all images
        public IEnumerable<LinkedImageDto> GetImages(long ID)
        {
            var imageCharacters = _imageCharacterRepository.GetAllForCharacter(ID);

            var dtos = imageCharacters.Select(i=> i.TranslateImage());

            return dtos;
        }

        public void AddLink(long imageID, long characterID)
        {
            var imageCharacter = _imageCharacterRepository.FindBy(i=> i.ImageID == imageID && i.CharacterID==characterID);

            if(!imageCharacter.Any()){
                _imageCharacterRepository.Add(new ImageCharacter
                {
                    ImageID = imageID,
                    CharacterID = characterID
                });

                _imageCharacterRepository.Commit();
            }     
        }

        public void RemoveLink(long ID)
        {
            var imageCharacter = _imageCharacterRepository.GetSingle(ID);

            _imageCharacterRepository.Delete(imageCharacter);

            _imageCharacterRepository.Commit();
        }
        public void SetAsPrimary(long ID)
        {
            var imageCharacter = _imageCharacterRepository.GetSingle(ID);
            ClearPrimaryImages(imageCharacter.CharacterID);

            imageCharacter.IsPrimaryImage = true;

            _imageCharacterRepository.Edit(imageCharacter);
            _imageCharacterRepository.Commit();
        }

        public void RemoveAsPrimary(long ID)
        {
            var imageCharacter = _imageCharacterRepository.GetSingle(ID);

            imageCharacter.IsPrimaryImage = false;

            _imageCharacterRepository.Edit(imageCharacter);
            _imageCharacterRepository.Commit();
        }

        private void ClearPrimaryImages(long characterID)
        {
            var primaryImages = _imageCharacterRepository.FindBy(i=> i.CharacterID == characterID && i.IsPrimaryImage);

            foreach(var imageCharacter in primaryImages)
            {
                imageCharacter.IsPrimaryImage = false;
                _imageCharacterRepository.Edit(imageCharacter);
            }

            _imageCharacterRepository.Commit();
        }
    }
}