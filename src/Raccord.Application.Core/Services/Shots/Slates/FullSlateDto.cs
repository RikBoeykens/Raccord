using System.Collections.Generic;
using Raccord.Application.Core.Services.Shots.Takes;

namespace Raccord.Application.Core.Services.Shots.Slates
{
    public class FullSlateDto : SlateDto
    {
        private IEnumerable<TakeDto> _takes;

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
    }
}