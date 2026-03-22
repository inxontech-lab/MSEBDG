using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class CampDetail
{
    public int Id { get; set; }

    public string CampNameEn { get; set; } = null!;

    public string? CampNameBn { get; set; }

    public int CampTypeId { get; set; }

    public int Country { get; set; }

    public int? SecommitteeId { get; set; }

    public int? UnitCommitteeId { get; set; }

    public DateTime CampDate { get; set; }

    public string CampLocationEn { get; set; } = null!;

    public string? CampLocationBn { get; set; }

    public string? Lattitude { get; set; }

    public string? Longitude { get; set; }

    public string? Coordinator { get; set; }

    public string? Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public int Active { get; set; }
}
