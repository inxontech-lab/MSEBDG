using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class UnitCommittee
{
    public int Id { get; set; }

    public string UnitCommitteeNameEn { get; set; } = null!;

    public string? UnitCommitteeNameBn { get; set; }

    public string? Address { get; set; }

    public string? ContactPerson { get; set; }

    public string? PhoneNumber { get; set; }

    public int Active { get; set; }
}
