using Raccord.API.ViewModels.Scenes;
using Raccord.API.ViewModels.Images;
using System.Collections.Generic;
using Raccord.API.ViewModels.Breakdowns.BreakdownTypes;
using Raccord.API.ViewModels.Comments;

namespace Raccord.API.ViewModels.Breakdowns.BreakdownItems
{
    // ViewModel to represent a breakdown items
    public class FullBreakdownItemViewModel : BaseBreakdownItemViewModel
    {
        private BreakdownSummaryViewModel _breakdown;
        private BreakdownTypeViewModel _type;
        private IEnumerable<LinkedSceneViewModel> _scenes;
        private IEnumerable<LinkedImageViewModel> _images;
        private IEnumerable<CommentViewModel> _comments;

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

        /// <summary>
        /// Breakdown linked to the item
        /// </summary>
        /// <returns></returns>
        public BreakdownSummaryViewModel Breakdown
        {
            get
            {
                return _breakdown ?? (_breakdown = new BreakdownSummaryViewModel());
            }
            set
            {
                _breakdown = value;
            }
        }

        /// <summary>
        /// Breakdown type linked to the item
        /// </summary>
        /// <returns></returns>
        public BreakdownTypeViewModel Type
        {
            get
            {
                return _type ?? (_type = new BreakdownTypeViewModel());
            }
            set
            {
                _type = value;
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