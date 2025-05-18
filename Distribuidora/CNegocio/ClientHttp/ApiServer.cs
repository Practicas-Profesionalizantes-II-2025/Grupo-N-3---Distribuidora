using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNegocio.Helper;

namespace CNegocio.ClientHttp
{
    internal static class ApiServer
    {
        public static HttpClient ObtenerClientHttp()
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.Timeout = TimeSpan.FromSeconds(15);

            return _client;
        }

        internal static string ObtenerUrlEndPoint(string Path)
        {
            string url = ApplicationConfiguration.GetSetting("ApiServer:BaseURL") + Path;
            return url;
        }
    }

}
