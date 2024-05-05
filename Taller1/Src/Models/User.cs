namespace Taller1.Src.Models;

public class User
{
    public int Id { get; set; }

    public string Rut { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public DateOnly Birthdate { get; set; }

    public string Email { get; set; } = string.Empty;

    public string? Gender { get; set; } 

    public string Password { get; set; } = string.Empty;


    //Relaciones
    public int RoleId { get; set;}

    public Role Role { get; set; } = null!;
}
