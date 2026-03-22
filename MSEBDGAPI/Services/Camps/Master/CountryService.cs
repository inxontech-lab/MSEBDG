using DataAccess.CampsRepo;
using Domain.CampsModels.RespDTO;

namespace MSEBDGAPI.Services.Camps.Master
{
    public class CountryService
    {
        private IGroupingCampContextDataRepo _IGroupingCampContextDataRepo;

        public CountryService(IGroupingCampContextDataRepo IGroupingCampContextDataRepo)
        {
            _IGroupingCampContextDataRepo = IGroupingCampContextDataRepo;
        }

        public CountryListRespDTO GetCountryList()
        {
            return _IGroupingCampContextDataRepo.GetCountryList();
        }
    }
}
