using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class UserToAppModule
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ApplicationModuleId { get; set; }

    public int Active { get; set; }
}
