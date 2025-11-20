namespace Lab11BarredaPintoZoriel.Application.DTos;

public class UserRoleCreateDTo
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public DateTime? CreateAt { get; set; }
}