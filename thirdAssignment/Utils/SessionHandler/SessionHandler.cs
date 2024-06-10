using Newtonsoft.Json;

namespace thirdAssignment.Presentation.Utils.SessionHandler
{
    public static class SessionHandler
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T Get<T>(this ISession session, string key)
        {
            string value = session.GetString(key);

            return value == null ? default : JsonConvert.DeserializeObject<T>(value); 
        }
    }
}
