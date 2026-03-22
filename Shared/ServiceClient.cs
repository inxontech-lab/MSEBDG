using System.Net;
using Microsoft.Extensions.Configuration;

namespace Shared
{
    public class ServiceClient
    {
        private readonly IConfiguration _configuration;
        public ServiceClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> clientMethod(string serviceURL)
        {
            string retrunString = null;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(serviceURL),
            };
            //request.Headers.Add("x-api-key", _configuration.GetSection("auth").GetSection("x-api-key").Value);

            using (var httpClient = new HttpClient(
                new HttpClientHandler()
                {
                    AutomaticDecompression = System.Net.DecompressionMethods.GZip,
                    Proxy = new WebProxy()
                    {
                        BypassProxyOnLocal = true
                    }
                }

            ))
            {
                using (var response = await httpClient.SendAsync(request))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        retrunString = apiResponse;
                    }
                    catch (Exception ex)
                    {
                        retrunString = null;
                    }
                }
            }
            return retrunString;
        }

        public async Task<string> PutClientMethod(string serviceURL, Object obj)
        {
            string retrunString = null;
            HttpClient client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Post,
            //    RequestUri = new Uri(serviceURL),
            //};

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync(serviceURL, (HttpContent?)obj))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync(); ;
                    try
                    {
                        retrunString = apiResponse;
                    }
                    catch (Exception ex)
                    {
                        retrunString = null;
                    }
                }


            }
            return retrunString;
        }
    }
}
