using System;
using System.Collections.Generic;

namespace CTS.Data.Models;

public partial class PhoneNumber
{
    public int Id { get; set; }

    public string? Number { get; set; }

    public int PhoneTypeId { get; set; }

    public string? CreatedByUserName { get; set; }

    public DateTime CreationDate { get; set; }

    public string? LastModifiedByUserName { get; set; }

    public DateTime ModifiedDate { get; set; }

    public int TicketId { get; set; }

    public virtual PhoneType PhoneType { get; set; } = null!;

    public virtual Ticket Ticket { get; set; } = null!;
}
