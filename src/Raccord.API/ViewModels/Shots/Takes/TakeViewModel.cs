using System;
using Raccord.API.ViewModels.Shots.Slates;

namespace Raccord.API.ViewModels.Shots.Takes
{
    public class TakeViewModel
    {
        private SlateViewModel _slate;
        
        // ID of the take
        public long ID { get; set; }

        // Number of the take
        public string Number { get; set; }

        // Notes about the take
        public string Notes { get; set; }

        // Length
        public TimeSpan Length { get; set; }

        // Specifies if the take is selected
        public bool Selected { get; set; }

        // Camera roll the take is on
        public string CameraRoll { get; set; }

        // Sound roll the take is on
        public string SoundRoll { get; set; }

        // Associated slate
        public SlateViewModel Slate
        {
            get
            {
                return _slate ?? (_slate = new SlateViewModel());
            }
            set
            {
                _slate = value;
            }
        }
    }
}