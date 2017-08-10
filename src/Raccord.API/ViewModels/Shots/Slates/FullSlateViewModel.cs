using System.Collections.Generic;
using Raccord.API.ViewModels.Shots.Takes;

namespace Raccord.API.ViewModels.Shots.Slates
{
    public class FullSlateViewModel : SlateViewModel
    {
        private IEnumerable<TakeViewModel> _takes;

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
    }
}