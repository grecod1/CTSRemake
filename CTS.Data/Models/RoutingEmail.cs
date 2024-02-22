using System;
using System.Collections.Generic;

namespace CTS.Data.Models;

public partial class RoutingEmail
{
    public int Id { get; set; }

    public int RoutingCategoryId { get; set; }

    public string? EmailAddress { get; set; }

    public string? CreatedByUserName { get; set; }

    public DateTime CreationDate { get; set; }

    public string? LastModifiedByUserName { get; set; }

    public DateTime ModificationDate { get; set; }

    public virtual RoutingCategory RoutingCategory { get; set; } = null!;
}
