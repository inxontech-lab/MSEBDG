using DataAccess.CampsRepo;
using Domain.CampsModels.RespDTO;

namespace MSEBDGAPI.Services.Camps.Master
{
    public class AddressService
    {
        private IGroupingCampContextDataRepo _IGroupingCampContextDataRepo;

        public AddressService(IGroupingCampContextDataRepo IGroupingCampContextDataRepo)
        {
            _IGroupingCampContextDataRepo = IGroupingCampContextDataRepo;
        }

        public DivisionListRespDTO GetDivisionList()
        {
            return _IGroupingCampContextDataRepo.GetDivisionList();
        }

        public DistrictListRespDTO GetDistrictList(int DivisionId)
        {
            return _IGroupingCampContextDataRepo.GetDistrictList(DivisionId);
        }

        public DistrictListRespDTO GetZillaList(int DivisionId)
        {
            return _IGroupingCampContextDataRepo.GetDistrictList(DivisionId);
        }

        public UpazilaListRespDTO GetUpazilaList(int DistrictId)
        {
            return _IGroupingCampContextDataRepo.GetUpazilaList(DistrictId);
        }

        public UpazilaListRespDTO GetThanaList(int DistrictId)
        {
            return _IGroupingCampContextDataRepo.GetUpazilaList(DistrictId);
        }

        public UnionWardListRespDTO GetWardUnionList(int UpazilaId)
        {
            return _IGroupingCampContextDataRepo.GetWardUnionList(UpazilaId);
        }

        public UnionWardListRespDTO GetVillageList(int UpazilaId)
        {
            return _IGroupingCampContextDataRepo.GetWardUnionList(UpazilaId);
        }
    }
}
