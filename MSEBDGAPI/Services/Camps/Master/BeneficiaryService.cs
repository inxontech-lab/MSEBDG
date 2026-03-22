using DataAccess.CampsRepo;
using Domain.CampsModels.ReqDTO;
using Domain.CampsModels.RespDTO;

namespace MSEBDGAPI.Services.Camps.Master
{
    public class BeneficiaryService
    {
        private IGroupingCampContextDataRepo _IGroupingCampContextDataRepo;

        public BeneficiaryService(IGroupingCampContextDataRepo IGroupingCampContextDataRepo)
        {
            _IGroupingCampContextDataRepo = IGroupingCampContextDataRepo;
        }

        public async Task<CommonRespDTO> SaveBeneficiaryDetailsAsync(BeneficiaryDetailsReqDTO reqDTO)
        {
            return await _IGroupingCampContextDataRepo.SaveBeneficiaryDetailsAsync(reqDTO);
        }

        public async Task<BeneficiaryInfoRespDTO> GetBeneficiaryByMobile(string MobileNumber)
        {
            return await _IGroupingCampContextDataRepo.GetBeneficiaryByMobile(MobileNumber);
        }

        public async Task<CommonRespDTO> UpdateBloodGroupByMobile(int BloodGroup, string MobileNumber)
        {
            return await _IGroupingCampContextDataRepo.UpdateBloodGroupByMobile(BloodGroup, MobileNumber);
        }
    }
}
