namespace Lab11BarredaPintoZoriel.Application.DTos;

public class TicketDTo
{
    public UserSimpleDTo user { get; set; } = null!; 
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ResponsesTicketDTo ResponseTicketDTo { get; set; } = null!;
}