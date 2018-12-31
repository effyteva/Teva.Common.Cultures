using System;
using System.Collections.Generic;
using System.Text;

namespace Teva.Common.Cultures
{
    public static class CultureHelper
    {
        public static System.Globalization.CultureInfo GetCulture(string CultureName)
        {
            return CachedCultures.GetOrAdd(CultureName, GetCultureUncached);
        }
        private static System.Globalization.CultureInfo GetCultureUncached(string CultureName)
        {
            var SerializedCulture = GetSerializedCulture(CultureName);
            var ToReturn = (System.Globalization.CultureInfo)new System.Globalization.CultureInfo(CultureName).Clone();
            if (SerializedCulture != null)
            {
                ToReturn.NumberFormat = SerializedCulture.NumberFormatInfo;
                ToReturn.DateTimeFormat = SerializedCulture.DateTimeFormatInfo;
            }
            return ToReturn;
        }
        private static SerializedCulture GetSerializedCulture(string CultureName)
        {
            var Serialized = new Newtonsoft.Json.JsonSerializer();
            using (var Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Teva.Common.Cultures.cultures." + CultureName.ToLower() + ".json"))
            {
                if (Stream == null)
                    return null;
                using (var StreamReader = new System.IO.StreamReader(Stream, System.Text.Encoding.UTF32))
                using (var JsonTextReader = new Newtonsoft.Json.JsonTextReader(StreamReader))
                {
                    return Serialized.Deserialize<SerializedCulture>(JsonTextReader);
                }
            }
        }
        public static void ClearCache()
        {
            CachedCultures.Clear();
        }
        private static readonly System.Collections.Concurrent.ConcurrentDictionary<string, System.Globalization.CultureInfo> CachedCultures = new System.Collections.Concurrent.ConcurrentDictionary<string, System.Globalization.CultureInfo>();
    }
}
