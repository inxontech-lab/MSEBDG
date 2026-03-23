using System.Net.Http.Json;
using Domain.CampsModels.DBModels;
using Domain.CampsModels.RespDTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Shared.CampsClient.Master
{
    public class CampaignVolunteerService
    {
        private readonly ServiceClient _serviceClient;
        private readonly IConfiguration _configuration;

        public CampaignVolunteerService(ServiceClient serviceClient, IConfiguration configuration)
        {
            _serviceClient = serviceClient;
            _configuration = configuration;
        }

        public async Task<CampaignVolunteerListRespDTO> GetCampaignVolunteerListAsync(bool activeOnly = false)
        {
            var returnString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints:BaseAddress").Value + $"CampaignVolunteer/GetCampaignVolunteerList/{activeOnly}");
            return JsonConvert.DeserializeObject<CampaignVolunteerListRespDTO>(returnString) ?? new CampaignVolunteerListRespDTO();
        }

        public async Task<CampaignVolunteerRespDTO> GetCampaignVolunteerByIdAsync(int volunteerId)
        {
            var returnString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints:BaseAddress").Value + $"CampaignVolunteer/GetCampaignVolunteerById/{volunteerId}");
            return JsonConvert.DeserializeObject<CampaignVolunteerRespDTO>(returnString) ?? new CampaignVolunteerRespDTO();
        }

        public async Task<CampaignVolunteerListRespDTO> SaveCampaignVolunteerAsync(CampaignVolunteer volunteer)
        {
            using var httpClient = new HttpClient { BaseAddress = new Uri(_configuration.GetSection("ApiEndpoints:BaseAddress").Value!) };
            var response = await httpClient.PostAsJsonAsync("CampaignVolunteer/SaveCampaignVolunteerAsync", volunteer);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CampaignVolunteerListRespDTO>() ?? new CampaignVolunteerListRespDTO();
        }

        public async Task<CampaignVolunteerListRespDTO> UpdateCampaignVolunteerAsync(CampaignVolunteer volunteer)
        {
            using var httpClient = new HttpClient { BaseAddress = new Uri(_configuration.GetSection("ApiEndpoints:BaseAddress").Value!) };
            var response = await httpClient.PostAsJsonAsync("CampaignVolunteer/UpdateCampaignVolunteerAsync", volunteer);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CampaignVolunteerListRespDTO>() ?? new CampaignVolunteerListRespDTO();
        }

        public async Task<CampaignVolunteerListRespDTO> DeleteCampaignVolunteerAsync(int volunteerId)
        {
            using var httpClient = new HttpClient { BaseAddress = new Uri(_configuration.GetSection("ApiEndpoints:BaseAddress").Value!) };
            var response = await httpClient.DeleteAsync($"CampaignVolunteer/DeleteCampaignVolunteerAsync/{volunteerId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CampaignVolunteerListRespDTO>() ?? new CampaignVolunteerListRespDTO();
        }
    }
}
