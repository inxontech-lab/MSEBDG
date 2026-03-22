using MSEBDGAPI.Services.Camps.Master;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampsAPI.Controllers.Master
{
    [ApiController]
    public class SeCommitteeController : ControllerBase
    {
        private SeCommitteeService _SeCommitteeService;
        public SeCommitteeController(SeCommitteeService SeCommitteeService)
        {
            _SeCommitteeService = SeCommitteeService;
        }

        [Route("api/[controller]/GetSeCommitteeList")]
        [HttpGet]
        public SECommitteeRespDTO GetSeCommitteeList()
        {
            return _SeCommitteeService.GetSeCommitteeList();
        }
    }
}
