using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.ScriptLocations;
using Raccord.API.ViewModels.Characters;
using System.Collections.Generic;
using Raccord.API.ViewModels.Breakdowns.BreakdownItems;
using Raccord.API.ViewModels.Shots.Slates;
using Raccord.API.ViewModels.Comments;

namespace Raccord.API.ViewModels.Images
{
    // ViewModel to represent a image
    public class FullImageViewModel : ImageViewModel
    {
        private IEnumerable<LinkedSceneViewModel> _scenes;
        private IEnumerable<LinkedScriptLocationViewModel> _scriptLocations;
        private IEnumerable<LinkedCharacterViewModel> _characters;
        private IEnumerable<LinkedBreakdownItemViewModel> _breakdownItems;
        private IEnumerable<LinkedSlateViewModel> _slates;
        private IEnumerable<CommentViewModel> _comments;
        
        // Indicates if the image is primary image for the project
        public bool IsPrimaryImage { get; set; }

        // Scenes linked to the image
        public IEnumerable<LinkedSceneViewModel> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<LinkedSceneViewModel>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Locations linked to the image
        public IEnumerable<LinkedScriptLocationViewModel> ScriptLocations
        {
            get
            {
                return _scriptLocations ?? (_scriptLocations = new List<LinkedScriptLocationViewModel>());
            }
            set
            {
                _scriptLocations = value;
            }
        }

        // Characters linked to the image
        public IEnumerable<LinkedCharacterViewModel> Characters
        {
            get
            {
                return _characters ?? (_characters = new List<LinkedCharacterViewModel>());
            }
            set
            {
                _characters = value;
            }
        }

        // Breakdown items linked to the image
        public IEnumerable<LinkedBreakdownItemViewModel> BreakdownItems
        {
            get
            {
                return _breakdownItems ?? (_breakdownItems = new List<LinkedBreakdownItemViewModel>());
            }
            set
            {
                _breakdownItems = value;
            }
        }

        // Slates linked to the image
        public IEnumerable<LinkedSlateViewModel> Slates
        {
            get
            {
                return _slates ?? (_slates = new List<LinkedSlateViewModel>());
            }
            set
            {
                _slates = value;
            }
        }

        // comments linked
        public IEnumerable<CommentViewModel> Comments
        {
            get
            {
                return _comments ?? (_comments = new List<CommentViewModel>());
            }
            set
            {
                _comments = value;
            }
        }
    }
}