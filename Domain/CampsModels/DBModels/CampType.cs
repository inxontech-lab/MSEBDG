using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class CampType
{
    public int Id { get; set; }

    public string? CampTypeName { get; set; }

    public int Active { get; set; }
}
