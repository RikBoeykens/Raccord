using System;
using System.Linq;
using Raccord.Application.Core.Services.ScriptUploads;
using Raccord.Application.Services.Characters;
using Raccord.Application.Services.Scenes;
using Raccord.Application.Services.ScriptLocations;
using Raccord.Domain.Model.ScriptUploads;

namespace Raccord.Application.Services.ScriptUploads
{
  // Helpers and extensions for script upload
  public static class Utilities
  {
    public static FullScriptUploadDto TranslateFull(this ScriptUpload scriptUpload)
    {
      return new FullScriptUploadDto
      {
        ID = scriptUpload.ID,
        FileName = scriptUpload.FileName,
        Start = scriptUpload.Start,
        End = scriptUpload.End,
        Scenes = scriptUpload.Scenes.OrderBy(s=> s.SortingOrder).Select(s=> s.Translate()),
        Characters = scriptUpload.Characters.Select(c=> c.Translate()),
        ScriptLocations = scriptUpload.ScriptLocations.Select(sl=> sl.Translate()),
      };
    }

    public static int ParsePageLength(this string pageLength)
    {
      int result = 0;
      if(string.IsNullOrEmpty(pageLength))
      {
        return result;
      }

      var pageLengthArray = pageLength.Split(' ');
      result += ParseFraction(pageLengthArray[0]);
      if(pageLengthArray.Length>1)
      {
        var eights = pageLengthArray[1];
        result += ParseFraction(eights);
      }

      return result;
    }

    public static bool HasSeparators(this string value, string firstSeparator, string secondSeparator)
    {
      var firstSeparatorPosition = value.IndexOf(firstSeparator);
      var secondSeparatorPosition = value.LastIndexOf(secondSeparator);

      return firstSeparatorPosition !=-1 && secondSeparatorPosition != -1;
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