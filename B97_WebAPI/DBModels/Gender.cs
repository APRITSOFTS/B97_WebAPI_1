using System;
using System.Collections.Generic;

namespace B97_WebAPI.DBModels;

public partial class Gender
{
    public int GenderId { get; set; }

    public string? GenderName { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
