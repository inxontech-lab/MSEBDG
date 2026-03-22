using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CampsModels.ReqDTO
{
    public class CampDetailsReqDTO
    {
        public int? campId { get; set; }
        public int? campTypeId { get; set; }
        public int? seCommitteeId { get; set; }
        public int? unitCommitteeId { get; set; }
        public string? campDateString { get; set; }
    }
}
