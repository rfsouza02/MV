using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaixaEletronico.Model.DTO;
using CaixaEletronico.Services;
using CaixaEletronico.Model;

namespace CaixaEletronico.Tests
{
    [TestClass]
    public class ConfiguracaoTest
    {
        [TestMethod]
        public void ConfiguracaoService_IniciaCaixaEletronico()
        {
            // Arrange
            var configuracaoSaqueService = new ConfiguracaoSaqueService();

            // Act
            ConfiguracaoSaque configuracaoSaqueDTO = configuracaoSaqueService.IniciaCaixaEletronico();

            // Assert
            Assert.AreEqual(configuracaoSaqueDTO.ValorLimiteSaque, 1500);
            Assert.AreEqual(configuracaoSaqueDTO.NotasDisponiveis, TipoNota.Dois | TipoNota.Cinco | TipoNota.Dez | TipoNota.Cinquenta | TipoNota.Cem);
        }
    }
}