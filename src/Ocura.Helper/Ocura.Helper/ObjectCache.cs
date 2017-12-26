using System;
using System.Web;

namespace Ocura.Helper
{
    public static class ObjectCache
    {
    /// <summary>
    /// Set any object in cache
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="cacheItemName"></param>
    /// <param name="cacheTimeInSeconds"></param>
    /// <param name="item"></param>
    /// <returns></returns>
      public static T SetObjectFromCache<T>(string cacheItemName, int cacheTimeInSeconds, object item)
      {
        T cachedObject = (T)HttpContext.Current.Cache[cacheItemName];
        if (cachedObject == null)
        {
          HttpContext.Current.Cache[cacheItemName] = item;
          HttpContext.Current.Cache.Insert(cacheItemName
              , item
              , null
              , DateTime.Now.AddSeconds(cacheTimeInSeconds)
              , System.Web.Caching.Cache.NoSlidingExpiration);

          cachedObject = (T)item;
        }
        return cachedObject;
      }
  }
}
