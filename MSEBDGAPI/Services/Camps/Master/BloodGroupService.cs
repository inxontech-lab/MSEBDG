using DataAccess.CampsRepo;
using Domain.CampsModels.RespDTO;

namespace MSEBDGAPI.Services.Camps.Master
{
    public class BloodGroupService
    {
        private IGroupingCampContextDataRepo _IGroupingCampContextDataRepo;

        public BloodGroupService(IGroupingCampContextDataRepo IGroupingCampContextDataRepo)
        {
            _IGroupingCampContextDataRepo = IGroupingCampContextDataRepo;
        }

        public BloodGroupListRespDTO GetBloodGroupList()
        {
            return _IGroupingCampContextDataRepo.GetBloodGroupList();
        }
    }
}
