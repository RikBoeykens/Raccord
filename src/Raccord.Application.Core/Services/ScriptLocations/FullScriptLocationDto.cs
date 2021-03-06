using Raccord.Application.Core.Services.Scenes;
using Raccord.Application.Core.Services.Images;
using System.Collections.Generic;
using Raccord.Application.Core.Services.Locations.LocationSets;
using Raccord.Application.Core.Services.Comments;

namespace Raccord.Application.Core.Services.ScriptLocations
{
    // Dto to represent a full location
    public class FullScriptLocationDto: ScriptLocationDto
    {
        private IEnumerable<SceneSummaryDto> _scenes;
        private IEnumerable<LinkedImageDto> _images;
        private IEnumerable<LocationSetLocationDto> _sets;
        private IEnumerable<CommentDto> _comments;

        // Scenes linked to the location
        public IEnumerable<SceneSummaryDto> Scenes
        {
            get
            {
                return _scenes ?? (_scenes = new List<SceneSummaryDto>());
            }
            set
            {
                _scenes = value;
            }
        }

        // Images linked to the location
        public IEnumerable<LinkedImageDto> Images
        {
            get
            {
                return _images ?? (_images = new List<LinkedImageDto>());
            }
            set
            {
                _images = value;
            }
        }

        // Sets linked to the location
        public IEnumerable<LocationSetLocationDto> Sets
        {
            get
            {
                return _sets ?? (_sets = new List<LocationSetLocationDto>());
            }
            set
            {
                _sets = value;
            }
        }

        // Comments linked to the breakdown item
        public IEnumerable<CommentDto> Comments
        {
            get
            {
                return _comments ?? (_comments = new List<CommentDto>());
            }
            set
            {
                _comments = value;
            }
        }
    }
}