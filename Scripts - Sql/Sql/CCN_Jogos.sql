USE [ColaComNoisFutsal]
GO

/****** Object:  Table [dbo].[CCN_Jogos]    Script Date: 30/06/2017 14:37:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CCN_Jogos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quadro] [char](1) NOT NULL,
	[Data] [date] NOT NULL,
	[ResultadoColaComNois] [int] NOT NULL,
	[ResultadoAdversario] [int] NOT NULL,
	[Mandante] [bit] NOT NULL,
	[Referente] [char](1) NOT NULL,
	[Observacao] [varchar](250) NOT NULL,
	[IdAdversario] [int] NOT NULL,
 CONSTRAINT [PK_CCN_Jogos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CCN_Jogos]  WITH CHECK ADD  CONSTRAINT [FK_CCN_Jogos_CCN_Adversario] FOREIGN KEY([IdAdversario])
REFERENCES [dbo].[CCN_Adversario] ([Id])
GO

ALTER TABLE [dbo].[CCN_Jogos] CHECK CONSTRAINT [FK_CCN_Jogos_CCN_Adversario]
GO

