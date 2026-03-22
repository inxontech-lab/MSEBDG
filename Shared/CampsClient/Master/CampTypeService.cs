using Domain.CampsModels.RespDTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Shared.CampsClient.Master
{
    public class CampTypeService
    {
        private ServiceClient _serviceClient;
        private IConfiguration _configuration;
        private CampTypeListRespDTO _CampTypeListRespDTO;

        public CampTypeService(ServiceClient serviceClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceClient = serviceClient;
        }
        public async Task<CampTypeListRespDTO> GetCampTypeList()
        {
            _CampTypeListRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"CampType/GetCampTypeList");
            _CampTypeListRespDTO = JsonConvert.DeserializeObject<CampTypeListRespDTO>(retrunString);
            return _CampTypeListRespDTO;
        }
    }
}
