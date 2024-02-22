using System;
using System.Collections.Generic;

namespace CTS.Data.Models;

public partial class Route
{
    public int Id { get; set; }

    public int RoutingCategoryId { get; set; }

    public int TicketId { get; set; }

    public int ProgramId { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedByUserName { get; set; }

    public DateTime CreationDate { get; set; }

    public string? LastModifiedByUserName { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Program Program { get; set; } = null!;

    public virtual RoutingCategory RoutingCategory { get; set; } = null!;

    public virtual Ticket Ticket { get; set; } = null!;
}
