using DataAccess.CampsRepo;
using Domain.CampsModels.RespDTO;

namespace MSEBDGAPI.Services.Camps.Master
{
    public class GenderService
    {
        private IGroupingCampContextDataRepo _IGroupingCampContextDataRepo;

        public GenderService(IGroupingCampContextDataRepo IGroupingCampContextDataRepo)
        {
            _IGroupingCampContextDataRepo = IGroupingCampContextDataRepo;
        }

        public GenderListRespDTO GetGenderList()
        {
            return _IGroupingCampContextDataRepo.GetGenderList();
        }
    }
}
