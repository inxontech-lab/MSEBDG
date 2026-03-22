using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class BenificieryMedicalHistory
{
    public int HistoryId { get; set; }

    public int BenificieryId { get; set; }

    public int? ConditionId { get; set; }

    public int? MedicationId { get; set; }

    public int? AllergyId { get; set; }

    public int? VaccinationId { get; set; }

    public bool? HasCondition { get; set; }

    public string? Details { get; set; }

    public DateTime? CreatedDate { get; set; }
}
