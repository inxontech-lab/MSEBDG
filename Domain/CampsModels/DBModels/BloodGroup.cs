using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class BloodGroup
{
    public int BloodGroupId { get; set; }

    public string? BlodGroupNameEn { get; set; }

    public string? BloodGroupNameBn { get; set; }

    public int Active { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedBy { get; set; }

    public int? ModifiedDate { get; set; }

    public virtual ICollection<CampaignVolunteer> CampaignVolunteers { get; set; } = new List<CampaignVolunteer>();
}
