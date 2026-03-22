using DataAccess.CampsRepo;
using Domain.CampsModels.RespDTO;

namespace MSEBDGAPI.Services.Camps.Master
{
    public class FemaleDonorQuestService
    {
        private IGroupingCampContextDataRepo _IGroupingCampContextDataRepo;

        public FemaleDonorQuestService(IGroupingCampContextDataRepo IGroupingCampContextDataRepo)
        {
            _IGroupingCampContextDataRepo = IGroupingCampContextDataRepo;
        }

        public FemaleQuestionsRespDTO GetFemaleDonorQuestions()
        {
            return _IGroupingCampContextDataRepo.GetFemaleDonorQuestions();
        }
    }
}
