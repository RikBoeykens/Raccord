using System;

namespace Raccord.Domain.Model.Shots
{
    public class Take : Entity<long>
    {
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

        // Sorting order
        public int? SortingOrder { get; set; }

        // ID of the parent slate
        public long SlateID { get; set; }

        // Parent slate
        public Slate Slate { get; set; }
    }
}