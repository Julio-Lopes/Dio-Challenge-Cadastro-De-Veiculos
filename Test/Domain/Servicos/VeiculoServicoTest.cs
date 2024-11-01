using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.infraestrutura.Db;

namespace Test.Domain.Servicos;

[TestClass]
public class VeiculoServicoTeste
{
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

        var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DbContexto(configuration);
    }
    
    [TestMethod]
    public void TestandoSalvarVeiculo()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        var veiculo = new Veiculo();
        veiculo.Id = 1;
        veiculo.Nome = "testeNome";
        veiculo.Marca = "testeMarca";
        veiculo.Ano = 2000;

        var veiculoServico = new VeiculoServico(context);

        veiculoServico.Incluir(veiculo);

        Assert.AreEqual(1, veiculoServico.Todos(1)?.Count());
    }

    [TestMethod]
    public void TestandoBuscaPorId()
    {
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        var veiculo = new Veiculo();
        veiculo.Id = 1;
        veiculo.Nome = "testeNome";
        veiculo.Marca = "testeMarca";
        veiculo.Ano = 2000;

        var veiculoServico = new VeiculoServico(context);

        veiculoServico.Incluir(veiculo);
        var veiculoBanco = veiculoServico.BuscaPorId(veiculo.Id);

        Assert.AreEqual(1, veiculoBanco?.Id);
    }
}