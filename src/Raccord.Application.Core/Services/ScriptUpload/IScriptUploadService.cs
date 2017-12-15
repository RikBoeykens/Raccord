namespace Raccord.Application.Core.Services.ScriptUpload
{
  public interface IScriptUploadService
  {
    ScriptUploadResponseDto UploadScript(ScriptUploadRequestDto request);
  }
}