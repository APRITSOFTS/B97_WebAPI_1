using System;
using System.Collections.Generic;

namespace B97_WebAPI.DBModels;

public partial class Branch
{
    public int BranchId { get; set; }

    public string? BranchCode { get; set; }

    public string? BranchName { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
