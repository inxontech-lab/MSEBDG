using DataAccess.CampsRepo;
using Domain.CampsModels.DBModels;
using Domain.CampsModels.RespDTO;

namespace MSEBDGAPI.Services.Camps.Master
{
    public class QuestionMasterService
    {
        private IGroupingCampContextDataRepo _IGroupingCampContextDataRepo;
        public QuestionMasterService(IGroupingCampContextDataRepo IGroupingCampContextDataRepo)
        {
            _IGroupingCampContextDataRepo = IGroupingCampContextDataRepo;
        }
        public List<QuestionMaster> GetQuestionList()
        {
            return _IGroupingCampContextDataRepo.GetQuestionList();
        }
    }
}
