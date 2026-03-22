using MSEBDGAPI.Services.Camps.Master;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampsAPI.Controllers.Master
{
    [ApiController]
    public class BloodGroupController : ControllerBase
    {
        private BloodGroupService _BloodGroupService;
        public BloodGroupController(BloodGroupService BloodGroupService)
        {
            _BloodGroupService = BloodGroupService;
        }

        [Route("api/[controller]/GetBloodGroupList")]
        [HttpGet]
        public BloodGroupListRespDTO GetBloodGroupList()
        {
            return _BloodGroupService.GetBloodGroupList();
        }
    }
}
