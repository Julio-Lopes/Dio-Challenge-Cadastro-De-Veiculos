using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoTeste
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {

        var veiculo = new Veiculo();

        veiculo.Id = 1;
        veiculo.Nome = "testeNome";
        veiculo.Marca = "testeMarca";
        veiculo.Ano = 2000;

        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("testeNome", veiculo.Nome);
        Assert.AreEqual("testeMarca", veiculo.Marca);
        Assert.AreEqual(2000, veiculo.Ano);
    }
}