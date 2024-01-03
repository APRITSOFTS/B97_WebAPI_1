using System;
using System.Collections.Generic;

namespace B97_WebAPI.DBModels;

public partial class ViewStudentCountBranch
{
    public string? BranchName { get; set; }

    public int? TotalStudents { get; set; }
}
