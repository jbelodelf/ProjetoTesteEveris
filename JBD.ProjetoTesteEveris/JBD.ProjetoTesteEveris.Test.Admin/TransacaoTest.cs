using ExpectedObjects;
using JBD.ProjetoTesteEveris.Domain.DTOS;
using JBD.ProjetoTesteEveris.Domain.Entitys;
using JBD.ProjetoTesteEveris.Domain.Enuns;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Repository;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Service;
using JBD.ProjetoTesteEveris.Domain.Services;
using JBD.ProjetoTesteEveris.Domain.Services.Processar;
using JBD.ProjetoTesteEveris.Domain.Services.Validar;
using Moq;
using System;
using Xunit;

namespace JBD.ProjetoTesteEveris.Test.Admin
{
    public class TransacaoTest
    {
        [Fact]
        public void DeveCrioarUmaTransacao()
        {
            //Arrange
            var TransacaoEsperada = new
            {
                CdTransacao = (int)0,
                AgContaOrigem = "0123",
                NumContaOrigem = "101234",
                AgContaDestino = "0123",
                NumContaDestino = "104321",
                TipoOperacao = (int)TipoOperacaoEnum.Credito,
                ValorOperacao = 100.00M,
                DataOperacao = DateTime.Now,
            };

            var contaTransacaoEntity = new ContaTransacaoEntity();
            var contaTransacaoEntityValida = contaTransacaoEntity.ValidaContaTransacaoEntity(
                    TransacaoEsperada.CdTransacao,
                    TransacaoEsperada.AgContaOrigem,
                    TransacaoEsperada.NumContaOrigem,
                    TransacaoEsperada.AgContaDestino,
                    TransacaoEsperada.NumContaDestino,
                    TransacaoEsperada.TipoOperacao,
                    TransacaoEsperada.ValorOperacao,
                    TransacaoEsperada.DataOperacao
                );

            TransacaoEsperada.ToExpectedObject().ShouldMatch(contaTransacaoEntityValida);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveTransacaoConterUmaAgenciaOrigemNulaOuVazia(string AgContaOrigemInvalida)
        {
            //Arrange
            var TransacaoEsperada = new
            {
                CdTransacao = (int)0,
                AgContaOrigem = "0123",
                NumContaOrigem = "101234",
                AgContaDestino = "0123",
                NumContaDestino = "104321",
                TipoOperacao = (int)TipoOperacaoEnum.Credito,
                ValorOperacao = 100.00M,
                DataOperacao = DateTime.Now,
            };
            var contaTransacaoEntity = new ContaTransacaoEntity();

            //Assert
            var message = Assert.Throws<ArgumentException>(() =>
            contaTransacaoEntity.ValidaContaTransacaoEntity(
                    TransacaoEsperada.CdTransacao,
                    AgContaOrigemInvalida,
                    TransacaoEsperada.NumContaOrigem,
                    TransacaoEsperada.AgContaDestino,
                    TransacaoEsperada.NumContaDestino,
                    TransacaoEsperada.TipoOperacao,
                    TransacaoEsperada.ValorOperacao,
                    TransacaoEsperada.DataOperacao
                )
            ).Message;
            Assert.Equal("Agência origem inválida", message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveTransacaoConterUmaConntaOrigemNulaOuVazia(string NumContaOrigemInvalida)
        {
            //Arrange
            var TransacaoEsperada = new
            {
                CdTransacao = (int)0,
                AgContaOrigem = "0123",
                NumContaOrigem = "101234",
                AgContaDestino = "0123",
                NumContaDestino = "104321",
                TipoOperacao = (int)TipoOperacaoEnum.Credito,
                ValorOperacao = 100.00M,
                DataOperacao = DateTime.Now,
            };
            var contaTransacaoEntity = new ContaTransacaoEntity();

            //Assert
            var message = Assert.Throws<ArgumentException>(() =>
            contaTransacaoEntity.ValidaContaTransacaoEntity(
                    TransacaoEsperada.CdTransacao,
                    TransacaoEsperada.AgContaOrigem,
                    NumContaOrigemInvalida,
                    TransacaoEsperada.AgContaDestino,
                    TransacaoEsperada.NumContaDestino,
                    TransacaoEsperada.TipoOperacao,
                    TransacaoEsperada.ValorOperacao,
                    TransacaoEsperada.DataOperacao
                )
            ).Message;
            Assert.Equal("Conta origem inválida", message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveTransacaoConterUmaAgContaDestinoNulaOuVazia(string AgContaDestinoInvalida)
        {
            //Arrange
            var TransacaoEsperada = new
            {
                CdTransacao = (int)0,
                AgContaOrigem = "0123",
                NumContaOrigem = "101234",
                AgContaDestino = "0123",
                NumContaDestino = "104321",
                TipoOperacao = (int)TipoOperacaoEnum.Credito,
                ValorOperacao = 100.00M,
                DataOperacao = DateTime.Now,
            };
            var contaTransacaoEntity = new ContaTransacaoEntity();

            //Assert
            var message = Assert.Throws<ArgumentException>(() =>
            contaTransacaoEntity.ValidaContaTransacaoEntity(
                    TransacaoEsperada.CdTransacao,
                    TransacaoEsperada.AgContaOrigem,
                    TransacaoEsperada.NumContaOrigem,
                    AgContaDestinoInvalida,
                    TransacaoEsperada.NumContaDestino,
                    TransacaoEsperada.TipoOperacao,
                    TransacaoEsperada.ValorOperacao,
                    TransacaoEsperada.DataOperacao
                )
            ).Message;
            Assert.Equal("Agência destino inválida", message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveTransacaoConterUmaNumContaDestinoNulaOuVazia(string NumContaDestinoInvalida)
        {
            //Arrange
            var TransacaoEsperada = new
            {
                CdTransacao = (int)0,
                AgContaOrigem = "0123",
                NumContaOrigem = "101234",
                AgContaDestino = "0123",
                NumContaDestino = "104321",
                TipoOperacao = (int)TipoOperacaoEnum.Credito,
                ValorOperacao = 100.00M,
                DataOperacao = DateTime.Now,
            };
            var contaTransacaoEntity = new ContaTransacaoEntity();

            //Assert
            var message = Assert.Throws<ArgumentException>(() =>
            contaTransacaoEntity.ValidaContaTransacaoEntity(
                    TransacaoEsperada.CdTransacao,
                    TransacaoEsperada.AgContaOrigem,
                    TransacaoEsperada.NumContaOrigem,
                    TransacaoEsperada.AgContaDestino,
                    NumContaDestinoInvalida,
                    TransacaoEsperada.TipoOperacao,
                    TransacaoEsperada.ValorOperacao,
                    TransacaoEsperada.DataOperacao
                )
            ).Message;
            Assert.Equal("Conta destino inválida", message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        public void NaoDeveTransacaoConterUmTipoOperacaoMenorQue1NemMairQue2(int TipoOperacaoInvalida)
        {
            //Arrange
            var TransacaoEsperada = new
            {
                CdTransacao = (int)0,
                AgContaOrigem = "0123",
                NumContaOrigem = "101234",
                AgContaDestino = "0123",
                NumContaDestino = "104321",
                TipoOperacao = (int)TipoOperacaoEnum.Credito,
                ValorOperacao = 100.00M,
                DataOperacao = DateTime.Now,
            };
            var contaTransacaoEntity = new ContaTransacaoEntity();

            //Assert
            var message = Assert.Throws<ArgumentException>(() =>
            contaTransacaoEntity.ValidaContaTransacaoEntity(
                    TransacaoEsperada.CdTransacao,
                    TransacaoEsperada.AgContaOrigem,
                    TransacaoEsperada.NumContaOrigem,
                    TransacaoEsperada.AgContaDestino,
                    TransacaoEsperada.NumContaDestino,
                    TipoOperacaoInvalida,
                    TransacaoEsperada.ValorOperacao,
                    TransacaoEsperada.DataOperacao
                )
            ).Message;
            Assert.Equal("Tipo de operação inválido", message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-0)]
        public void NaoDeveTransacaoConterUmValorOperacaoMenorQue1(decimal ValorOperacaoInvalida)
        {
            //Arrange
            var TransacaoEsperada = new
            {
                CdTransacao = (int)0,
                AgContaOrigem = "0123",
                NumContaOrigem = "101234",
                AgContaDestino = "0123",
                NumContaDestino = "104321",
                TipoOperacao = (int)TipoOperacaoEnum.Credito,
                ValorOperacao = 100.00M,
                DataOperacao = DateTime.Now,
            };
            var contaTransacaoEntity = new ContaTransacaoEntity();

            //Assert
            var message = Assert.Throws<ArgumentException>(() =>
            contaTransacaoEntity.ValidaContaTransacaoEntity(
                    TransacaoEsperada.CdTransacao,
                    TransacaoEsperada.AgContaOrigem,
                    TransacaoEsperada.NumContaOrigem,
                    TransacaoEsperada.AgContaDestino,
                    TransacaoEsperada.NumContaDestino,
                    TransacaoEsperada.TipoOperacao,
                    ValorOperacaoInvalida,
                    TransacaoEsperada.DataOperacao
                )
            ).Message;
            Assert.Equal("Valor da transação inválida", message);
        }

        [Theory]
        [InlineData(null)]
        public void NaoDeveTransacaoConterUmaDataOperacaoNula(DateTime DataOperacaoInvalida)
        {
            //Arrange
            var TransacaoEsperada = new
            {
                CdTransacao = (int)0,
                AgContaOrigem = "0123",
                NumContaOrigem = "101234",
                AgContaDestino = "0123",
                NumContaDestino = "104321",
                TipoOperacao = (int)TipoOperacaoEnum.Credito,
                ValorOperacao = 100.00M,
                DataOperacao = DateTime.Now,
            };
            var contaTransacaoEntity = new ContaTransacaoEntity();

            //Assert
            var message = Assert.Throws<ArgumentException>(() =>
            contaTransacaoEntity.ValidaContaTransacaoEntity(
                    TransacaoEsperada.CdTransacao,
                    TransacaoEsperada.AgContaOrigem,
                    TransacaoEsperada.NumContaOrigem,
                    TransacaoEsperada.AgContaDestino,
                    TransacaoEsperada.NumContaDestino,
                    TransacaoEsperada.TipoOperacao,
                    TransacaoEsperada.ValorOperacao,
                    DataOperacaoInvalida
                )
            ).Message;
            Assert.Equal("Data da transação inválida", message);
        }

        //[Fact]
        //public async void DeveValidarUmaTansacao()
        //{
        //    //Arrange
        //    var TransacaoEsperadaDTO = new ContaTransacaoDTO()
        //    {
        //        CdTransacao = (int)0,
        //        AgContaOrigem = "0123",
        //        NumContaOrigem = "101234",
        //        AgContaDestino = "0123",
        //        NumContaDestino = "104321",
        //        TipoOperacao = (int)TipoOperacaoEnum.Credito,
        //        ValorOperacao = 250.00M,
        //        DataOperacao = DateTime.Now,
        //    };

        //    var contaRepositoryMock = new Mock<IContaRepository>();
        //    var validarTransacaoServiceMock = new Mock<IValidarTransacaoService>();
        //    var validarTransacaoRepositorio = new ValidarTransacao(contaRepositoryMock.Object);

        //    //Act
        //    validarTransacaoRepositorio.TransacaoValida(TransacaoEsperadaDTO);

        //    //Assert
        //    validarTransacaoServiceMock.Verify(r => r.TransacaoValida(It.IsAny<ContaTransacaoDTO>()));
        //}


        //[Fact]
        //public async void DeveProcessarUmaTansacao()
        //{
        //    //Arrange
        //    var TransacaoEsperadaDTO = new ContaTransacaoDTO()
        //    {
        //        CdTransacao = (int)0,
        //        AgContaOrigem = "0123",
        //        NumContaOrigem = "101234",
        //        AgContaDestino = "0123",
        //        NumContaDestino = "104321",
        //        TipoOperacao = (int)TipoOperacaoEnum.Credito,
        //        ValorOperacao = 250.00M,
        //        DataOperacao = DateTime.Now,
        //    };

        //    var processamentoDeTransacaoServiceMock = new Mock<IProcessamentoDeTransacaoService>();
        //    var contaRepositoryMock = new Mock<IContaRepository>();
        //    var historicoRepositoryMock = new Mock<IContaMovimentoHistoricoRepository>();

        //    var processamentoDeTransacao = new ProcessamentoDeTransacao(contaRepositoryMock.Object, historicoRepositoryMock.Object);

        //    //Act
        //    processamentoDeTransacao.ProcessarTransacao(TransacaoEsperadaDTO);

        //    //Assert
        //    processamentoDeTransacaoServiceMock.Verify(r => r.ProcessarTransacao(It.IsAny<ContaTransacaoDTO>()));
        //}


        //[Fact]
        //public async void DeveSalvarUmaTansacao()
        //{
        //    //Arrange
        //    var TransacaoEsperadaDTO = new ContaTransacaoDTO()
        //    {
        //        CdTransacao = (int)0,
        //        AgContaOrigem = "0123",
        //        NumContaOrigem = "101234",
        //        AgContaDestino = "0123",
        //        NumContaDestino = "104321",
        //        TipoOperacao = (int)TipoOperacaoEnum.Credito,
        //        ValorOperacao = 250.00M,
        //        DataOperacao = DateTime.Now,
        //    };

        //    var contaRepositoryMock = new Mock<IContaRepository>();
        //    var transacaoRepositoryMock = new Mock<IContaTransacaoRepository>();
        //    var historicoRepositoryMock = new Mock<IContaMovimentoHistoricoRepository>();

        //    var validarTransacaoServiceMock = new Mock<IValidarTransacaoService>();
        //    var processamentoDeTransacaoServiceMock = new Mock<IProcessamentoDeTransacaoService>();

        //    var contaTransacaoRepositorio = new ContaTransacaoRepositoryService(transacaoRepositoryMock.Object, contaRepositoryMock.Object, historicoRepositoryMock.Object, validarTransacaoServiceMock.Object, processamentoDeTransacaoServiceMock.Object);

        //    //Act
        //    contaTransacaoRepositorio.Salvar(TransacaoEsperadaDTO);

        //    //Assert
        //    transacaoRepositoryMock.Verify(r => r.Salvar(It.IsAny<ContaTransacaoDTO>()));
        //}
    }
}
 