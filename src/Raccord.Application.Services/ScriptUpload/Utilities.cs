using System;

namespace Raccord.Application.Services.ScriptUpload
{
  // Helpers and extensions for script upload
  public static class Helpers
  {
    public static int ParsePageLength(this string pageLength)
    {
      int result = 0;

      var pageLengthArray = pageLength.Split(' ');
      result += ParseFraction(pageLengthArray[0]);
      if(pageLengthArray.Length>1)
      {
        var eights = pageLengthArray[1];
        result += ParseFraction(eights);
      }

      return result;
    }

    public static string GetSubstringBeforeSeparator(this string value, string separator)
    {
      var separatorPosition = value.IndexOf(separator);
      if(separatorPosition==-1) return string.Empty;
      return value.Substring(0, separatorPosition);
    }

    public static string GetSubstringAfterSeparator(this string value, string separator)
    {
      var separatorPosition = value.LastIndexOf(separator);
      if(separatorPosition==-1) return string.Empty;
      return value.Substring(separatorPosition + separator.Length, value.Length - separatorPosition - separator.Length);
    }

    public static string GetSubstringBetweenSeparators(this string value, string firstSeparator, string secondSeparator)
    {
      var firstSeparatorPosition = value.IndexOf(firstSeparator);
      if(firstSeparatorPosition==-1) return string.Empty;
      var secondSeparatorPosition = value.LastIndexOf(secondSeparator);
      if(secondSeparatorPosition==-1) return string.Empty;
      return value.Substring(firstSeparatorPosition + firstSeparator.Length, secondSeparatorPosition - firstSeparator.Length - firstSeparatorPosition);
    }

    private static int ParseFraction(string fraction)
    {
      var fractionArray = fraction.Split('/');
      if(fractionArray.Length>1)
      {
        return Convert.ToInt32(fractionArray[0]);
      }
      else
      {
        return Convert.ToInt32(fractionArray[0]) * 8;
      }
    }
  }
}