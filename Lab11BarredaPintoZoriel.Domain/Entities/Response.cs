using System;
using System.Collections.Generic;

namespace Lab11BarredaPintoZoriel.Infrastructure.Models;

public partial class Response
{
    public Guid ResponseId { get; set; }

    public Guid TicketId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;
}
