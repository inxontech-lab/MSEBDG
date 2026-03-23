using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class Gender
{
    public int Id { get; set; }

    public string? GenderName { get; set; }

    public int Active { get; set; }

    public virtual ICollection<CampaignVolunteer> CampaignVolunteers { get; set; } = new List<CampaignVolunteer>();
}
