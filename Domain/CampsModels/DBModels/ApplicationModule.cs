using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class ApplicationModule
{
    public int Id { get; set; }

    public string ModuleName { get; set; } = null!;

    public int Active { get; set; }
}
