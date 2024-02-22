using System;
using System.Collections.Generic;

namespace CTS.Data.Models;

public partial class County
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? CreatedByUserName { get; set; }

    public DateTime CreationDate { get; set; }

    public string? LastModifiedByUserName { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
