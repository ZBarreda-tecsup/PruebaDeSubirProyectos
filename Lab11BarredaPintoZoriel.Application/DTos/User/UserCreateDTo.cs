namespace Lab11BarredaPintoZoriel.Application.DTos;

public class UserCreateDTo
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    
    public DateTimeOffset? CreateAt { get; set; }
}