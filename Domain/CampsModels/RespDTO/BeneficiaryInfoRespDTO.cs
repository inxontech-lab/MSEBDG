using Domain.CampsModels.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CampsModels.RespDTO
{
    public class BeneficiaryInfoRespDTO
    {
        public string? RESPONSE_CODE { get; set; }
        public string? RESPONSE_DESCRPTION { get; set; }
        public Beneficiary? Beneficiary { get; set; }
    }
}
