using DataAccess.CampsRepo;
using Domain.CampsModels.RespDTO;

namespace MSEBDGAPI.Services.Camps.Master
{
    public class CampTypeService
    {
        private IGroupingCampContextDataRepo _IGroupingCampContextDataRepo;

        public CampTypeService(IGroupingCampContextDataRepo IGroupingCampContextDataRepo)
        {
            _IGroupingCampContextDataRepo = IGroupingCampContextDataRepo;
        }

        public CampTypeListRespDTO GetCampTypeList()
        {
            return _IGroupingCampContextDataRepo.GetCampTypeList();
        }
    }
}
