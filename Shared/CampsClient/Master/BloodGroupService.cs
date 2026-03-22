using Domain.CampsModels.RespDTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Shared.CampsClient.Master
{
    public class BloodGroupService
    {
        private ServiceClient _serviceClient;
        private IConfiguration _configuration;
        private BloodGroupListRespDTO _BloodGroupListRespDTO;
        public BloodGroupService(ServiceClient serviceClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceClient = serviceClient;
        }

        public async Task<BloodGroupListRespDTO> GetBloodGroupList()
        {
            _BloodGroupListRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"BloodGroup/GetBloodGroupList");
            _BloodGroupListRespDTO = JsonConvert.DeserializeObject<BloodGroupListRespDTO>(retrunString);
            return _BloodGroupListRespDTO;
        }
    }
}
