using Domain.CampsModels.RespDTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Shared.CampsClient.Master
{
    public class GneralHealthQuestionService
    {
        private ServiceClient _serviceClient;
        private IConfiguration _configuration;
        private GeneralHealthQuestionRespDTO _GeneralHealthQuestionRespDTO;
        public GneralHealthQuestionService(ServiceClient serviceClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceClient = serviceClient;
        }

        public async Task<GeneralHealthQuestionRespDTO> GetGeneralHealtQuestions()
        {
            _GeneralHealthQuestionRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"GeneralHealthQuest/GetGeneralHealtQuestions");
            _GeneralHealthQuestionRespDTO = JsonConvert.DeserializeObject<GeneralHealthQuestionRespDTO>(retrunString);
            return _GeneralHealthQuestionRespDTO;
        }
    }
}
