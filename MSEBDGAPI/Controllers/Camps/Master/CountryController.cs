using MSEBDGAPI.Services.Camps.Master;
using Domain.CampsModels.RespDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampsAPI.Controllers.Master
{
    [ApiController]
    public class CountryController : ControllerBase
    {
        private CountryService _CountryService;
        public CountryController(CountryService CountryService)
        {
            _CountryService = CountryService;
        }

        [Route("api/[controller]/GetCountryList")]
        [HttpGet]
        public CountryListRespDTO GetCountryList()
        {
            return _CountryService.GetCountryList();
        }
    }
}
