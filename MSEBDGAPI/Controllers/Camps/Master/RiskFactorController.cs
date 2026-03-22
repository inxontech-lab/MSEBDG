using MSEBDGAPI.Services.Camps.Master;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampsAPI.Controllers.Master
{
    [ApiController]
    public class RiskFactorController : ControllerBase
    {
        private RiskFactorService _RiskFactorService;
        public RiskFactorController(RiskFactorService RiskFactorService)
        {
            _RiskFactorService = RiskFactorService;
        }

        [Route("api/[controller]/GetRiskFactQuestions")]
        [HttpGet]
        public RiskFactorQuestRespDTO GetRiskFactQuestions()
        {
            return _RiskFactorService.GetRiskFactQuestions();
        }

    }
}
