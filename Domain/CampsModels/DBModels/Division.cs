using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class Division
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string BnName { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int? Active { get; set; }
}
