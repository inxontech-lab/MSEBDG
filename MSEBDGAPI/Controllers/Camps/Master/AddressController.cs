using MSEBDGAPI.Services.Camps.Master;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;

namespace CampsAPI.Controllers.Master
{
    [ApiController]
    public class AddressController : ControllerBase
    {
        private AddressService _AddressService;
        public AddressController(AddressService AddressService)
        {
            _AddressService = AddressService;
        }

        [Route("api/[controller]/GetDivisionList")]
        [HttpGet]
        public DivisionListRespDTO GetDivisionList()
        {
            return _AddressService.GetDivisionList();
        }

        [Route("api/[controller]/GetDistrictList/{DivisionId}")]
        [HttpGet]
        public DistrictListRespDTO GetDistrictList(int DivisionId)
        {
            return _AddressService.GetDistrictList(DivisionId);
        }

        [Route("api/[controller]/GetUpazilaList/{DistrictId}")]
        [HttpGet]
        public UpazilaListRespDTO GetUpazilaList(int DistrictId)
        {
            return _AddressService.GetUpazilaList(DistrictId);
        }

        [Route("api/[controller]/GetWardUnionList/{UpazilaId}")]
        [HttpGet]
        public UnionWardListRespDTO GetWardUnionList(int UpazilaId)
        {
            return _AddressService.GetWardUnionList(UpazilaId);
        }
    }
}
