using Raccord.API.ViewModels.Images;
using System.Collections.Generic;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Breakdowns.BreakdownItems;

namespace Raccord.API.ViewModels.Scenes
{
    // Viewmodel to represent scene
    public class FullSceneViewModel : SceneViewModel
    {
        private IEnumerable<LinkedImageViewModel> _images;
        private IEnumerable<LinkedCharacterViewModel> _characters;
        private IEnumerable<LinkedBreakdownItemViewModel> _breakdownItems;

        // Images linked to the scene
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

        // Characters linked to the scene
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

        // Breakdown items linked to the scene
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
    }
}