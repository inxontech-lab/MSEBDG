using Domain.CampsModels.DBModels;
using Domain.CampsModels.RespDTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Shared.CampsClient.Master
{
    public class QuestionMasterService
    {
        private ServiceClient _serviceClient;
        private IConfiguration _configuration;
        private List<QuestionMaster> _questionMasters;

        public QuestionMasterService(ServiceClient serviceClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceClient = serviceClient;
        }

        public async Task<List<QuestionMaster>> GetQuestionList()
        {
            _questionMasters = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"QuestionMaster/GetQuestionList");
            _questionMasters = JsonConvert.DeserializeObject<List<QuestionMaster>>(retrunString);
            return _questionMasters;
        }
    }
}
