using System;
using System.Collections.Generic;

namespace CTS.Data.Models;

public partial class PhoneType
{
    public int Id { get; set; }

    public string? PhoneTypeName { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedByUserName { get; set; }

    public DateTime CreationDate { get; set; }

    public string? LastModifiedByUserName { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
}
