USE MASTER

GO

CREATE DATABASE EVERIS_TESTEDB

GO

USE EVERIS_TESTEDB

GO

-----------------------------------------------------------------------------
CREATE TABLE [dbo].[tbConta](
	[CdConta] [int] IDENTITY(1,1) NOT NULL,
	[ContaAgencia] [nvarchar](6) NOT NULL,
	[ContaNumero] [nvarchar](10) NOT NULL,
	[ContaTipo] [int] NOT NULL,
	[ContaStatus] [int] NOT NULL,
	[Saldo] [money] NOT NULL,
	[DataAbertura] [datetime] NOT NULL,
 CONSTRAINT [PK_CdConta] PRIMARY KEY CLUSTERED 
(
	[CdConta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tbConta] ADD DEFAULT ('1900-01-01T00:00:00.000') FOR [DataAbertura]

GO

-----------------------------------------------------------------------------
CREATE TABLE [dbo].[tbContaMovimentoHistorico](
CdHistorico int IDENTITY(1,1) NOT NULL,
CdConta int NOT NULL,
AgConta nvarchar(10) NOT NULL,
NumConta nvarchar(6) NOT NULL,
TipoOperacao int NOT NULL,
SaldoAnterior money NOT NULL,
ValorOperacao money NOT NULL,
SaldoAtual money NOT NULL,
DataOperacao datetime NOT NULL,

CONSTRAINT [PK_CdHistorico] PRIMARY KEY CLUSTERED
(
   [CdHistorico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tbContaMovimentoHistorico]  WITH CHECK ADD  CONSTRAINT [FK_tbContaMovimentoHistorico_tbConta] FOREIGN KEY([CdConta])
REFERENCES [dbo].[tbConta] ([CdConta])
GO

ALTER TABLE [dbo].[tbContaMovimentoHistorico] CHECK CONSTRAINT [FK_tbContaMovimentoHistorico_tbConta]
GO

-----------------------------------------------------------------------------
CREATE TABLE [dbo].[tbContaTransacao](
CdTransacao int IDENTITY(1,1) NOT NULL,
AgContaOrigem nvarchar(6) NOT NULL,
NumContaOrigem nvarchar(10) NOT NULL,
AgContaDestino nvarchar(6) NOT NULL,
NumContaDestino nvarchar(10) NOT NULL,
TipoOperacao int NOT NULL,
ValorOperacao money NOT NULL,
DataOperacao datetime NOT NULL,

CONSTRAINT [PK_CdTransacao] PRIMARY KEY CLUSTERED
(
   [CdTransacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

GO

-----------------------------------------------------------------------------




