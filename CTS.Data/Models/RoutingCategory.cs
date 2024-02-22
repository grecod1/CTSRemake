using System;
using System.Collections.Generic;

namespace CTS.Data.Models;

public partial class RoutingCategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedByUserName { get; set; }

    public DateTime CreationDate { get; set; }

    public string? LastModifiedByUserName { get; set; }

    public DateTime ModifiedDate { get; set; }

    public string? Area { get; set; }

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();

    public virtual ICollection<RoutingEmail> RoutingEmails { get; set; } = new List<RoutingEmail>();
}
