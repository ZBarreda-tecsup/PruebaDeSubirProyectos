using Lab11BarredaPintoZoriel.Application.DTos;

namespace Lab11BarredaPintoZoriel.Application.DTos;

public class UserDTo
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int QuantityResponses { get; set; }
    public int QuantityTickets { get; set; }
    public RoleUserDTo role { get; set; } = null!;
}