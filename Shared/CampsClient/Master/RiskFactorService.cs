using Domain.CampsModels.RespDTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Shared.CampsClient.Master
{
    public class RiskFactorService
    {
        private ServiceClient _serviceClient;
        private IConfiguration _configuration;
        private RiskFactorQuestRespDTO _RiskFactorQuestRespDTO;
        public RiskFactorService(ServiceClient serviceClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceClient = serviceClient;
        }

        public async Task<RiskFactorQuestRespDTO> GetRiskFactQuestions()
        {
            _RiskFactorQuestRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"RiskFactor/GetRiskFactQuestions");
            _RiskFactorQuestRespDTO = JsonConvert.DeserializeObject<RiskFactorQuestRespDTO>(retrunString);
            return _RiskFactorQuestRespDTO;
        }
    }
}
