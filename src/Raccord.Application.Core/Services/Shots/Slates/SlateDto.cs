using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.ShootingDays;

namespace Raccord.Application.Core.Services.Shots.Slates
{
    public class SlateDto
    {
        private ShootingDayDto _shootingDay;
        private SceneDto _scene;
        
        public long ID { get; set; }

        // Number of the shot
        public string Number { get; set; }

        // Desciption of the shot
        public string Description { get; set; }

        // Lens used
        public string Lens { get; set; }

        // Distance used
        public string Distance { get; set; }

        // Aperture used
        public string Aperture { get; set; }

        // Filters used
        public string Filters { get; set; }

        // Sound used
        public string Sound { get; set; }

        // Indicates if the slate is a vfx slate
        public bool IsVfx { get; set; }

        // Project ID
        public long ProjectID { get; set; }

        // Shooting day linked to slate
        public ShootingDayDto ShootingDay
        {
            get
            {
                return _shootingDay ?? (_shootingDay = new ShootingDayDto());
            }
            set
            {
                _shootingDay = value;
            }
        }

        // Shooting day linked to slate
        public SceneDto Scene
        {
            get
            {
                return _scene ?? (_scene = new SceneDto());
            }
            set
            {
                _scene = value;
            }
        }
    }
}