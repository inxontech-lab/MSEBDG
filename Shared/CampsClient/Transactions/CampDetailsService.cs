using Domain.CampsModels.DBModels;
using Domain.CampsModels.ReqDTO;
using Domain.CampsModels.RespDTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Shared.CampsClient.Transactions
{
    public class CampDetailsService
    {
        private ServiceClient _serviceClient;
        private IConfiguration _configuration;
        private CampDetailsRespDTO _CampDetailsRespDTO;

        public CampDetailsService(ServiceClient serviceClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceClient = serviceClient;
        }

        public async Task<CampDetailsRespDTO> GetCampDetailsList(CampDetailsReqDTO req)
        {
            _CampDetailsRespDTO = new();
            var httpClient = new HttpClient();
            HttpContent content = new StringContent(req.ToString(), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsJsonAsync(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Camp/GetCampDetailsList", req).Result;
            _CampDetailsRespDTO = JsonConvert.DeserializeObject<CampDetailsRespDTO>(response.Content.ReadAsStringAsync().Result);
            return _CampDetailsRespDTO;
        }

        public async Task<CampDetailsRespDTO> GetAllCampDetailsList()
        {
            _CampDetailsRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Camp/GetAllCampDetailsList");
            _CampDetailsRespDTO = JsonConvert.DeserializeObject<CampDetailsRespDTO>(retrunString);
            return _CampDetailsRespDTO;
        }

        public async Task<CampDetailsRespDTO> SaveCampDetailsAsync(CampDetail req)
        {
            _CampDetailsRespDTO = new();

            if (req.CampNameEn==null || req.CampNameEn.Equals(""))
            {
                req.CampNameEn = "Camp";
            }

            if (req.CampLocationEn == null || req.CampLocationEn.Equals(""))
            {
                req.CampLocationEn = "Camp Location";
            }
            

            var baseUrl = _configuration.GetSection("ApiEndpoints:BaseAddress").Value;

            using var httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };

            var response = await httpClient.PostAsJsonAsync("Camp/SaveCampDetailsAsync", req);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            }

            _CampDetailsRespDTO = await response.Content.ReadFromJsonAsync<CampDetailsRespDTO>();



            //var httpClient = new HttpClient();
            //HttpContent content = new StringContent(req.ToString(), Encoding.UTF8, "application/json");
            //var response = httpClient.PostAsJsonAsync(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Camp/SaveCampDetailsAsync", req).Result;
            //_CampDetailsRespDTO = JsonConvert.DeserializeObject<CampDetailsRespDTO>(response.Content.ReadAsStringAsync().Result);
            return _CampDetailsRespDTO;
        }

        public async Task<CampDetailsRespDTO> UpdateCampDetailsAsync(CampDetail req)
        {
            _CampDetailsRespDTO = new();

            if (req.CampNameEn == null || req.CampNameEn.Equals(""))
            {
                req.CampNameEn = "Camp";
            }

            if (req.CampLocationEn == null || req.CampLocationEn.Equals(""))
            {
                req.CampLocationEn = "Camp Location";
            }


            var baseUrl = _configuration.GetSection("ApiEndpoints:BaseAddress").Value;

            using var httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };

            var response = await httpClient.PostAsJsonAsync("Camp/UpdateCampDetailsAsync", req);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            }

            _CampDetailsRespDTO = await response.Content.ReadFromJsonAsync<CampDetailsRespDTO>();
            return _CampDetailsRespDTO;
        }
    }
}
