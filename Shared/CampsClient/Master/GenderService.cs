using Domain.CampsModels.RespDTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Shared.CampsClient.Master
{
    public class GenderService
    {
        private ServiceClient _serviceClient;
        private IConfiguration _configuration;
        private GenderListRespDTO _GenderListRespDTO;
        public GenderService(ServiceClient serviceClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceClient = serviceClient;
        }

        public async Task<GenderListRespDTO> GetGenderList()
        {
            _GenderListRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Gender/GetGenderList");
            _GenderListRespDTO = JsonConvert.DeserializeObject<GenderListRespDTO>(retrunString);
            return _GenderListRespDTO;
        }
    }
}
