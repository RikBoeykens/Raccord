using Raccord.Application.Core.Services.Scenes;
using System.Collections.Generic;
using Raccord.Application.Core.Services.ScriptLocations;
using Raccord.Application.Core.Services.Characters;
using Raccord.Application.Core.Services.Breakdowns.BreakdownItems;
using Raccord.Application.Core.Services.Shots.Slates;
using Raccord.Application.Core.Services.Comments;

namespace Raccord.Application.Core.Services.Images
{
    // Dto to represent a full image
    public class FullImageDto : ImageDto
    {
        private IEnumerable<LinkedSceneDto> _scenes;
        private IEnumerable<LinkedScriptLocationDto> _scriptLocations;
        private IEnumerable<LinkedCharacterDto> _characters;
        private IEnumerable<LinkedBreakdownItemDto> _items;
        private IEnumerable<LinkedSlateDto> _slates;
        private IEnumerable<CommentDto> _comments;
        
        // Indicates if the image is primary image for the project
        public bool IsPrimaryImage { get; set; }

        // Scenes linked to the image
        public IEnumerable<LinkedSceneDto> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<LinkedSceneDto>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Locations linked to the image
        public IEnumerable<LinkedScriptLocationDto> ScriptLocations
        {
            get
            {
                return _scriptLocations ?? (_scriptLocations = new List<LinkedScriptLocationDto>());
            }
            set
            {
                _scriptLocations = value;
            }
        }

        // Characters linked to the image
        public IEnumerable<LinkedCharacterDto> Characters
        {
            get
            {
                return _characters ?? (_characters = new List<LinkedCharacterDto>());
            }
            set
            {
                _characters = value;
            }
        }

        // Breakdown items linked to the image
        public IEnumerable<LinkedBreakdownItemDto> BreakdownItems
        {
            get
            {
                return _items ?? (_items = new List<LinkedBreakdownItemDto>());
            }
            set
            {
                _items = value;
            }
        }

        // Slates linked to the image
        public IEnumerable<LinkedSlateDto> Slates
        {
            get
            {
                return _slates ?? (_slates = new List<LinkedSlateDto>());
            }
            set
            {
                _slates = value;
            }
        }

        // Comments linked to the breakdown item
        public IEnumerable<CommentDto> Comments
        {
            get
            {
                return _comments ?? (_comments = new List<CommentDto>());
            }
            set
            {
                _comments = value;
            }
        }
    }
}