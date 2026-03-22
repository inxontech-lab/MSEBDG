using Domain.CampsModels.RespDTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Shared.CampsClient.Master
{
    public class SeCommitteeService
    {
        private ServiceClient _serviceClient;
        private IConfiguration _configuration;
        private SECommitteeRespDTO _SECommitteeRespDTO;
        public SeCommitteeService(ServiceClient serviceClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceClient = serviceClient;
        }

        public async Task<SECommitteeRespDTO> GetSeCommitteeList()
        {
            _SECommitteeRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"SeCommittee/GetSeCommitteeList");
            _SECommitteeRespDTO = JsonConvert.DeserializeObject<SECommitteeRespDTO>(retrunString);
            return _SECommitteeRespDTO;
        }
    }
}
