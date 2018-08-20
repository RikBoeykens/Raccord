using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Images;
using System.Collections.Generic;
using Raccord.API.ViewModels.Locations.LocationSets;
using Raccord.API.ViewModels.Comments;

namespace Raccord.API.ViewModels.ScriptLocations
{
    // ViewModel to represent a location
    public class FullScriptLocationViewModel : ScriptLocationViewModel
    {
        private IEnumerable<SceneSummaryViewModel> _scenes;
        private IEnumerable<LinkedImageViewModel> _images;
        private IEnumerable<LocationSetLocationViewModel> _sets;
        private IEnumerable<CommentViewModel> _comments;

        // Scenes linked to the location
        public IEnumerable<SceneSummaryViewModel> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<SceneSummaryViewModel>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Images linked to the location
        public IEnumerable<LinkedImageViewModel> Images
        {
            get
            {
                return _images ?? (_images = new List<LinkedImageViewModel>());
            }
            set
            {
                _images = value;
            }
        }

        // sets linked to the location
        public IEnumerable<LocationSetLocationViewModel> Sets
        {
            get
            {
                return _sets ?? (_sets = new List<LocationSetLocationViewModel>());
            }
            set
            {
                _sets = value;
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