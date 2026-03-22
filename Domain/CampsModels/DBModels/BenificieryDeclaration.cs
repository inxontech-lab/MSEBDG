using System;
using System.Collections.Generic;

namespace Domain.CampsModels.DBModels;

public partial class BenificieryDeclaration
{
    public int DonorDeclarationId { get; set; }

    public int BenificieryId { get; set; }

    public int DeclarationId { get; set; }

    public bool Response { get; set; }

    public DateTime ResponseDate { get; set; }

    public string? Remarks { get; set; }

    public byte[]? SignatureImage { get; set; }

    public string? SignatureBase64 { get; set; }
}
