namespace Raccord.Application.Core.Services.ScriptUploads
{
  public interface IScriptUploadService
  {
    FullScriptUploadDto Get(long ID);
    long UploadScript(ScriptUploadRequestDto request);
  }
}