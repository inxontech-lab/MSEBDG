using Domain.CampsModels.RespDTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Shared.CampsClient.Master
{
    public class AddressService
    {
        private ServiceClient _serviceClient;
        private IConfiguration _configuration;
        private DivisionListRespDTO _DivisionListRespDTO;
        private DistrictListRespDTO _DistrictListRespDTO;
        private UpazilaListRespDTO _UpazilaListRespDTO;
        private UnionWardListRespDTO _UnionWardListRespDTO;

        public AddressService(ServiceClient serviceClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceClient = serviceClient;
        }
        public async Task<DivisionListRespDTO> GetDivisionList()
        {
            _DivisionListRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Address/GetDivisionList");
            _DivisionListRespDTO = JsonConvert.DeserializeObject<DivisionListRespDTO>(retrunString);
            return _DivisionListRespDTO;
        }

        public async Task<DistrictListRespDTO> GetDistrictList(int DivisionId)
        {
            _DistrictListRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Address/GetDistrictList/{DivisionId}");
            _DistrictListRespDTO = JsonConvert.DeserializeObject<DistrictListRespDTO>(retrunString);
            return _DistrictListRespDTO;
        }

        public async Task<DistrictListRespDTO> GetZillaList(int divisionId)
        {
            _DistrictListRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Address/GetZillaList/{divisionId}");
            _DistrictListRespDTO = JsonConvert.DeserializeObject<DistrictListRespDTO>(retrunString);
            return _DistrictListRespDTO;
        }

        public async Task<UpazilaListRespDTO> GetUpazilaList(int DistrictId)
        {
            _UpazilaListRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Address/GetUpazilaList/{DistrictId}");
            _UpazilaListRespDTO = JsonConvert.DeserializeObject<UpazilaListRespDTO>(retrunString);
            return _UpazilaListRespDTO;
        }

        public async Task<UpazilaListRespDTO> GetThanaList(int districtId)
        {
            _UpazilaListRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Address/GetThanaList/{districtId}");
            _UpazilaListRespDTO = JsonConvert.DeserializeObject<UpazilaListRespDTO>(retrunString);
            return _UpazilaListRespDTO;
        }
        public async Task<UnionWardListRespDTO> GetWardUnionList(int UpazilaId)
        {
            _UnionWardListRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Address/GetWardUnionList/{UpazilaId}");
            _UnionWardListRespDTO = JsonConvert.DeserializeObject<UnionWardListRespDTO>(retrunString);
            return _UnionWardListRespDTO;
        }

        public async Task<UnionWardListRespDTO> GetVillageList(int upazilaId)
        {
            _UnionWardListRespDTO = new();
            string retrunString = null;
            retrunString = await _serviceClient.clientMethod(_configuration.GetSection("ApiEndpoints").GetSection("BaseAddress").Value + $"Address/GetVillageList/{upazilaId}");
            _UnionWardListRespDTO = JsonConvert.DeserializeObject<UnionWardListRespDTO>(retrunString);
            return _UnionWardListRespDTO;
        }
    }
}
