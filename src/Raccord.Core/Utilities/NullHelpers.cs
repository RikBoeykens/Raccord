namespace Raccord.Core.Utilities
{
  // Helpers for working with converting defaults to null values
  public static class NullHelpers
  {
    public static long? GetValueOrNull(this long value)
    {
      return value != default(long) ? value : (long?) null;
    }
  }
}