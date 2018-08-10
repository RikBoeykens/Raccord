using System.Collections.Generic;
using Raccord.API.ViewModels.Characters;
using Raccord.API.ViewModels.Comments;
using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Scheduling.ScheduleDays;
using Raccord.API.ViewModels.ShootingDays;
using Raccord.Application.Core.Services.Comments;

namespace Raccord.API.ViewModels.Locations.LocationSets
{
    // Vm to represent a full location set
    public class FullLocationSetViewModel : LocationSetSummaryViewModel
    {
        private IEnumerable<ShootingDayInfoSceneCollectionViewModel> _shootingDays;
        private IEnumerable<CommentViewModel> _comments;

        // Schedule scenes linked to the location set
        public IEnumerable<ShootingDayInfoSceneCollectionViewModel> ShootingDays
        {
            get
            {
                return _shootingDays ?? (_shootingDays = new List<ShootingDayInfoSceneCollectionViewModel>());
            }
            set
            {
                _shootingDays = value;
            }
        }

        // Schedule scenes linked to the location set
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