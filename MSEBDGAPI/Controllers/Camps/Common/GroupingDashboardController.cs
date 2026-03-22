using MSEBDGAPI.Services.Camps.Common;
using Domain.CampsModels.DTOs;
using Domain.CampsModels.ReqDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampsAPI.Controllers.GroupingCamp
{
    [ApiController]
    public class GroupingDashboardController : ControllerBase
    {
        private GroupingDashboardService _GroupingDashboardService;
        public GroupingDashboardController(GroupingDashboardService GroupingDashboardService)
        {
            _GroupingDashboardService = GroupingDashboardService;
        }

        [Route("api/[controller]/GroupingCamp/GetDasboardForGrouping")]
        [HttpPost]
        public Task<DashboardResultGrouping> GetDasboardForGrouping([FromBody] GroupingDashboardReqDTO req)
        {
            return _GroupingDashboardService.GetDasboardForGrouping(req.campId, req.unitCommitteeId, req.startDate, req.endDate);
        }
    }
}
