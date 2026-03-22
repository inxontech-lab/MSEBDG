using Domain.CampsModels.RespDTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Shared.CampsClient.Master
{
    public class CountryService
    {
        private ServiceClient _serviceClient;
        private IConfiguration _configuration;
        private CountryListRespDTO _CountryListRespDTO;

        public CountryService(ServiceClient serviceClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceClient = serviceClient;
        }
        public async Task<CountryListRespDTO> GetCountryList()
        {
            _CountryListRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Country/GetCountryList");
            _CountryListRespDTO = JsonConvert.DeserializeObject<CountryListRespDTO>(retrunString);
            return _CountryListRespDTO;
        }
    }
}
