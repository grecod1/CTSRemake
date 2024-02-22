using System;
using System.Collections.Generic;

namespace CTS.Data.Models;

public partial class EventType
{
    public int Id { get; set; }

    public string? EventTypeName { get; set; }

    public string? CreatedByUserName { get; set; }

    public DateTime CreationDate { get; set; }

    public string? LastModifiedByUserName { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<EventLog> EventLogs { get; set; } = new List<EventLog>();
}
