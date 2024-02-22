using System;
using System.Collections.Generic;

namespace CTS.Data.Models;

public partial class Address
{
    public int Id { get; set; }

    public string? StreetNumber { get; set; }

    public string? StreetName { get; set; }

    public string? AptNumber { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public int CountyId { get; set; }

    public int AddressTypeId { get; set; }

    public string? CreatedByUserName { get; set; }

    public DateTime CreationDate { get; set; }

    public string? LastModifiedByUserName { get; set; }

    public DateTime ModifiedDate { get; set; }

    public int TicketId { get; set; }

    public bool IsPobox { get; set; }

    public virtual AddressType AddressType { get; set; } = null!;

    public virtual County County { get; set; } = null!;

    public virtual Ticket Ticket { get; set; } = null!;
}
