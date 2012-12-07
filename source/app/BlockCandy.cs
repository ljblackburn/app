using System;

namespace app
{
  public static class BlockExtensions
  {
    public static Func<TResult> cache_result<TResult>(this Func<TResult> original_target)
    {
      var is_in_cache = false;
      var cached_value = default(TResult);

      return () =>
      {
        if (is_in_cache) return cached_value;
        is_in_cache = true;
        cached_value = original_target();

        return cached_value;
      };
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