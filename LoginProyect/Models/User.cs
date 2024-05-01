using System;
using System.Collections.Generic;

namespace LoginProyect.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
