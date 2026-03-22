using MSEBDGAPI.Services.Camps.Master;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampsAPI.Controllers.Master
{
    
    [ApiController]
    public class GenderController : ControllerBase
    {
        private GenderService _GenderService;

        public GenderController(GenderService GenderService)
        {
            _GenderService = GenderService;
        }

        [Route("api/[controller]/GetGenderList")]
        [HttpGet]
        public GenderListRespDTO GetGenderList()
        {
            return _GenderService.GetGenderList();
        }
    }
}
