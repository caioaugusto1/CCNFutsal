USE [ColaComNoisFutsal]
GO

/****** Object:  Table [dbo].[CCN_Adversario]    Script Date: 30/06/2017 14:36:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CCN_Adversario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Responsavel] [varchar](30) NOT NULL,
	[Telefone] [varchar](11) NOT NULL,
	[Nota] [char](1) NOT NULL,
	[Observacao] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Adversario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

