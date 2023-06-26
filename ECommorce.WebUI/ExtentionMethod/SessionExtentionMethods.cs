using Newtonsoft.Json;

namespace ECommorce.WebUI.ExtentionMethod
{
	public static class SessionExtentionMethods
	{
		public static void SetObject(this ISession session, string key, object value)
		{
			string objString = JsonConvert.SerializeObject(value);
			session.SetString(key, objString);
		}

		public static T GetObject<T>(this ISession session, string key) where T : class
		{
			string objString = session.GetString(key);
			if (string.IsNullOrEmpty(objString))
			{
				return null;
			}
			T result = JsonConvert.DeserializeObject<T>(objString);
			return result;
		}
	}
}
