using Lab11BarredaPintoZoriel.Application.DTos;

namespace Lab11BarredaPintoZoriel.Application.DTos;

public class UserResponseDTo
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public RoleDTo Role { get; set; } = null!;
}