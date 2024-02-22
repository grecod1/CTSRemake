using System;
using System.Collections.Generic;

namespace CTS.Data.Models;

public partial class OfficeLocation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CloseDate { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedByUserName { get; set; }

    public DateTime CreationDate { get; set; }

    public string? LastModifiedByUserName { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
