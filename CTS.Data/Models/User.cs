using System;
using System.Collections.Generic;

namespace CTS.Data.Models;

public partial class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int RoleId { get; set; }

    public int OfficeLocationId { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedByUserName { get; set; }

    public DateTime CreationDate { get; set; }

    public string? LastModifiedByUserName { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual OfficeLocation OfficeLocation { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
