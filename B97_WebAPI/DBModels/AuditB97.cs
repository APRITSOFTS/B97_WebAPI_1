using System;
using System.Collections.Generic;

namespace B97_WebAPI.DBModels;

public partial class AuditB97
{
    public int AuditId { get; set; }

    public string? AuditLog { get; set; }

    public DateTime? AuditedOn { get; set; }
}
