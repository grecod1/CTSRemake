using System;
using System.Collections.Generic;

namespace CTS.Data.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public string? AssignedUser { get; set; }

    public int StatusId { get; set; }

    public int RequestTypeId { get; set; }

    public int CommunicationTypeId { get; set; }

    public string? CreatedByUserName { get; set; }

    public DateTime CreationDate { get; set; }

    public string? LastModifiedByUserName { get; set; }

    public DateTime ModifiedDate { get; set; }

    public string? TrackingNumber { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Affiliation { get; set; }

    public string? Bureau { get; set; }

    public string? ReferredFrom { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual CommunicationType CommunicationType { get; set; } = null!;

    public virtual ICollection<Email> Emails { get; set; } = new List<Email>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();

    public virtual RequestType RequestType { get; set; } = null!;

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();

    public virtual Status Status { get; set; } = null!;
}
