using DataAccess.CampsRepo;
using Domain.CampsModels.RespDTO;

namespace MSEBDGAPI.Services.Camps.Master
{
    public class SeCommitteeService
    {
        private IGroupingCampContextDataRepo _IGroupingCampContextDataRepo;

        public SeCommitteeService(IGroupingCampContextDataRepo IGroupingCampContextDataRepo)
        {
            _IGroupingCampContextDataRepo = IGroupingCampContextDataRepo;
        }

        public SECommitteeRespDTO GetSeCommitteeList()
        {
            return _IGroupingCampContextDataRepo.GetSeCommitteeList();
        }
    }
}
