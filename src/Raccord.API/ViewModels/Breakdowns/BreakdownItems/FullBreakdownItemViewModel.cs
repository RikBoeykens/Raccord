using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Images;
using System.Collections.Generic;

namespace Raccord.API.ViewModels.Breakdowns.BreakdownItems
{
    // ViewModel to represent a breakdown items
    public class FullBreakdownItemViewModel : BreakdownItemViewModel
    {
        private IEnumerable<LinkedSceneViewModel> _scenes;
        private IEnumerable<LinkedImageViewModel> _images;

        // Scenes linked to the breakdown item
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

        // Images linked to the breakdown item
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
    }
}