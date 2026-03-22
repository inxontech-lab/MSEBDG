using DataAccess.CampsRepo;
using Domain.CampsModels.RespDTO;

namespace MSEBDGAPI.Services.Camps.Master
{
    public class RiskFactorService
    {
        private IGroupingCampContextDataRepo _IGroupingCampContextDataRepo;

        public RiskFactorService(IGroupingCampContextDataRepo IGroupingCampContextDataRepo)
        {
            _IGroupingCampContextDataRepo = IGroupingCampContextDataRepo;
        }

        public RiskFactorQuestRespDTO GetRiskFactQuestions()
        {
            return _IGroupingCampContextDataRepo.GetRiskFactQuestions();
        }
    }
}
