using System;
using System.Collections.Generic;

namespace CTS.Data.Models;

public partial class ErrorLog
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public string? Message { get; set; }

    public string? Task { get; set; }

    public string? UserName { get; set; }

    public DateTime Time { get; set; }
}
