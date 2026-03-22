using Domain.CampsModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CampsRepo
{
    public interface IGroupingCampDataRepo : IDisposable
    {
        Task<DashboardResultGrouping> GetDashboardSummaryAsync(int? campId, int? unitCommitteeId, DateTime? startDate, DateTime? endDate);
    }
}
