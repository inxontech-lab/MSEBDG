using Domain.CampsModels.RespDTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Shared.CampsClient.Master
{
    public class CampaignVolunteerProfileService
    {
        private readonly ServiceClient _serviceClient;
        private readonly IConfiguration _configuration;

        public CampaignVolunteerProfileService(ServiceClient serviceClient, IConfiguration configuration)
        {
            _serviceClient = serviceClient;
            _configuration = configuration;
        }

        public async Task<CampaignVolunteerProfileRespDTO> GetVolunteerProfileAsync(int volunteerId)
        {
            var baseAddress = _configuration["ApiEndpoints:BaseAddress"];

            var returnString = await _serviceClient.clientMethod($"{baseAddress}VolunteerProfile/GetVolunteerProfile/{volunteerId}");
            return JsonConvert.DeserializeObject<CampaignVolunteerProfileRespDTO>(returnString) ?? new CampaignVolunteerProfileRespDTO();
        }
    }
}
