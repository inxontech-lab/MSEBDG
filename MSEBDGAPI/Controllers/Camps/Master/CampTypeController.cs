using MSEBDGAPI.Services.Camps.Master;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampsAPI.Controllers.Master
{
   
    [ApiController]
    public class CampTypeController : ControllerBase
    {
        private CampTypeService _CampTypeService;
        public CampTypeController(CampTypeService CampTypeService)
        {
            _CampTypeService = CampTypeService;
        }

        [Route("api/[controller]/GetCampTypeList")]
        [HttpGet]
        public CampTypeListRespDTO GetCampTypeList()
        {
            return _CampTypeService.GetCampTypeList();
        }
    }
}
