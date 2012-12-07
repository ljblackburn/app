using System;
using System.Security;

namespace app.web.core
{
  public interface ISupportAUserFeature
  {
    void process(IContainRequestDetails request);
  }

  public interface IAddBehaviourToAnInvocation
  {
    void enrich(IRepresentAMethodInvocation method);
  }

  public interface IRepresentAMethodInvocation
  {
    void proceed();
    void swap_result_with(object get_cached_result_for);
  }

  public interface ICacheValues
  {
    bool contains_cache_result_for(IRepresentAMethodInvocation method);
    object get_cached_result_for(IRepresentAMethodInvocation method);
  }

  public class SecuredFeature : IAddBehaviourToAnInvocation
  {
    Func<bool> contraint;

    public SecuredFeature(Func<bool> contraint)
    {
      this.contraint = contraint;
    }

    public void enrich(IRepresentAMethodInvocation method)
    {
      if (contraint()) method.proceed();
      throw new SecurityException();
    }
  }

  public class CachedFeature : IAddBehaviourToAnInvocation
  {
    ICacheValues cache;

    public CachedFeature(ICacheValues cache)
    {
      this.cache = cache;
    }

    public void enrich(IRepresentAMethodInvocation method)
    {
      if (cache.contains_cache_result_for(method)) method.swap_result_with(cache.get_cached_result_for(method));
    }
  }

  public class TimedFeature : IAddBehaviourToAnInvocation
  {
    public void enrich(IRepresentAMethodInvocation method)
    {
      //start timer
      method.proceed();
      //stop timer
    }
  }
}