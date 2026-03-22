using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class User
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int UserProfileId { get; set; }

    public int Active { get; set; }
}
