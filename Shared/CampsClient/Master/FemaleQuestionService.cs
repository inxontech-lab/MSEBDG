using Domain.CampsModels.RespDTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Shared.CampsClient.Master
{
    public class FemaleQuestionService
    {
        private ServiceClient _serviceClient;
        private IConfiguration _configuration;
        private FemaleQuestionsRespDTO _FemaleQuestionsRespDTO;

        public FemaleQuestionService(ServiceClient serviceClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceClient = serviceClient;
        }
        public async Task<FemaleQuestionsRespDTO> GetFemaleDonorQuestions()
        {
            _FemaleQuestionsRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"FemaleQuest/GetFemaleDonorQuestions");
            _FemaleQuestionsRespDTO = JsonConvert.DeserializeObject<FemaleQuestionsRespDTO>(retrunString);
            return _FemaleQuestionsRespDTO;
        }
    }
}
