using DataAccess.CampsRepo;
using Domain.CampsModels.DTOs;

namespace MSEBDGAPI.Services.Camps.Common
{
    public class GroupingDashboardService
    {
        private IGroupingCampDataRepo _IGroupingCampDataRepo;

        public GroupingDashboardService(IGroupingCampDataRepo IGroupingCampDataRepo)
        {
            _IGroupingCampDataRepo = IGroupingCampDataRepo;
        }

        public Task<DashboardResultGrouping> GetDasboardForGrouping(int? campId, int? unitCommitteeId, DateTime? startDate, DateTime? endDate)
        {
            return _IGroupingCampDataRepo.GetDashboardSummaryAsync(campId, unitCommitteeId, startDate, endDate);
        }
    }
}
