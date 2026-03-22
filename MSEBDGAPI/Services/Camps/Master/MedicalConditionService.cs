using DataAccess.CampsRepo;
using Domain.CampsModels.RespDTO;

namespace MSEBDGAPI.Services.Camps.Master
{
    public class MedicalConditionService
    {
        private IGroupingCampContextDataRepo _IGroupingCampContextDataRepo;

        public MedicalConditionService(IGroupingCampContextDataRepo IGroupingCampContextDataRepo)
        {
            _IGroupingCampContextDataRepo = IGroupingCampContextDataRepo;
        }

        public MedicalConsitonListRespDTO GetMedicalConditonList()
        {
            return _IGroupingCampContextDataRepo.GetMedicalConditonList();
        }
    }
}
