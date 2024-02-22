using System;
using System.Collections.Generic;

namespace CTS.Data.Models;

public partial class Program
{
    public int Id { get; set; }

    public string LongName { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public bool IsActive { get; set; }

    public string? CreatedByUserName { get; set; }

    public DateTime CreationDate { get; set; }

    public string? LastModifiedByUserName { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();
}
