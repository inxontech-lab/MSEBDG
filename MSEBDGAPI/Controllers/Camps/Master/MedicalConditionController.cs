using MSEBDGAPI.Services.Camps.Master;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampsAPI.Controllers.Master
{
    [ApiController]
    public class MedicalConditionController : ControllerBase
    {
        private MedicalConditionService _MedicalConditionService;

        public MedicalConditionController(MedicalConditionService MedicalConditionService)
        {
            _MedicalConditionService = MedicalConditionService;
        }

        [Route("api/[controller]/GetMedicalConditonList")]
        [HttpGet]
        public MedicalConsitonListRespDTO GetMedicalConditonList()
        {
            return _MedicalConditionService.GetMedicalConditonList();
        }
    }
}
