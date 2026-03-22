using DataAccess.CampsRepo;
using Domain.CampsModels.RespDTO;

namespace MSEBDGAPI.Services.Camps.Master
{
    public class GeneralHealthQuestService
    {
        private IGroupingCampContextDataRepo _IGroupingCampContextDataRepo;

        public GeneralHealthQuestService(IGroupingCampContextDataRepo IGroupingCampContextDataRepo)
        {
            _IGroupingCampContextDataRepo = IGroupingCampContextDataRepo;
        }

        public GeneralHealthQuestionRespDTO GetGeneralHealtQuestions()
        {
            return _IGroupingCampContextDataRepo.GetGeneralHealtQuestions();
        }
    }
}
