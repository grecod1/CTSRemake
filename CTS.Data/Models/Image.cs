using System;
using System.Collections.Generic;

namespace CTS.Data.Models;

public partial class Image
{
    public int Id { get; set; }

    public byte[]? CharacterSet { get; set; }

    public int TicketId { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedByUserName { get; set; }

    public DateTime CreationDate { get; set; }

    public string? LastModifiedByUserName { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;
}
