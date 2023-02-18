using Microsoft.AspNetCore.Http;
//using Newtonsoft.Json;
using System.Text.Json;

namespace QuachHengToniRazorPages.Helpers
{
    public static class SessionHelper
    {
        //public static void SetObjectAsJson(this ISession session, string key, object value)
        //{
        //    session.SetString(key, JsonConvert.SerializeObject(value));
        //}

        //public static T GetObjectFromJson<T>(this ISession session, string key)
        //{
        //    var value = session.GetString(key);
        //    return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        //}

        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }

        public static bool IsSignedIn(HttpContext httpContext)
        {
            if (httpContext.Session.GetString("Email") == null)
            {
                return false;
            }

            return true;
        }
    }
}
