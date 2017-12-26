using System.IO;

namespace Raccord.Application.Core.Services.ScriptUploads
{
  public class ScriptUploadRequestDto
  {
    // File Content
    public Stream FileContent { get; set; }

    // File name
    public string FileName { get; set; }

    // ID of the linked project
    public long ProjectID { get; set; }
  }
}