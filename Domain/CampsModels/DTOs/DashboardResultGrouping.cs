using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CampsModels.DTOs
{
    public class DashboardResultGrouping
    {
        public int Total { get; set; }
        public int Male { get; set; }
        public int Female { get; set; }
        public int Other { get; set; }

        public List<BloodGroupSummary> BloodGroups { get; set; } = new();
        //public List<CampItem> Camps { get; set; } = new();
        //public List<UnitCommitteeItem> UnitCommittees { get; set; } = new();
        public List<TrendPoint> Trend { get; set; } = new();
    }
    public class BloodGroupSummary 
    { 
        public string BloodGroup { get; set; } = ""; 
        public int Total { get; set; } 
    }

    public class CampItem 
    { 
        public int CampId { get; set; } 
        public string? CampNameEn { get; set; } = "";
        public string? CampNameBn { get; set; } = ""; 
        public DateTime? CampDate { get; set; } 
    }

    public class UnitCommitteeItem 
    { 
        public int? UnitCommitteeId { get; set; } 
        public string? UnitCommitteeNameEn { get; set; } = "";
        public string? UnitCommitteeNameBn { get; set; } = "";
    }
    public class TrendPoint 
    { 
        public string YearMonth { get; set; } = ""; 
        public int BeneficiaryCount { get; set; } 
    }
}
