namespace Raccord.Application.Core.Services.Shots.Slates
{
    // Interface for slate functionality
    public interface ISlateService : IService<SlateDto, SlateSummaryDto, FullSlateDto>, IAllForParentService<SlateSummaryDto>
    {
    }
}