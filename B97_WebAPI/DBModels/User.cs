﻿using System;
using System.Collections.Generic;

namespace B97_WebAPI.DBModels;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserEmail { get; set; }

    public string? Password { get; set; }
}
