USE [AccesosSUA]
GO

/****** Object:  Table [dbo].[ACC_dAplicaciones]    Script Date: 20/02/2019 11:11:13 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

ALTER TABLE [dbo].[ACC_dAplicaciones]
	ADD 
		[esPocket] [char](1) NOT NULL DEFAULT ('N'),
		[tooltip] [varchar](100),
		[imagen] [varchar](100),
		[url] [varchar](100)
	
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'N para No o S para si' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACC_dAplicaciones', @level2type=N'COLUMN',@level2name=N'esPocket'
GO


USE [AccesosSUA]
GO

ALTER TABLE [dbo].[ACC_rdUsuarios_dPerfiles] DROP CONSTRAINT [FK_ACC_rdUsuarios_dPerfiles_ACC_dUsuarios]
GO

ALTER TABLE [dbo].[ACC_rdUsuarios_dPerfiles] DROP CONSTRAINT [FK_ACC_rdUsuarios_dPerfiles_ACC_dPerfiles]
GO

ALTER TABLE [dbo].[ACC_rdUsuarios_dPerfiles] DROP CONSTRAINT [DF_ACC_rdUsuarios_dPerfiles_ts]
GO

/****** Object:  Table [dbo].[ACC_rdUsuarios_dPerfiles]    Script Date: 28/02/2019 11:51:24 a.m. ******/
DROP TABLE [dbo].[ACC_rdUsuarios_dPerfiles]
GO

/****** Object:  Table [dbo].[ACC_rdUsuarios_dPerfiles]    Script Date: 28/02/2019 11:51:24 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO
USE [AccesosSUA]
GO

/****** Object:  Table [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones]    Script Date: 28/02/2019 12:02:05 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones](
	[idUsuario] [smallint] NOT NULL,
	[idPerfilAccion] [numeric](8, 0) NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[ts] [datetime] NOT NULL,
 CONSTRAINT [UQ_ACC_rdUsuarios_dPerfiles_dAcciones] UNIQUE NONCLUSTERED 
(
	[idUsuario] ASC,
	[idPerfilAccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ADD  CONSTRAINT [DF_ACC_rdUsuarios_dPerfiles_dAcciones_ts]  DEFAULT (getdate()) FOR [ts]
GO

ALTER TABLE [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones]  WITH CHECK ADD  CONSTRAINT [FK_ACC_rdUsuarios_dPerfiles_dAcciones_ACC_dUsuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[ACC_dUsuarios] ([id])
GO

ALTER TABLE [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] CHECK CONSTRAINT [FK_ACC_rdUsuarios_dPerfiles_dAcciones_ACC_dUsuarios]
GO

ALTER TABLE [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones]  WITH CHECK ADD  CONSTRAINT [FK_ACC_rdUsuarios_dPerfiles_dAcciones_ACC_rdPerfil_dAcciones] FOREIGN KEY([idPerfilAccion])
REFERENCES [dbo].[ACC_rdPerfil_dAcciones] ([id])
GO

ALTER TABLE [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] CHECK CONSTRAINT [FK_ACC_rdUsuarios_dPerfiles_dAcciones_ACC_rdPerfil_dAcciones]
GO


