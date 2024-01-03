using System;
using System.Collections.Generic;

namespace B97_WebAPI.DBModels;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public DateTime? StudentDateofBirth { get; set; }

    public int? BranchId { get; set; }

    public int? GenderId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Gender? Gender { get; set; }
}
