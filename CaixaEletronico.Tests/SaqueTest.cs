using CaixaEletronico.Model.Enums;
using CaixaEletronico.Model.DTO;
using CaixaEletronico.Services;
using CaixaEletronico.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CaixaEletronico.Model;

namespace CaixaEletronico.Tests
{
    [TestClass]
    public class SaqueTest
    {
        [TestMethod]
        public void SaqueService_EstaNoLimite_SacaValorMaiorQueLimite()
        {
            // Arrange
            var configuracaoMock = new Mock<IConfiguracaoSaqueService>();

            configuracaoMock.Setup(o => o.IniciaCaixaEletronico()).Returns(new ConfiguracaoSaque
            {
                NotasDisponiveis = TipoNota.Dois | TipoNota.Cinco | TipoNota.Dez | TipoNota.Vinte | TipoNota.Cinquenta | TipoNota.Cem,
                ValorLimiteSaque = 1500
            });

            SaqueService saqueService = new SaqueService(configuracaoMock.Object);

            // Act
            var resultado = saqueService.EstaNoLimite(new SaqueDTO { ValorRequisitado = 1501 });

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void SaqueService_EstaNoLimite_SacaValorMenorQueLimite()
        {
            // Arrange
            var configuracaoMock = new Mock<IConfiguracaoSaqueService>();

            configuracaoMock.Setup(o => o.IniciaCaixaEletronico()).Returns(new ConfiguracaoSaque
            {
                NotasDisponiveis = TipoNota.Dois | TipoNota.Cinco | TipoNota.Dez | TipoNota.Vinte | TipoNota.Cinquenta | TipoNota.Cem,
                ValorLimiteSaque = 1500
            });

            SaqueService saqueService = new SaqueService(configuracaoMock.Object);

            // Act
            var resultado = saqueService.EstaNoLimite(new SaqueDTO { ValorRequisitado = 1499 });

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void SaqueService_EstaNoLimite_SacaValorNoLimite()
        {
            // Arrange
            var configuracaoMock = new Mock<IConfiguracaoSaqueService>();

            configuracaoMock.Setup(o => o.IniciaCaixaEletronico()).Returns(new ConfiguracaoSaque
            {
                NotasDisponiveis = TipoNota.Dois | TipoNota.Cinco | TipoNota.Dez | TipoNota.Vinte | TipoNota.Cinquenta | TipoNota.Cem,
                ValorLimiteSaque = 1500
            });

            SaqueService saqueService = new SaqueService(configuracaoMock.Object);

            // Act
            var resultado = saqueService.EstaNoLimite(new SaqueDTO { ValorRequisitado = 1500 });

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void SaqueService_ValorRequisitadoValido_SacaValorInvalidoEmNotasDeDois()
        {
            // Arrange
            var configuracaoMock = new Mock<IConfiguracaoSaqueService>();

            configuracaoMock.Setup(o => o.IniciaCaixaEletronico()).Returns(new ConfiguracaoSaque
            {
                NotasDisponiveis = TipoNota.Dois | TipoNota.Cinco | TipoNota.Dez | TipoNota.Vinte | TipoNota.Cinquenta | TipoNota.Cem,
                ValorLimiteSaque = 1500
            });

            SaqueService saqueService = new SaqueService(configuracaoMock.Object);

            // Act
            var resultado = saqueService.ValorRequisitadoValido(new SaqueDTO { ValorRequisitado = 3 });

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void SaqueService_ValorRequisitadoValido_SacaValorInvalidoEmNotasDeDoisECinco()
        {
            // Arrange
            var configuracaoMock = new Mock<IConfiguracaoSaqueService>();

            configuracaoMock.Setup(o => o.IniciaCaixaEletronico()).Returns(new ConfiguracaoSaque
            {
                NotasDisponiveis = TipoNota.Dois | TipoNota.Cinco | TipoNota.Dez | TipoNota.Vinte | TipoNota.Cinquenta | TipoNota.Cem,
                ValorLimiteSaque = 1500
            });

            SaqueService saqueService = new SaqueService(configuracaoMock.Object);

            // Act
            var resultado = saqueService.ValorRequisitadoValido(new SaqueDTO { ValorRequisitado = 8 });

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void SaqueService_ValorRequisitadoValido_SacaValorInvalidoEmNotasDeDoisCincoEDez()
        {
            // Arrange
            var configuracaoMock = new Mock<IConfiguracaoSaqueService>();

            configuracaoMock.Setup(o => o.IniciaCaixaEletronico()).Returns(new ConfiguracaoSaque
            {
                NotasDisponiveis = TipoNota.Dois | TipoNota.Cinco | TipoNota.Dez | TipoNota.Vinte | TipoNota.Cinquenta | TipoNota.Cem,
                ValorLimiteSaque = 1500
            });

            SaqueService saqueService = new SaqueService(configuracaoMock.Object);

            // Act
            var resultado = saqueService.ValorRequisitadoValido(new SaqueDTO { ValorRequisitado = 18 });

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void SaqueService_ValorRequisitadoValido_SacaValorInvalidoEmNotasDeDoisCincoDezEVinte()
        {
            // Arrange
            var configuracaoMock = new Mock<IConfiguracaoSaqueService>();

            configuracaoMock.Setup(o => o.IniciaCaixaEletronico()).Returns(new ConfiguracaoSaque
            {
                NotasDisponiveis = TipoNota.Dois | TipoNota.Cinco | TipoNota.Dez | TipoNota.Vinte | TipoNota.Cinquenta | TipoNota.Cem,
                ValorLimiteSaque = 1500
            });

            SaqueService saqueService = new SaqueService(configuracaoMock.Object);

            // Act
            var resultado = saqueService.ValorRequisitadoValido(new SaqueDTO { ValorRequisitado = 38 });

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void SaqueService_ValorRequisitadoValido_SacaValorInvalidoEmNotasDeDoisCincoDezVinteECiquenta()
        {
            // Arrange
            var configuracaoMock = new Mock<IConfiguracaoSaqueService>();

            configuracaoMock.Setup(o => o.IniciaCaixaEletronico()).Returns(new ConfiguracaoSaque
            {
                NotasDisponiveis = TipoNota.Dois | TipoNota.Cinco | TipoNota.Dez | TipoNota.Vinte | TipoNota.Cinquenta | TipoNota.Cem,
                ValorLimiteSaque = 1500
            });

            SaqueService saqueService = new SaqueService(configuracaoMock.Object);

            // Act
            var resultado = saqueService.ValorRequisitadoValido(new SaqueDTO { ValorRequisitado = 88 });

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void SaqueService_ValorRequisitadoValido_SacaValorInvalidoEmNotasDeDoisCincoDezVinteCiquentaECem()
        {
            // Arrange
            var configuracaoMock = new Mock<IConfiguracaoSaqueService>();

            configuracaoMock.Setup(o => o.IniciaCaixaEletronico()).Returns(new ConfiguracaoSaque
            {
                NotasDisponiveis = TipoNota.Dois | TipoNota.Cinco | TipoNota.Dez | TipoNota.Vinte | TipoNota.Cinquenta | TipoNota.Cem,
                ValorLimiteSaque = 1500
            });

            SaqueService saqueService = new SaqueService(configuracaoMock.Object);

            // Act
            var resultado = saqueService.ValorRequisitadoValido(new SaqueDTO { ValorRequisitado = 188 });

            // Assert
            Assert.IsFalse(resultado);
        }
        
        [TestMethod]
        public void SaqueService_ValorRequisitadoValido_SacaValorInvalidoComValorDecimal()
        {
            // Arrange
            var configuracaoMock = new Mock<IConfiguracaoSaqueService>();

            configuracaoMock.Setup(o => o.IniciaCaixaEletronico()).Returns(new ConfiguracaoSaque
            {
                NotasDisponiveis = TipoNota.Dois | TipoNota.Cinco | TipoNota.Dez | TipoNota.Vinte | TipoNota.Cinquenta | TipoNota.Cem,
                ValorLimiteSaque = 1500
            });

            SaqueService saqueService = new SaqueService(configuracaoMock.Object);

            // Act
            var resultado = saqueService.ValorRequisitadoValido(new SaqueDTO { ValorRequisitado = 220.54m });

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void SaqueService_ValorRequisitadoValido_SacaValorValido()
        {
            // Arrange
            var configuracaoMock = new Mock<IConfiguracaoSaqueService>();

            configuracaoMock.Setup(o => o.IniciaCaixaEletronico()).Returns(new ConfiguracaoSaque
            {
                NotasDisponiveis = TipoNota.Dois | TipoNota.Cinco | TipoNota.Dez | TipoNota.Vinte | TipoNota.Cinquenta | TipoNota.Cem,
                ValorLimiteSaque = 1500
            });

            SaqueService saqueService = new SaqueService(configuracaoMock.Object);

            // Act
            var resultado = saqueService.ValorRequisitadoValido(new SaqueDTO { ValorRequisitado = 389 });

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void SaqueService_ValorRequisitadoValido_SacaValorZero()
        {
            // Arrange
            var configuracaoMock = new Mock<IConfiguracaoSaqueService>();

            configuracaoMock.Setup(o => o.IniciaCaixaEletronico()).Returns(new ConfiguracaoSaque
            {
                NotasDisponiveis = TipoNota.Dois | TipoNota.Cinco | TipoNota.Dez | TipoNota.Vinte | TipoNota.Cinquenta | TipoNota.Cem,
                ValorLimiteSaque = 1500
            });

            SaqueService saqueService = new SaqueService(configuracaoMock.Object);

            // Act
            var resultado = saqueService.ValorRequisitadoValido(new SaqueDTO { ValorRequisitado = 0 });

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void SaqueService_RealizaSaque_SacaValorComSucesso()
        {
            // Arrange
            var configuracaoMock = new Mock<IConfiguracaoSaqueService>();

            configuracaoMock.Setup(o => o.IniciaCaixaEletronico()).Returns(new ConfiguracaoSaque
            {
                NotasDisponiveis = TipoNota.Dois | TipoNota.Cinco | TipoNota.Dez | TipoNota.Vinte | TipoNota.Cinquenta | TipoNota.Cem,
                ValorLimiteSaque = 1500
            });

            SaqueService saqueService = new SaqueService(configuracaoMock.Object);

            // Act
            var resultado = saqueService.RealizaSaque(new SaqueDTO { ValorRequisitado = 389 });

            // Assert
            Assert.AreEqual(resultado[TipoNota.Cem], 3);
            Assert.AreEqual(resultado[TipoNota.Cinquenta], 1);
            Assert.AreEqual(resultado[TipoNota.Vinte], 1);
            Assert.AreEqual(resultado[TipoNota.Dez], 1);
            Assert.AreEqual(resultado[TipoNota.Cinco], 1);
            Assert.AreEqual(resultado[TipoNota.Dois], 2);
        }

        [TestMethod]
        public void SaqueService_RealizaSaque_Saca300ComSucesso()
        {
            // Arrange
            var configuracaoMock = new Mock<IConfiguracaoSaqueService>();

            configuracaoMock.Setup(o => o.IniciaCaixaEletronico()).Returns(new ConfiguracaoSaque
            {
                NotasDisponiveis = TipoNota.Dois | TipoNota.Cinco | TipoNota.Dez | TipoNota.Vinte | TipoNota.Cinquenta | TipoNota.Cem,
                ValorLimiteSaque = 1500
            });

            SaqueService saqueService = new SaqueService(configuracaoMock.Object);

            // Act
            var resultado = saqueService.RealizaSaque(new SaqueDTO { ValorRequisitado = 300 });

            // Assert
            Assert.AreEqual(resultado[TipoNota.Cem], 3);
            Assert.AreEqual(resultado[TipoNota.Cinquenta], 0);
            Assert.AreEqual(resultado[TipoNota.Vinte], 0);
            Assert.AreEqual(resultado[TipoNota.Dez], 0);
            Assert.AreEqual(resultado[TipoNota.Cinco], 0);
            Assert.AreEqual(resultado[TipoNota.Dois], 0);
        }
    }
}
