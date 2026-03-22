using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class CountryMst
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public string Iso2code { get; set; } = null!;

    public string Iso3code { get; set; } = null!;

    public string? DialCode { get; set; }
}
