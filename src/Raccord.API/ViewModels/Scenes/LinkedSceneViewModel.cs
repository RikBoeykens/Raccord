using Raccord.API.ViewModels.Images;
using System.Collections.Generic;
namespace Raccord.API.ViewModels.Scenes
{
    // Viewmodel to represent scene linked to entity
    public class LinkedSceneViewModel : SceneViewModel
    {
        public long LinkID { get; set; }
    }
}