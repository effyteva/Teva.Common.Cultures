using System;
using System.Collections.Generic;
using System.Text;

namespace Teva.Common.Cultures
{
    public static class CultureJsonBuilder
    {
        public static void ExportCultures()
        {
            foreach (var Culture in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures))
            {
                if (!string.IsNullOrEmpty(Culture.Name))
                    ExportCulture(Culture);
            }
        }
        static void ExportCulture(System.Globalization.CultureInfo Culture)
        {
            var Details = new SerializedCulture
            {
                NumberFormatInfo = Culture.NumberFormat,
                DateTimeFormatInfo = Culture.DateTimeFormat,
            };
            var JSON = Newtonsoft.Json.JsonConvert.SerializeObject(Details, Newtonsoft.Json.Formatting.None);
            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(System.AppContext.BaseDirectory, "cultures"));
            System.IO.File.WriteAllText(System.IO.Path.Combine(System.AppContext.BaseDirectory, "cultures", Culture.Name + ".json"), JSON, System.Text.Encoding.UTF32);
        }
    }
}
