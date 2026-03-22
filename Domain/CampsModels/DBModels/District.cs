using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class District
{
    public int Id { get; set; }

    public int DivisionId { get; set; }

    public string Name { get; set; } = null!;

    public string BnName { get; set; } = null!;

    public string? Lat { get; set; }

    public string? Lon { get; set; }

    public string Url { get; set; } = null!;

    public int? Active { get; set; }
}
