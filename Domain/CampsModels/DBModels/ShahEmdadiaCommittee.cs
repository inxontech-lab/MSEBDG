using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class ShahEmdadiaCommittee
{
    public int Id { get; set; }

    public string SecommitteeNameEn { get; set; } = null!;

    public string? SecommitteeNameBn { get; set; }

    public int IsDaira { get; set; }

    public string? AddressEn { get; set; }

    public string? AddressBn { get; set; }

    public string? ContactPerson { get; set; }

    public string? PhoneNumber { get; set; }

    public int Active { get; set; }
}
