using System;
using System.Collections.Generic;

namespace CTS.Data.Models;

public partial class EventLog
{
    public int Id { get; set; }

    public int EventTypeId { get; set; }

    public string? CreatedByUserName { get; set; }

    public DateTime CreationDate { get; set; }

    public string? LastModifiedByUserName { get; set; }

    public DateTime ModifiedDate { get; set; }

    public string? TicketTrackingNumber { get; set; }

    public string? Email { get; set; }

    public virtual EventType EventType { get; set; } = null!;
}
