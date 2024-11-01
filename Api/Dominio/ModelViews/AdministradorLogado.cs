using minimalapi.Dominio.Enums;

namespace minimalapi.Dominio.ModelViews;

public record AdministradorLogado
{
    public string Email {get; set;} = default!;
    public String Perfil {get; set;} = default!;
    public String Token {get; set;} = default!;
}
