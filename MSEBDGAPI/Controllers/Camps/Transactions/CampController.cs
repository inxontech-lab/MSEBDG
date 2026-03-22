using MSEBDGAPI.Services.Camps.Transactions;
using Domain.CampsModels.DBModels;
using Domain.CampsModels.ReqDTO;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampsAPI.Controllers.Transactions
{
    
    [ApiController]
    public class CampController : ControllerBase
    {
        private CampDetailsService _CampDetailsService;
        public CampController(CampDetailsService CampDetailsService)
        {
            _CampDetailsService = CampDetailsService;
        }

        [Route("api/[controller]/GetCampDetailsList")]
        [HttpPost]
        public async Task<CampDetailsRespDTO> GetCampDetailsList([FromBody] CampDetailsReqDTO req)
        {
            return await _CampDetailsService.GetCampDetailsList(req);
        }

        [Route("api/[controller]/GetAllCampDetailsList")]
        [HttpGet]
        public async Task<CampDetailsRespDTO> GetAllCampDetailsList()
        {
            return await _CampDetailsService.GetAllCampDetailsList();
        }

        [Route("api/[controller]/SaveCampDetailsAsync")]
        [HttpPost]
        public async Task<CampDetailsRespDTO> SaveCampDetailsAsync([FromBody] CampDetail req)
        {
            return await _CampDetailsService.SaveCampDetailsAsync(req);
        }

        [Route("api/[controller]/UpdateCampDetailsAsync")]
        [HttpPost]
        public async Task<CampDetailsRespDTO> UpdateCampDetailsAsync([FromBody] CampDetail req)
        {
            return await _CampDetailsService.UpdateCampDetailsAsync(req);
        }
    }
}
