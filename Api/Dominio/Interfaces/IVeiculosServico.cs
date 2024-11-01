using MinimalApi.Dominio.Entidades;
using MinimalApi.DTOs;

namespace MinimalApi.Dominio.Servicos;

public interface IveiculosServico
{
    List<Veiculo>? Todos(int? pagina = 1, string? nome = null, string? marca = null);

    Veiculo? BuscaPorId(int id);

    void Incluir(Veiculo veiculo);

    void Atualizar(Veiculo veiculo);

    void Apagar(Veiculo veiculo);
}