using Domain.CampsModels.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CampsModels.ReqDTO
{
    public class BeneficiaryDetailsReqDTO
    {
        public Beneficiary Beneficiary { get; set; } = new();
        public List<BeneficiaryQuestionAnswer> BeneficiaryQuestionAnswers { get; set; } = new();
    }
}
