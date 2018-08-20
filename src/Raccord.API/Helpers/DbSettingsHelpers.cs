using System.Linq;

namespace Raccord.UI.Helpers
{
  public static class DbSettingsHelpers
  {
    public static string GetConnectionString(string connectionUri)
    {
      connectionUri.Replace("//", "");

      char[] delimiterChars = { '/', ':', '@', '?' };
      string[] strConn = connectionUri.Split(delimiterChars);
      strConn = strConn.Where(x => !string.IsNullOrEmpty(x)).ToArray();

      var user = strConn[1];
      var pass = strConn[2];
      var server = strConn[3];
      var database = strConn[5];
      var port = strConn[4];
      return $"host={server};port={port};database={database};uid={user};pwd={pass};sslmode=Require;Trust Server Certificate=true;Timeout=1000";
    }
  }
}