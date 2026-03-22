using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CampsModels.RespDTO
{
    public class CampDetailsDTO
    {
        public int Id { get; set; }
        public string? CampNameEn { get; set; }
        public string? CampNameBn { get; set; }
        public int? CampTypeId { get; set; }
        public string? CampTypeName { get; set; }
        public int? CountryId { get; set; }
        public string? CountryName { get; set; }
        public int? SECommitteeId { get; set; }
        public string? SECommitteeNameEn { get; set; }
        public string? SECommitteeNameBn { get; set; }
        public int? UnitCommitteeId { get; set; }
        public string? UnitCommitteeNameEn { get; set; }
        public string? UnitCommitteeNameBn { get; set; }
        public DateTime? CampDate { get; set; }
        public string? CampLocationEn { get; set; }
        public string? CampLocationBn { get; set; }
        public string? Lattitude { get; set; }
        public string? Longitude { get; set; }
        public string? Coordinator { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public int Active { get; set; }
    }
}
