using System.IO;

namespace Raccord.Application.Core.Services.ScriptUpload
{
  public class ScriptUploadRequestDto
  {
    // File Content
    public Stream FileContent { get; set; }

    // ID of the linked project
    public long ProjectID { get; set; }
  }
}