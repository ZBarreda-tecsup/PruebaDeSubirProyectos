namespace Lab11BarredaPintoZoriel.Application.DTos;

public class TicketCreateDTo
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string status {get; set;}
    public DateTime? CreateAt { get; set; }
    public DateTime? CloseAt { get; set; }
}