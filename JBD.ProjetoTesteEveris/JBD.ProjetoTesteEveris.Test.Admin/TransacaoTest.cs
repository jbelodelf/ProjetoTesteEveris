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
using System.Collections.Generic;
using Xunit;

namespace JBD.ProjetoTesteEveris.Test.Admin
{
    public class TransacaoTest
    {
        ContaTransacaoDTO _TransacaoEsperadaDTO;
        public TransacaoTest()
        {
            _TransacaoEsperadaDTO = new ContaTransacaoDTO()
            {
                CdTransacao = (int)0,
                AgContaOrigem = "0123",
                NumContaOrigem = "10123",
                AgContaDestino = "0123",
                NumContaDestino = "20125",
                TipoOperacao = (int)TipoOperacaoEnum.Credito,
                ValorOperacao = 250.00M,
                DataOperacao = DateTime.Now,
            };
        }

        #region Bloco de testes Entidade - Ok
        [Fact]
        public void DeveCrioarUmaTransacao()
        {
            //Arrange
            var contaTransacaoEntity = new ContaTransacaoEntity();
            var contaTransacaoEntityValida = contaTransacaoEntity.ValidaContaTransacaoEntity(
                    _TransacaoEsperadaDTO.CdTransacao,
                    _TransacaoEsperadaDTO.AgContaOrigem,
                    _TransacaoEsperadaDTO.NumContaOrigem,
                    _TransacaoEsperadaDTO.AgContaDestino,
                    _TransacaoEsperadaDTO.NumContaDestino,
                    _TransacaoEsperadaDTO.TipoOperacao,
                    _TransacaoEsperadaDTO.ValorOperacao,
                    _TransacaoEsperadaDTO.DataOperacao
                );

            //Assert
            _TransacaoEsperadaDTO.ToExpectedObject().ShouldMatch(contaTransacaoEntityValida);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveTransacaoConterUmaAgenciaOrigemNulaOuVazia(string AgContaOrigemInvalida)
        {
            //Act
            var message = Assert.Throws<ArgumentException>(() =>
            new ContaTransacaoEntity().ValidaContaTransacaoEntity(
                    _TransacaoEsperadaDTO.CdTransacao,
                    AgContaOrigemInvalida,
                    _TransacaoEsperadaDTO.NumContaOrigem,
                    _TransacaoEsperadaDTO.AgContaDestino,
                    _TransacaoEsperadaDTO.NumContaDestino,
                    _TransacaoEsperadaDTO.TipoOperacao,
                    _TransacaoEsperadaDTO.ValorOperacao,
                    _TransacaoEsperadaDTO.DataOperacao
                )
            ).Message;

            //Assert
            Assert.Equal("Agência origem inválida", message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveTransacaoConterUmaConntaOrigemNulaOuVazia(string NumContaOrigemInvalida)
        {
            //Act
            var message = Assert.Throws<ArgumentException>(() =>
            new ContaTransacaoEntity().ValidaContaTransacaoEntity(
                    _TransacaoEsperadaDTO.CdTransacao,
                    _TransacaoEsperadaDTO.AgContaOrigem,
                    NumContaOrigemInvalida,
                    _TransacaoEsperadaDTO.AgContaDestino,
                    _TransacaoEsperadaDTO.NumContaDestino,
                    _TransacaoEsperadaDTO.TipoOperacao,
                    _TransacaoEsperadaDTO.ValorOperacao,
                    _TransacaoEsperadaDTO.DataOperacao
                )
            ).Message;

            //Assert
            Assert.Equal("Conta origem inválida", message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveTransacaoConterUmaAgContaDestinoNulaOuVazia(string AgContaDestinoInvalida)
        {
            //Act
            var message = Assert.Throws<ArgumentException>(() =>
            new ContaTransacaoEntity().ValidaContaTransacaoEntity(
                    _TransacaoEsperadaDTO.CdTransacao,
                    _TransacaoEsperadaDTO.AgContaOrigem,
                    _TransacaoEsperadaDTO.NumContaOrigem,
                    AgContaDestinoInvalida,
                    _TransacaoEsperadaDTO.NumContaDestino,
                    _TransacaoEsperadaDTO.TipoOperacao,
                    _TransacaoEsperadaDTO.ValorOperacao,
                    _TransacaoEsperadaDTO.DataOperacao
                )
            ).Message;

            //Assert
            Assert.Equal("Agência destino inválida", message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveTransacaoConterUmaNumContaDestinoNulaOuVazia(string NumContaDestinoInvalida)
        {
            //ct
            var message = Assert.Throws<ArgumentException>(() =>
            new ContaTransacaoEntity().ValidaContaTransacaoEntity(
                    _TransacaoEsperadaDTO.CdTransacao,
                    _TransacaoEsperadaDTO.AgContaOrigem,
                    _TransacaoEsperadaDTO.NumContaOrigem,
                    _TransacaoEsperadaDTO.AgContaDestino,
                    NumContaDestinoInvalida,
                    _TransacaoEsperadaDTO.TipoOperacao,
                    _TransacaoEsperadaDTO.ValorOperacao,
                    _TransacaoEsperadaDTO.DataOperacao
                )
            ).Message;

            //Assert
            Assert.Equal("Conta destino inválida", message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-0)]
        public void NaoDeveTransacaoConterUmValorOperacaoMenorQue1(decimal ValorOperacaoInvalida)
        {
            //Act
            var message = Assert.Throws<ArgumentException>(() =>
            new ContaTransacaoEntity().ValidaContaTransacaoEntity(
                    _TransacaoEsperadaDTO.CdTransacao,
                    _TransacaoEsperadaDTO.AgContaOrigem,
                    _TransacaoEsperadaDTO.NumContaOrigem,
                    _TransacaoEsperadaDTO.AgContaDestino,
                    _TransacaoEsperadaDTO.NumContaDestino,
                    _TransacaoEsperadaDTO.TipoOperacao,
                    ValorOperacaoInvalida,
                    _TransacaoEsperadaDTO.DataOperacao
                )
            ).Message;

            //Assert
            Assert.Equal("Valor da transação inválida", message);
        }

        [Theory]
        [InlineData(null)]
        public void NaoDeveTransacaoConterUmaDataOperacaoNula(DateTime DataOperacaoInvalida)
        {
            //Act
            var message = Assert.Throws<ArgumentException>(() =>
            new ContaTransacaoEntity().ValidaContaTransacaoEntity(
                    _TransacaoEsperadaDTO.CdTransacao,
                    _TransacaoEsperadaDTO.AgContaOrigem,
                    _TransacaoEsperadaDTO.NumContaOrigem,
                    _TransacaoEsperadaDTO.AgContaDestino,
                    _TransacaoEsperadaDTO.NumContaDestino,
                    _TransacaoEsperadaDTO.TipoOperacao,
                    _TransacaoEsperadaDTO.ValorOperacao,
                    DataOperacaoInvalida
                )
            ).Message;

            //Assert
            Assert.Equal("Data da transação inválida", message);
        }
        #endregion

        #region Bloco teste com MOQ Validação - Ok
        [Fact]
        public void DeveValidarUmaTansacaoPreenchidaCorretamente()
        {
            //Arrange
            var contaRepositoryMock = new Mock<IContaRepository>();
            var validarTransacaoRepositorio = new ValidarTransacao(contaRepositoryMock.Object);

            //Act
            var retorno = validarTransacaoRepositorio.TransacaoValida(_TransacaoEsperadaDTO);

            //Assert
            Assert.True(retorno);
        }

        [Fact]
        public void DeveValidarUmaTansacaoNOk()
        {
            //Arrange
            _TransacaoEsperadaDTO.AgContaOrigem = "";

            var contaRepositoryMock = new Mock<IContaRepository>();
            var validarTransacaoRepositorio = new ValidarTransacao(contaRepositoryMock.Object);

            //Act
            var message = Assert.Throws<ArgumentException>(() => validarTransacaoRepositorio.TransacaoValida(_TransacaoEsperadaDTO)).Message;

            //Assert
            Assert.Equal("Agência origem inválida", message);
        }

        [Fact]
        public void DeveValidarSeAsDuasContasOrigem_E_DestinoEstaoOk()
        {
            //Arrange
            var contaRepositoryMock = new Mock<IContaRepository>();
            contaRepositoryMock.Setup(c => c.ListarContas(_TransacaoEsperadaDTO.AgContaOrigem, _TransacaoEsperadaDTO.NumContaOrigem, _TransacaoEsperadaDTO.AgContaDestino, _TransacaoEsperadaDTO.NumContaDestino))
                .Returns(
                    new List<ContaDTO>()
                        {
                            new ContaDTO { CdConta = 1, ContaAgencia = "0123", ContaNumero = "10123", ContaTipo = 1, ContaStatus = 1, Saldo = 5450.00M, DataAbertura = Convert.ToDateTime("2019-07-13 13:15:32") },
                            new ContaDTO { CdConta = 2, ContaAgencia = "0123", ContaNumero = "20125", ContaTipo = 1, ContaStatus = 1, Saldo = 14550.00M, DataAbertura = Convert.ToDateTime("2019-07-13 13:15:32") }
                        }
                );

            var validarTransacaoRepositorio = new ValidarTransacao(contaRepositoryMock.Object);

            //Act
            var IsValido = validarTransacaoRepositorio.ValidaContasOrigemDestino(_TransacaoEsperadaDTO);

            //Assert
            Assert.True(IsValido);
        }

        [Fact]
        public void NaoDeveEncontrarContaDestino()
        {
            //Arrange
            _TransacaoEsperadaDTO.NumContaDestino = "201256"; // Errada

            var contaRepositoryMock = new Mock<IContaRepository>();
            contaRepositoryMock.Setup(c => c.ListarContas(_TransacaoEsperadaDTO.AgContaOrigem, _TransacaoEsperadaDTO.NumContaOrigem, _TransacaoEsperadaDTO.AgContaDestino, _TransacaoEsperadaDTO.NumContaDestino))
                .Returns(
                    new List<ContaDTO>()
                        {
                            new ContaDTO { CdConta = 1, ContaAgencia = "0123", ContaNumero = "10123", ContaTipo = 1, ContaStatus = 1, Saldo = 5450.00M, DataAbertura = Convert.ToDateTime("2019-07-13 13:15:32") },
                            new ContaDTO { CdConta = 2, ContaAgencia = "0123", ContaNumero = "20125", ContaTipo = 1, ContaStatus = 1, Saldo = 14550.00M, DataAbertura = Convert.ToDateTime("2019-07-13 13:15:32") }
                        }
                );

            var validarTransacaoRepositorio = new ValidarTransacao(contaRepositoryMock.Object);

            //Act
            var message = Assert.Throws<ArgumentException>(() => validarTransacaoRepositorio.ValidaContasOrigemDestino(_TransacaoEsperadaDTO)).Message;

            //Assert
            Assert.Equal("Conta destino não localizada", message);
        }

        [Fact]
        public void NaoDeveEncontrarContaOrigem()
        {
            //Arrange
            _TransacaoEsperadaDTO.NumContaOrigem = "101235"; //Conta errada

            var contaRepositoryMock = new Mock<IContaRepository>();
            contaRepositoryMock.Setup(c => c.ListarContas(_TransacaoEsperadaDTO.AgContaOrigem, _TransacaoEsperadaDTO.NumContaOrigem, _TransacaoEsperadaDTO.AgContaDestino, _TransacaoEsperadaDTO.NumContaDestino))
                .Returns(
                    new List<ContaDTO>()
                        {
                            new ContaDTO { CdConta = 1, ContaAgencia = "0123", ContaNumero = "10123", ContaTipo = 1, ContaStatus = 1, Saldo = 5450.00M, DataAbertura = Convert.ToDateTime("2019-07-13 13:15:32") },
                            new ContaDTO { CdConta = 2, ContaAgencia = "0123", ContaNumero = "20125", ContaTipo = 1, ContaStatus = 1, Saldo = 14550.00M, DataAbertura = Convert.ToDateTime("2019-07-13 13:15:32") }
                        }
                );

            var validarTransacaoRepositorio = new ValidarTransacao(contaRepositoryMock.Object);

            //Act
            var message = Assert.Throws<ArgumentException>(() => validarTransacaoRepositorio.ValidaContasOrigemDestino(_TransacaoEsperadaDTO)).Message;

            //Assert
            Assert.Equal("Conta origem não localizada", message);
        }

        [Fact]
        public void DeveEncontrarContaOrigem_ComSaldoInsuficiente()
        {
            //Arrange

            var contaRepositoryMock = new Mock<IContaRepository>();
            contaRepositoryMock.Setup(c => c.ListarContas(_TransacaoEsperadaDTO.AgContaOrigem, _TransacaoEsperadaDTO.NumContaOrigem, _TransacaoEsperadaDTO.AgContaDestino, _TransacaoEsperadaDTO.NumContaDestino))
                .Returns(
                    new List<ContaDTO>()
                        {
                            new ContaDTO { CdConta = 1, ContaAgencia = "0123", ContaNumero = "10123", ContaTipo = 1, ContaStatus = 1, Saldo = 50.00M, DataAbertura = Convert.ToDateTime("2019-07-13 13:15:32") },
                            new ContaDTO { CdConta = 2, ContaAgencia = "0123", ContaNumero = "20125", ContaTipo = 1, ContaStatus = 1, Saldo = 14550.00M, DataAbertura = Convert.ToDateTime("2019-07-13 13:15:32") }
                        }
                );

            var validarTransacaoRepositorio = new ValidarTransacao(contaRepositoryMock.Object);

            //Act
            var message = Assert.Throws<ArgumentException>(() => validarTransacaoRepositorio.ValidaContasOrigemDestino(_TransacaoEsperadaDTO)).Message;

            //Assert
            Assert.Equal("Saldo insuficiente", message);
        }
        #endregion

        #region Bloco de teste com MOQ Processamento
        [Fact]
        public void DeveExecutarTransacao_E_AtualizarSaldoDasContasOrigem_E_Destino()
        {
            //Arrange
            var contaMovimentoHistoricoRepositoryMock = new Mock<IContaMovimentoHistoricoRepository>();
            var contaRepositoryMock = new Mock<IContaRepository>();
            contaRepositoryMock.Setup(c => c.ListarContas(_TransacaoEsperadaDTO.AgContaOrigem, _TransacaoEsperadaDTO.NumContaOrigem, _TransacaoEsperadaDTO.AgContaDestino, _TransacaoEsperadaDTO.NumContaDestino))
                .Returns(
                    new List<ContaDTO>()
                        {
                            new ContaDTO { CdConta = 1, ContaAgencia = "0123", ContaNumero = "10123", ContaTipo = 1, ContaStatus = 1, Saldo = 5450.00M, DataAbertura = Convert.ToDateTime("2019-07-13 13:15:32") },
                            new ContaDTO { CdConta = 2, ContaAgencia = "0123", ContaNumero = "20125", ContaTipo = 1, ContaStatus = 1, Saldo = 14550.00M, DataAbertura = Convert.ToDateTime("2019-07-13 13:15:32") }
                        }
                );

            var processamentoTransacaoRepositorio = new ProcessamentoDeTransacao(contaRepositoryMock.Object, contaMovimentoHistoricoRepositoryMock.Object);

            //Act
            var IsValido = processamentoTransacaoRepositorio.ProcessarTransacao(_TransacaoEsperadaDTO);

            //Assert
            Assert.True(IsValido);
        }
        #endregion

        #region Bloco de teste com MOQ SalvarContaTransacao
        [Fact]
        public void DeveSalvarTransacao()
        {
            //Arrange
            var contaTransacaoRepositoryMock = new Mock<IContaTransacaoRepository>();
            var contaRepositoryMock = new Mock<IContaRepository>();
            var contaMovimentoHistoricoRepositoryMock = new Mock<IContaMovimentoHistoricoRepository>();
            var validarTransacaoServiceMock = new Mock<IValidarTransacaoService>();
            var processamentoDeTransacaoServiceMock = new Mock<IProcessamentoDeTransacaoService>();

            contaRepositoryMock.Setup(c => c.ListarContas(_TransacaoEsperadaDTO.AgContaOrigem, _TransacaoEsperadaDTO.NumContaOrigem, _TransacaoEsperadaDTO.AgContaDestino, _TransacaoEsperadaDTO.NumContaDestino))
                .Returns(
                    new List<ContaDTO>()
                        {
                            new ContaDTO { CdConta = 1, ContaAgencia = "0123", ContaNumero = "10123", ContaTipo = 1, ContaStatus = 1, Saldo = 5450.00M, DataAbertura = Convert.ToDateTime("2019-07-13 13:15:32") },
                            new ContaDTO { CdConta = 2, ContaAgencia = "0123", ContaNumero = "20125", ContaTipo = 1, ContaStatus = 1, Saldo = 14550.00M, DataAbertura = Convert.ToDateTime("2019-07-13 13:15:32") }
                        }
                );

            validarTransacaoServiceMock.Setup(c => c.TransacaoValida(_TransacaoEsperadaDTO)).Returns(true);
            validarTransacaoServiceMock.Setup(c => c.ValidaContasOrigemDestino(_TransacaoEsperadaDTO)).Returns(true);

            processamentoDeTransacaoServiceMock.Setup(t => t.ProcessarTransacao(_TransacaoEsperadaDTO)).Returns(true);

            contaTransacaoRepositoryMock.Setup(c => c.Salvar(_TransacaoEsperadaDTO));

            var contaTransacaoRepositoryService = new ContaTransacaoRepositoryService(contaTransacaoRepositoryMock.Object, contaRepositoryMock.Object, contaMovimentoHistoricoRepositoryMock.Object, validarTransacaoServiceMock.Object, processamentoDeTransacaoServiceMock.Object);

            //Act
            contaTransacaoRepositoryService.Salvar(_TransacaoEsperadaDTO);

            //Assert
            contaTransacaoRepositoryMock.Verify(t => t.Salvar(_TransacaoEsperadaDTO));
        }
        #endregion
    }
}
