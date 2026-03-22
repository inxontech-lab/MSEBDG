using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CampsModels.ReqDTO
{
    public class GroupingDashboardReqDTO
    {
        public int? campId { get; set; }
        public int? unitCommitteeId { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}
