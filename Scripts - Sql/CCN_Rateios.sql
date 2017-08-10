USE [ColaComNoisFutsal]
GO

/****** Object:  Table [dbo].[CCN_Rateios]    Script Date: 30/06/2017 14:38:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CCN_Rateios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdJogador] [int] NOT NULL,
	[IdDespesa] [int] NOT NULL,
	[Valor] [decimal](18, 0) NOT NULL,
	[Data_Pagamento] [datetime] NOT NULL,
	[IdRecebedor] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Despesas_Jogadores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CCN_Rateios]  WITH CHECK ADD  CONSTRAINT [FK_Despesas_Jogadores_Despesas] FOREIGN KEY([IdDespesa])
REFERENCES [dbo].[CCN_Despesas] ([Id])
GO

ALTER TABLE [dbo].[CCN_Rateios] CHECK CONSTRAINT [FK_Despesas_Jogadores_Despesas]
GO

ALTER TABLE [dbo].[CCN_Rateios]  WITH CHECK ADD  CONSTRAINT [FK_Despesas_Jogadores_Despesas_Jogadores] FOREIGN KEY([IdJogador])
REFERENCES [dbo].[CCN_Jogadores] ([Id])
GO

ALTER TABLE [dbo].[CCN_Rateios] CHECK CONSTRAINT [FK_Despesas_Jogadores_Despesas_Jogadores]
GO

