namespace Lab11BarredaPintoZoriel.Application.DTos;

public class RoleDTo
{
    public Guid id { get; set; }
    public string RoleName { get; set; } = null!;
    public IList<UserSimpleDTo> Users { get; set; } = null!;
}