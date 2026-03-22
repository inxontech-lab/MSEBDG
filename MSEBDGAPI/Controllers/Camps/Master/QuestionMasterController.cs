using MSEBDGAPI.Services.Camps.Master;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.CampsModels.DBModels;

namespace CampsAPI.Controllers.Master
{
    [ApiController]
    public class QuestionMasterController : ControllerBase
    {
        private QuestionMasterService _QuestionMasterService;
        public QuestionMasterController(QuestionMasterService QuestionMasterService)
        {
            _QuestionMasterService = QuestionMasterService;
        }

        [Route("api/[controller]/GetQuestionList")]
        [HttpGet]
        public List<QuestionMaster> GetQuestionList()
        {
            return _QuestionMasterService.GetQuestionList();
        }
    }
}
