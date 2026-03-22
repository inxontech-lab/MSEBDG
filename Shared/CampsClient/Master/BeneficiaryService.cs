using System.Net.Http.Json;
using System.Text;
using Domain.CampsModels.ReqDTO;
using Domain.CampsModels.RespDTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Shared.CampsClient.Master
{
    public class BeneficiaryService
    {
        private ServiceClient _serviceClient;
        private IConfiguration _configuration;
        private CommonRespDTO _CommonRespDTO;
        private BeneficiaryInfoRespDTO _BeneficiaryInfoRespDTO;
        public BeneficiaryService(ServiceClient serviceClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceClient = serviceClient;
        }
        public async Task<CommonRespDTO> SaveBeneficiaryDetailsAsync(BeneficiaryDetailsReqDTO req)
        {
            _CommonRespDTO = new();
            var httpClient = new HttpClient();
            HttpContent content = new StringContent(req.ToString(), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsJsonAsync(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Beneficiary/SaveBeneficiaryDetailsAsync", req).Result;
            _CommonRespDTO = JsonConvert.DeserializeObject<CommonRespDTO>(response.Content.ReadAsStringAsync().Result);
            return _CommonRespDTO;
        }

        public async Task<BeneficiaryInfoRespDTO> GetBeneficiaryByMobile(string MobileNumber)
        {
            _BeneficiaryInfoRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Beneficiary/GetBeneficiaryByMobile/{MobileNumber}");
            _BeneficiaryInfoRespDTO = JsonConvert.DeserializeObject<BeneficiaryInfoRespDTO>(retrunString);
            return _BeneficiaryInfoRespDTO;
        }

        public async Task<CommonRespDTO> UpdateBloodGroupByMobile(int? BloodGroup, string MobileNumber)
        {
            _CommonRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Beneficiary/UpdateBloodGroupByMobile/{BloodGroup}/{MobileNumber}");
            _CommonRespDTO = JsonConvert.DeserializeObject<CommonRespDTO>(retrunString);
            return _CommonRespDTO;
        }
    }
}
