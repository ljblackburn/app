using System;

namespace app
{
  public static class BlockExtensions
  {
    public static Func<T> cache_result<T>(this Func<T> original_target)
    {
      return original_target;
    }
  }
  public class BlockCandy
  {
    public static Func<T> to_run<T>(Func<T> target)
    {
      return target;
    }
  }
}