using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class UserProfile
{
    public int Id { get; set; }

    public string UserProfileName { get; set; } = null!;

    public int Active { get; set; }
}
