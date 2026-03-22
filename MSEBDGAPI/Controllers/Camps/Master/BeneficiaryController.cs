using MSEBDGAPI.Services.Camps.Master;
using Domain.CampsModels.ReqDTO;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampsAPI.Controllers.Master
{
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        private BeneficiaryService _BeneficiaryService;
        public BeneficiaryController(BeneficiaryService BeneficiaryService)
        {
            _BeneficiaryService = BeneficiaryService;
        }

        [Route("api/[controller]/SaveBeneficiaryDetailsAsync")]
        [HttpPost]
        public Task<CommonRespDTO> SaveBeneficiaryDetailsAsync([FromBody] BeneficiaryDetailsReqDTO reqDTO)
        {
            return _BeneficiaryService.SaveBeneficiaryDetailsAsync(reqDTO);
        }

        [Route("api/[controller]/GetBeneficiaryByMobile/{MobileNumber}")]
        [HttpGet]
        public Task<BeneficiaryInfoRespDTO> GetBeneficiaryByMobile(string MobileNumber)
        {
            return _BeneficiaryService.GetBeneficiaryByMobile(MobileNumber);
        }

        [Route("api/[controller]/UpdateBloodGroupByMobile/{BloodGroup}/{MobileNumber}")]
        [HttpGet]
        public Task<CommonRespDTO> UpdateBloodGroupByMobile(int BloodGroup, string MobileNumber)
        {
            return _BeneficiaryService.UpdateBloodGroupByMobile(BloodGroup,MobileNumber);
        }
    }
}
