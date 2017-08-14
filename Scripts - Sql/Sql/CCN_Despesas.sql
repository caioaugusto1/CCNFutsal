USE [ColaComNoisFutsal]
GO

/****** Object:  Table [dbo].[CCN_Despesas]    Script Date: 30/06/2017 14:37:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CCN_Despesas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Valor] [decimal](18, 0) NOT NULL,
	[Data_Vencimento] [datetime] NOT NULL,
	[Data_Pagamento] [datetime] NULL,
	[Status] [char](1) NOT NULL,
	[Observacao] [varchar](200) NULL,
 CONSTRAINT [PK_Despesas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

