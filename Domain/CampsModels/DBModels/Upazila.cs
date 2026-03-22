using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class Upazila
{
    public int Id { get; set; }

    public int DistrictId { get; set; }

    public string Name { get; set; } = null!;

    public string BnName { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int? Active { get; set; }
}
