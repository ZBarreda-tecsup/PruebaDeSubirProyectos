namespace Lab11BarredaPintoZoriel.Application.DTos;

public class ResponseCreateDTo
{
    public Guid Id { get; set; }
    public Guid TicketId { get; set; }
    public Guid ResponseId { get; set; }
    public string Message { get; set; }
    public DateTime? CreateAt {get; set;}
}