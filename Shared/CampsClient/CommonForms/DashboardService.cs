using Domain.CampsModels.DTOs;
using Domain.CampsModels.ReqDTO;
using Domain.CampsModels.RespDTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Shared;
using System.Net.Http.Json;
using System.Text;

namespace Shared.CampsClient.CommonForms
{
    public class DashboardService
    {
        private ServiceClient _serviceClient;
        private IConfiguration _configuration;
        private DashboardResultGrouping _DashboardResultGrouping;
        public DashboardService(ServiceClient serviceClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceClient = serviceClient;
        }

        public async Task<DashboardResultGrouping> GetDasboardForGrouping(GroupingDashboardReqDTO req)
        {
            _DashboardResultGrouping = new();
            var httpClient = new HttpClient();
            HttpContent content = new StringContent(req.ToString(), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsJsonAsync(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"GroupingDashboard/GroupingCamp/GetDasboardForGrouping", req).Result;
            _DashboardResultGrouping = JsonConvert.DeserializeObject<DashboardResultGrouping>(response.Content.ReadAsStringAsync().Result);
            return _DashboardResultGrouping;
        }
    }
}
