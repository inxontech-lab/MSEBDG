using Domain.CampsModels.RespDTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Shared.CampsClient.Master
{
    public class MedicalConditionService
    {
        private ServiceClient _serviceClient;
        private IConfiguration _configuration;
        private MedicalConsitonListRespDTO _MedicalConsitonListRespDTO;
        public MedicalConditionService(ServiceClient serviceClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceClient = serviceClient;
        }

        public async Task<MedicalConsitonListRespDTO> GetMedicalConditonList()
        {
            _MedicalConsitonListRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"MedicalCondition/GetMedicalConditonList");
            _MedicalConsitonListRespDTO = JsonConvert.DeserializeObject<MedicalConsitonListRespDTO>(retrunString);
            return _MedicalConsitonListRespDTO;
        }
    }
}
