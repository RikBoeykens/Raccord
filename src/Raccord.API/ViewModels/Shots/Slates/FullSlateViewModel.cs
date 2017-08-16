using System.Collections.Generic;
using Raccord.API.ViewModels.Images;
using Raccord.API.ViewModels.Shots.Takes;

namespace Raccord.API.ViewModels.Shots.Slates
{
    public class FullSlateViewModel : SlateViewModel
    {
        private IEnumerable<TakeViewModel> _takes;
        private IEnumerable<LinkedImageViewModel> _images;

        public IEnumerable<TakeViewModel> Takes
        {
            get
            {
                return _takes ?? (_takes = new List<TakeViewModel>());
            }
            set
            {
                _takes = value;
            }
        }

        // Images linked to the slate
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