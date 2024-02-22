using System;
using System.Collections.Generic;

namespace CTS.Data.Models;

public partial class CommunicationType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? CreatedByUserName { get; set; }

    public DateTime CreationDate { get; set; }

    public string? LastModifiedByUserName { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
