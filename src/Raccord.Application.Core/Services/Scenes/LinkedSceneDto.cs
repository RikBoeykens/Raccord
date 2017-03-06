using Raccord.Application.Core.Services.Images;

namespace Raccord.Application.Core.Services.Scenes
{
    // Dto to represent a scene linked to something
    public class LinkedSceneDto : SceneSummaryDto
    {
        // ID of the link
        public long LinkID { get; set; }
    }
}