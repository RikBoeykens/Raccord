using System.Collections.Generic;
using Raccord.Application.Core.Services.Comments;
using Raccord.Application.Core.Services.Images;
using Raccord.Application.Core.Services.Shots.Takes;

namespace Raccord.Application.Core.Services.Shots.Slates
{
    public class FullSlateDto : SlateDto
    {
        private IEnumerable<TakeDto> _takes;
        private IEnumerable<LinkedImageDto> _images;
        private IEnumerable<CommentDto> _comments;

        public IEnumerable<TakeDto> Takes
        {
            get
            {
                return _takes ?? (_takes = new List<TakeDto>());
            }
            set
            {
                _takes = value;
            }
        }
        // Images linked to the slate
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
        // Images linked to the slate
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