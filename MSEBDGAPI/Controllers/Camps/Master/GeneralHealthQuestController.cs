using MSEBDGAPI.Services.Camps.Master;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampsAPI.Controllers.Master
{
    [ApiController]
    public class GeneralHealthQuestController : ControllerBase
    {
        private GeneralHealthQuestService _GeneralHealthQuestService;
        public GeneralHealthQuestController(GeneralHealthQuestService GeneralHealthQuestService)
        {
            _GeneralHealthQuestService = GeneralHealthQuestService;
        }

        [Route("api/[controller]/GetGeneralHealtQuestions")]
        [HttpGet]
        public GeneralHealthQuestionRespDTO GetGeneralHealtQuestions()
        {
            return _GeneralHealthQuestService.GetGeneralHealtQuestions();
        }
    }
}
