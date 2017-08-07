using System;
using Raccord.Application.Core.Services.Shots.Slates;

namespace Raccord.Application.Core.Services.Shots.Takes
{
    public class TakeDto
    {
        private SlateDto _slate;
        
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
        public SlateDto Slate
        {
            get
            {
                return _slate ?? (_slate = new SlateDto());
            }
            set
            {
                _slate = value;
            }
        }
    }
}