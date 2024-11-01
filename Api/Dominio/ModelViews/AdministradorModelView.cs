using minimalapi.Dominio.Enums;

namespace minimalapi.Dominio.ModelViews;

public record AdministradorModelView
{
    public int Id {get; set;} = default!;
    public string Email {get; set;} = default!;
    public String Perfil {get; set;} = default!;
}