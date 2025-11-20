namespace Lab11BarredaPintoZoriel.Application.DTos;

public class ResponseDTo
{
    public TicketResponseDTo TicketData{ get; set; }
    public UserResponseDTo UserData { get; set; }
    public string Message { get; set; } = null!;
}