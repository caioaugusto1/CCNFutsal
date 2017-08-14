USE [ColaComNoisFutsal]
GO

/****** Object:  Table [dbo].[CCN_Jogadores]    Script Date: 30/06/2017 14:37:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CCN_Jogadores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[RG] [varchar](9) NOT NULL,
	[Data_Nascimento] [datetime] NOT NULL,
	[Data_Admissao] [datetime] NOT NULL,
	[Data_Demissao] [datetime] NULL,
	[Comissao] [bit] NOT NULL,
 CONSTRAINT [PK_Jogadores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

