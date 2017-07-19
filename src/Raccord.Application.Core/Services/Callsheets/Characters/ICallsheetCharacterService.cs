namespace Raccord.Application.Core.Services.Callsheets.Characters
{
    public interface ICallsheetCharacterService
    {
        void SetCharacters(long callsheetID, long projectID);
    }
}