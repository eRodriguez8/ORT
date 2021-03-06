USE [CDs]
GO
/****** Object:  Table [dbo].[INV_dCCsActivos]    Script Date: 11/7/2019 11:18:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INV_dCCsActivos](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[idRegion] [tinyint] NOT NULL,
	[cc] [numeric](5, 0) NOT NULL,
	[descripcion] [nvarchar](80) NOT NULL,
	[idb] [numeric](5, 0) NOT NULL,
	[usuario] [nvarchar](50) NOT NULL,
	[ts] [date] NOT NULL CONSTRAINT [DF_INV_dCCsActivos_ts]  DEFAULT (getdate()),
	[estado] [char](1) NOT NULL CONSTRAINT [DF_INV_dCCsActivos_estado]  DEFAULT ('A')
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INV_dDocumentos]    Script Date: 11/7/2019 11:18:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_dDocumentos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Documento] [nvarchar](255) NOT NULL,
	[LegajoAsignado] [nvarchar](20) NULL,
	[Estado] [smallint] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Usuario] [nvarchar](30) NOT NULL,
	[idInventario] [int] NULL,
	[Fase] [int] NULL,
	[idDocumentoPadre] [int] NULL,
 CONSTRAINT [PK_INV_dDocumentos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[INV_dInventario]    Script Date: 11/7/2019 11:18:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_dInventario](
	[Nombre] [nvarchar](200) NOT NULL,
	[Estado] [smallint] NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[FechaFinalizacion] [date] NULL,
	[Usuario] [nvarchar](30) NOT NULL,
	[cc] [smallint] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_INV_dInventario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[INV_dPosiciones]    Script Date: 11/7/2019 11:18:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INV_dPosiciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idDocumento] [int] NOT NULL,
	[sector] [nvarchar](255) NULL,
	[pasillo] [nvarchar](3) NULL,
	[columna] [float] NULL,
	[nivel] [float] NULL,
	[compart] [float] NULL,
	[etiqueta] [nvarchar](255) NULL,
	[ean13] [nvarchar](255) NULL,
	[descripcion] [nvarchar](255) NULL,
	[proveedor] [nvarchar](255) NULL,
	[id_orden_compra] [nvarchar](255) NULL,
	[fecha_hora_recepcion] [datetime] NULL,
	[vencimiento] [datetime] NULL,
	[vidautil] [float] NULL,
	[diasvencer] [nvarchar](255) NULL,
	[cxh] [float] NULL,
	[hxp] [float] NULL,
	[uxb] [float] NULL,
	[uxpack] [float] NULL,
	[bultos] [float] NULL,
	[packs] [float] NULL,
	[unidades] [float] NULL,
	[recepcionista] [nvarchar](255) NULL,
	[almacenador] [nvarchar](255) NULL,
	[estadocalidad] [nvarchar](255) NULL,
	[cara] [float] NULL,
	[usuario] [nvarchar](50) NULL,
	[digito] [nvarchar](50) NULL,
	[bultosinv] [float] NULL,
	[ts] [datetime] NULL,
	[fechaact] [datetime] NULL,
	[usuarioinventario] [nvarchar](100) NULL,
	[tipoinventario] [nvarchar](100) NULL,
	[hxpinv] [int] NULL,
	[cajassueltasinv] [int] NULL,
	[estado] [nvarchar](100) NULL,
	[observaciones] [nvarchar](100) NULL,
	[codigoarticulo] [nvarchar](25) NULL,
	[tipolectura] [nvarchar](100) NULL CONSTRAINT [DF_INV_dPosiciones_tipolectura]  DEFAULT (N'Ubicacion'),
	[documentoasociado] [nvarchar](255) NULL CONSTRAINT [DF_INV_dPosiciones_documentoasociado]  DEFAULT (N'No Aplica'),
 CONSTRAINT [PK_INV_dPosiciones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[INV_dDocumentos]  WITH CHECK ADD  CONSTRAINT [FK_INV_dDocumentos_INV_dInventario] FOREIGN KEY([idInventario])
REFERENCES [dbo].[INV_dInventario] ([id])
GO
ALTER TABLE [dbo].[INV_dDocumentos] CHECK CONSTRAINT [FK_INV_dDocumentos_INV_dInventario]
GO
ALTER TABLE [dbo].[INV_dPosiciones]  WITH CHECK ADD  CONSTRAINT [FK_INV_dPosiciones_INV_dDocumento] FOREIGN KEY([idDocumento])
REFERENCES [dbo].[INV_dDocumentos] ([id])
GO
ALTER TABLE [dbo].[INV_dPosiciones] CHECK CONSTRAINT [FK_INV_dPosiciones_INV_dDocumento]
GO
