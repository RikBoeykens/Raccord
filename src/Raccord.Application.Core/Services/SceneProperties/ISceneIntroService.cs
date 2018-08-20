namespace Raccord.Application.Core.Services.SceneProperties
{
    // Interface for int/ext functionality
    public interface ISceneIntroService : IService<SceneIntroDto, SceneIntroSummaryDto, FullSceneIntroDto>, IAllForParentService<SceneIntroSummaryDto>
    {
        void Merge(long toID, long mergeID);
    }
}