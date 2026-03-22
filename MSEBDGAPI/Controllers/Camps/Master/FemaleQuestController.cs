using MSEBDGAPI.Services.Camps.Master;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampsAPI.Controllers.Master
{
    [ApiController]
    public class FemaleQuestController : ControllerBase
    {
        private FemaleDonorQuestService _FemaleDonorQuestService;
        public FemaleQuestController(FemaleDonorQuestService FemaleDonorQuestService)
        {
            _FemaleDonorQuestService = FemaleDonorQuestService;
        }

        [Route("api/[controller]/GetFemaleDonorQuestions")]
        [HttpGet]
        public FemaleQuestionsRespDTO GetFemaleDonorQuestions()
        {
            return _FemaleDonorQuestService.GetFemaleDonorQuestions();
        }
    }
}
