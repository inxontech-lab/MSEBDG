using DataAccess.CampsRepo;
using Domain.CampsModels.DBModels;
using Domain.CampsModels.ReqDTO;
using Domain.CampsModels.RespDTO;

namespace MSEBDGAPI.Services.Camps.Transactions
{
    public class CampDetailsService
    {
        private IGroupingCampContextDataRepo _IGroupingCampContextDataRepo;

        public CampDetailsService(IGroupingCampContextDataRepo IGroupingCampContextDataRepo)
        {
            _IGroupingCampContextDataRepo = IGroupingCampContextDataRepo;
        }

        public async Task<CampDetailsRespDTO> GetCampDetailsList(CampDetailsReqDTO req)
        {
            return await _IGroupingCampContextDataRepo.GetCampDetailsList(req.campId,req.campTypeId, req.seCommitteeId, req.unitCommitteeId, req.campDateString);
        }

        public async Task<CampDetailsRespDTO> SaveCampDetailsAsync(CampDetail req)
        {
            return await _IGroupingCampContextDataRepo.SaveCampDetailsAsync(req);
        }

        public async Task<CampDetailsRespDTO> UpdateCampDetailsAsync(CampDetail req)
        {
            return await _IGroupingCampContextDataRepo.UpdateCampDetailsAsync(req);
        }

        public async Task<CampDetailsRespDTO> GetAllCampDetailsList()
        {
            return await _IGroupingCampContextDataRepo.GetAllCampDetailsList();
        }
    }
}
