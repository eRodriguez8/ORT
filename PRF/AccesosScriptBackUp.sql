USE [AccesosSUA]
GO
/****** Object:  Table [dbo].[ACC_dAcciones]    Script Date: 18/4/2020 17:52:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[ACC_dAcciones](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[idAplicacion] [varchar](3) NOT NULL,
	[descripcion] [varchar](60) NOT NULL,
	[idEstado] [char](1) NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[ts] [datetime] NOT NULL CONSTRAINT [DF_ACC_dAcciones_ts]  DEFAULT (getdate()),
 CONSTRAINT [PKAcciones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACC_dAplicaciones]    Script Date: 18/4/2020 17:52:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACC_dAplicaciones](
	[id] [varchar](3) NOT NULL,
	[descripcion] [varchar](30) NOT NULL,
	[idEstado] [char](1) NOT NULL,
	[accesos] [char](1) NOT NULL,
	[ts] [datetime] NOT NULL CONSTRAINT [DF_ACC_dAplicaciones_ts]  DEFAULT (getdate()),
	[esPocket] [char](1) NOT NULL DEFAULT ('N'),
	[tooltip] [varchar](100) NULL,
	[imagen] [varchar](100) NULL,
	[url] [varchar](100) NULL,
 CONSTRAINT [PKAplicacionesIdapp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACC_dMenu]    Script Date: 18/4/2020 17:52:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[ACC_dMenu](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[idAplicacion] [varchar](3) NOT NULL,
	[idMenu_Precede] [smallint] NULL,
	[orden] [smallint] NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[tooltip] [varchar](254) NULL,
	[descripcion] [varchar](254) NOT NULL,
	[idEstado] [char](1) NOT NULL,
	[imagen] [varchar](254) NULL,
	[usuariosMaximos] [smallint] NULL,
	[usuario] [varchar](50) NOT NULL,
	[ts] [datetime] NOT NULL CONSTRAINT [DF_ACC_dMenu_ts]  DEFAULT (getdate())
) ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[ACC_dMenu] ADD [url] [varchar](100) NULL
 CONSTRAINT [PKMenu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACC_dPerfiles]    Script Date: 18/4/2020 17:52:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACC_dPerfiles](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[idRegion] [smallint] NOT NULL,
	[idAplicacion] [varchar](3) NOT NULL,
	[descripcion] [varchar](30) NOT NULL,
	[idEstado] [char](1) NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[ts] [datetime] NOT NULL CONSTRAINT [DF_ACC_dPerfiles_ts]  DEFAULT (getdate()),
 CONSTRAINT [PKPerfiles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACC_dUsuarios]    Script Date: 18/4/2020 17:52:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACC_dUsuarios](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[usuarioAD] [varchar](50) NULL,
	[legajo] [varchar](20) NOT NULL,
	[apellido] [varchar](50) NULL,
	[nombre] [char](50) NULL,
	[fhAlta] [datetime] NOT NULL,
	[fhBaja] [datetime] NULL,
	[idEstado] [char](1) NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[ts] [datetime] NOT NULL CONSTRAINT [DF_ACC_dUsuarios_ts]  DEFAULT (getdate()),
	[email] [varchar](100) NULL,
 CONSTRAINT [PKUsuariosIdUsuari] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACC_rdMenu_dAcciones]    Script Date: 18/4/2020 17:52:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACC_rdMenu_dAcciones](
	[idAplicacion] [varchar](3) NOT NULL,
	[idMenu] [smallint] NOT NULL,
	[idAccion] [smallint] NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[ts] [datetime] NOT NULL CONSTRAINT [DF_ACC_rdMenu_dAcciones_ts]  DEFAULT (getdate()),
 CONSTRAINT [PK_ACC_rdMenu_dAcciones] PRIMARY KEY CLUSTERED 
(
	[idMenu] ASC,
	[idAccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACC_rdPerfil_dAcciones]    Script Date: 18/4/2020 17:52:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[ACC_rdPerfil_dAcciones](
	[idPerfil] [smallint] NOT NULL,
	[idAccion] [smallint] NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[ts] [datetime] NOT NULL CONSTRAINT [DF_ACC_rdPerfil_dAcciones_ts]  DEFAULT (getdate()),
	[id] [numeric](8, 0) IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ACC_rdPerfil_dAcciones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones]    Script Date: 18/4/2020 17:52:35 ******/
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
	[ts] [datetime] NOT NULL CONSTRAINT [DF_ACC_rdUsuarios_dPerfiles_dAcciones_ts]  DEFAULT (getdate()),
 CONSTRAINT [PK_ACC_rdUsuarios_dPerfiles_dAcciones] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC,
	[idPerfilAccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACC_sEstados]    Script Date: 18/4/2020 17:52:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACC_sEstados](
	[id] [char](1) NOT NULL,
	[descripcion] [varchar](10) NOT NULL,
 CONSTRAINT [PK_ACC_rEstados] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACC_sRegiones]    Script Date: 18/4/2020 17:52:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACC_sRegiones](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](30) NOT NULL,
	[descripcionCorta] [varchar](10) NULL,
 CONSTRAINT [PKRegiones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ACC_dAcciones] ON 

INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (1, N'ACC', N'Administrador', N'A', N'Cencosud\EA0344', CAST(N'2019-01-02 00:00:00.000' AS DateTime))
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (2, N'AUD', N'AUD_ADM', N'A', N'Cencosud\EA0344', CAST(N'2019-01-08 16:46:12.560' AS DateTime))
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (3, N'ULS', N'ULS_ADM', N'A', N'Cencosud\ACucci', CAST(N'2019-02-14 17:18:15.173' AS DateTime))
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (4, N'IWS', N'IWS_ADM', N'A', N'Cencosud\EB6220', CAST(N'2019-03-07 12:40:29.237' AS DateTime))
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (5, N'DEV', N'DEV_ADM', N'A', N'Cencosud\EB6220', CAST(N'2019-03-07 12:40:48.377' AS DateTime))
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (6, N'DIS', N'DIS_ADM', N'A', N'Cencosud\EA0344', CAST(N'2019-04-10 08:56:15.890' AS DateTime))
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (7, N'DIS', N'DIS_USR', N'A', N'Cencosud\EA0344', CAST(N'2019-04-10 08:56:31.263' AS DateTime))
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (9, N'OPE', N'OPE_REC_ADM', N'A', N'Cencosud\Ea0344', CAST(N'2019-04-17 18:34:32.787' AS DateTime))
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (10, N'OPE', N'OPE_REC_USR', N'A', N'Cencosud\EA0344', CAST(N'2019-04-17 18:34:54.263' AS DateTime))
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (11, N'INV', N'INV_ADM', N'A', N'Cencosud\EA0344', CAST(N'2019-05-15 16:10:19.927' AS DateTime))
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (12, N'INV', N'INV_USR', N'A', N'Cencosud\EA0344', CAST(N'2019-05-15 16:10:36.283' AS DateTime))
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (13, N'SOL', N'SOL_SIG_ADM', N'A', N'Cencosud\EA0344', CAST(N'2019-05-29 01:46:36.173' AS DateTime))
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (15, N'SOL', N'SOL_TRZ_ADM', N'A', N'', CAST(N'2019-08-01 15:36:57.740' AS DateTime))
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (16, N'SGT', N'SGT_USR', N'A', N'Cencosud\EC3872', CAST(N'2019-09-24 17:04:22.483' AS DateTime))
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (17, N'SGT', N'SGT_APR', N'A', N'Cencosud\EC3872', CAST(N'2019-09-24 17:04:22.483' AS DateTime))
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (18, N'OLG', N'OLG_USR', N'A', N'Cencosud\EC3872', CAST(N'2019-12-17 23:47:29.393' AS DateTime))
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (19, N'OLG', N'OLG_ADM', N'A', N'Cencosud\EC3872', CAST(N'2019-12-17 23:47:29.393' AS DateTime))
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (20, N'SUL', N'SUL_ADM', N'A', N'Cencosud\EC3872', CAST(N'2020-01-14 15:07:13.283' AS DateTime))
SET IDENTITY_INSERT [dbo].[ACC_dAcciones] OFF
INSERT [dbo].[ACC_dAplicaciones] ([id], [descripcion], [idEstado], [accesos], [ts], [esPocket], [tooltip], [imagen], [url]) VALUES (N'ACC', N'Accesos SUA', N'A', N'S', CAST(N'2019-01-02 00:00:00.000' AS DateTime), N'N', NULL, NULL, NULL)
INSERT [dbo].[ACC_dAplicaciones] ([id], [descripcion], [idEstado], [accesos], [ts], [esPocket], [tooltip], [imagen], [url]) VALUES (N'AUD', N'Auditoria', N'A', N'S', CAST(N'2019-01-08 00:00:00.000' AS DateTime), N'S', NULL, NULL, N'http://g100603sv216/AuditoriaWeb')
INSERT [dbo].[ACC_dAplicaciones] ([id], [descripcion], [idEstado], [accesos], [ts], [esPocket], [tooltip], [imagen], [url]) VALUES (N'DEV', N'Devoluciones', N'A', N'S', CAST(N'2019-02-26 17:16:05.950' AS DateTime), N'S', NULL, NULL, N'http://g100603sv216/Devoluciones')
INSERT [dbo].[ACC_dAplicaciones] ([id], [descripcion], [idEstado], [accesos], [ts], [esPocket], [tooltip], [imagen], [url]) VALUES (N'DIS', N'Distribuidor SUA', N'A', N'S', CAST(N'2019-04-10 08:45:43.493' AS DateTime), N'N', NULL, N'assets/images/distri.png', N'http://g100603sv216/Distribuidor')
INSERT [dbo].[ACC_dAplicaciones] ([id], [descripcion], [idEstado], [accesos], [ts], [esPocket], [tooltip], [imagen], [url]) VALUES (N'INV', N'Inventario', N'A', N'S', CAST(N'2019-05-15 00:00:00.000' AS DateTime), N'N', NULL, NULL, NULL)
INSERT [dbo].[ACC_dAplicaciones] ([id], [descripcion], [idEstado], [accesos], [ts], [esPocket], [tooltip], [imagen], [url]) VALUES (N'IWS', N'Inventario', N'A', N'S', CAST(N'2019-02-26 00:00:00.000' AS DateTime), N'S', NULL, NULL, N'http://g100603sv216/IWMS')
INSERT [dbo].[ACC_dAplicaciones] ([id], [descripcion], [idEstado], [accesos], [ts], [esPocket], [tooltip], [imagen], [url]) VALUES (N'OLG', N'Operaciones Logistica', N'A', N'S', CAST(N'2019-12-17 17:26:32.240' AS DateTime), N'N', NULL, N'assets/images/operacionesLogistico.png', N'http://g100603sv216/OperacionesLogisticas')
INSERT [dbo].[ACC_dAplicaciones] ([id], [descripcion], [idEstado], [accesos], [ts], [esPocket], [tooltip], [imagen], [url]) VALUES (N'OPE', N'Operaciones', N'A', N'S', CAST(N'2019-04-17 18:32:56.833' AS DateTime), N'N', NULL, N'assets/images/operaciones.png', N'http://localhost/Operaciones')
INSERT [dbo].[ACC_dAplicaciones] ([id], [descripcion], [idEstado], [accesos], [ts], [esPocket], [tooltip], [imagen], [url]) VALUES (N'SGT', N'SGT', N'A', N'S', CAST(N'2019-09-24 16:55:02.473' AS DateTime), N'N', N'SGT', N'assets/images/sgt.png', N'http://g100603sv216/SGT')
INSERT [dbo].[ACC_dAplicaciones] ([id], [descripcion], [idEstado], [accesos], [ts], [esPocket], [tooltip], [imagen], [url]) VALUES (N'SOL', N'Solicitudes', N'A', N'S', CAST(N'2019-05-29 00:00:00.000' AS DateTime), N'N', NULL, N'assets/images/solicitudes.png', N'http://localhost/solicitudes')
INSERT [dbo].[ACC_dAplicaciones] ([id], [descripcion], [idEstado], [accesos], [ts], [esPocket], [tooltip], [imagen], [url]) VALUES (N'SUL', N'Seguimiento Ul', N'A', N'S', CAST(N'2020-01-14 14:56:07.333' AS DateTime), N'S', NULL, NULL, N'http://g100603sv216/Sua.OperacionesLogisticas.Pocket')
INSERT [dbo].[ACC_dAplicaciones] ([id], [descripcion], [idEstado], [accesos], [ts], [esPocket], [tooltip], [imagen], [url]) VALUES (N'ULS', N'Reparacion ULs', N'A', N'S', CAST(N'2019-02-14 17:18:15.090' AS DateTime), N'S', NULL, NULL, N'http://g100603sv216/ULsReparacionWeb')
SET IDENTITY_INSERT [dbo].[ACC_dMenu] ON 

INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (1, N'ACC', 19, 1, N'ACC_Usuario', N'Usuario', N'Usuarios', N'A', N'assets/images/usuarios.png', 10, N'Cencosud\EA0344', CAST(N'2019-01-02 00:00:00.000' AS DateTime), N'/Usuario')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (2, N'AUD', NULL, 1, N'AUD_ADM', NULL, N'Administracion', N'A', NULL, NULL, N'Cencosud\EA0344', CAST(N'2019-01-08 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (5, N'ACC', 19, 2, N'ACC_Perfil', N'Perfiles', N'Perfiles', N'A', N'assets/images/perfiles.png', NULL, N'Cencosud\EA0344', CAST(N'2019-01-22 15:43:20.843' AS DateTime), N'/Perfil')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (7, N'ACC', 1, 1, N'ACC_Usuario_Alta', N'Agregar', N'Alta', N'A', N'assets/images/addUser.png', NULL, N'Cencosud\EA0344', CAST(N'2019-01-22 15:44:19.287' AS DateTime), N'/Usuario/alta')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (8, N'ACC', 1, 2, N'ACC_Usuario_Modif', N'Modificar', N'Modificacion', N'A', N'assets/images/editUser.png', NULL, N'Cencosud\EA0344', CAST(N'2019-01-22 15:45:00.100' AS DateTime), N'/Usuario/modif')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (10, N'ACC', 1, 3, N'ACC_Usuario_Baja', N'Eliminar', N'Baja', N'A', N'assets/images/removeUser.png', NULL, N'Cencosud\EA0344', CAST(N'2019-01-22 15:45:39.677' AS DateTime), N'/Usuario/baja')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (12, N'ACC', 5, 1, N'ACC_Perfil_Alta', N'Agregar', N'Alta', N'A', N'assets/images/addPerfil.png', NULL, N'Cencosud\EA0344', CAST(N'2019-01-22 15:48:08.967' AS DateTime), N'/Perfil/alta')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (13, N'ACC', 5, 2, N'ACC_Perfil_Baja', N'Eliminar', N'Baja', N'A', N'assets/images/removePerfil.png', NULL, N'Cencosud\EA0344', CAST(N'2019-01-22 15:48:43.313' AS DateTime), N'/Perfil/baja')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (14, N'ACC', 5, 3, N'ACC_Perfil_Asociar', N'Asociar Perfil', N'Asociar Perfiles', N'A', N'assets/images/asociarPerfil.png', NULL, N'Cencosud\EA0344', CAST(N'2019-01-22 15:50:11.303' AS DateTime), N'/Perfil/asociar')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (15, N'ACC', 5, 4, N'ACC_Perfil_Copia', N'Copiar Perfil', N'Copiar Perfiles', N'A', N'assets/images/copiarPerfil.png', NULL, N'Cencosud\EA0344', CAST(N'2019-01-22 15:50:48.013' AS DateTime), N'/Perfil/copiar')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (16, N'ACC', 1, 4, N'ACC_Usuario_Consulta', N'Consultar Perfil', N'Consulta', N'A', N'assets/images/findUser.png', NULL, N'Cencosud\EA0344', CAST(N'2019-01-23 12:33:42.770' AS DateTime), N'/Usuario/consulta')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (19, N'DIS', NULL, 1, N'DIS_Generales', N'Generales', N'Generales', N'A', N'assets/images/generales.png', NULL, N'Cencosud\EA0344', CAST(N'2019-04-10 08:50:08.137' AS DateTime), N'/SubMenu/Generales')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (20, N'DIS', NULL, 2, N'DIS_PProductivas', N'Plantas Productivas', N'Plantas Productivas', N'A', N'assets/images/plantas.png', NULL, N'Cencosud\EA0344', CAST(N'2019-04-10 08:51:02.850' AS DateTime), N'/SubMenu/PlantasProductivas')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (22, N'DIS', NULL, 3, N'DIS_Logistica', N'Logistica', N'Logistica', N'A', N'assets/images/logistica.png', NULL, N'Cencosud\EA0344', CAST(N'2019-04-10 08:52:15.070' AS DateTime), N'/SubMenu/Logistica')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (24, N'DIS', NULL, 4, N'DIS_Configuracion', N'Configuracion', N'Configuracion', N'A', N'assets/images/configuracion.png', NULL, N'Cencosud\EA0344', CAST(N'2019-04-10 08:53:18.260' AS DateTime), N'/SubMenu/Configuracion')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (26, N'DIS', 24, 1, N'DIS_ACC', N'Accesos', N'Accesos', N'A', N'assets/images/accesos.png', NULL, N'Cencosud\EA0344', CAST(N'2019-04-10 08:50:08.137' AS DateTime), N'/Accesos')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (35, N'OPE', NULL, 1, N'OPE_Recepciones', N'Recepciones', N'Recepciones', N'A', N'assets/images/recepcionesTxt.png', NULL, N'Cencosud\EA0344', CAST(N'2019-04-17 19:00:54.847' AS DateTime), N'/Recepciones')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (36, N'OPE', 35, 1, N'OPE_RCP_Buscar', N'Buscar', N'Buscar', N'A', N'assets/images/buscar.png', NULL, N'Cencosud\EA0344', CAST(N'2019-04-17 19:02:02.813' AS DateTime), N'/Recepciones/Buscar')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (37, N'DIS', 20, 1, N'DIS_OPE', N'Operaciones', N'Operaciones', N'A', N'assets/images/operaciones.png', NULL, N'Cencosud\EA0344', CAST(N'2019-05-15 16:04:37.203' AS DateTime), N'/Operaciones')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (38, N'DIS', 20, 2, N'DIS_INV', N'Inventario', N'Inventario', N'A', N'assets/images/inventario.png', NULL, N'Cencosud\EA0344', CAST(N'2019-05-15 16:05:34.703' AS DateTime), N'/Inventario')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (39, N'INV', NULL, 2, N'INV_Consulta', N'Consulta', N'Consulta', N'A', N'assets/images/consultar.png', NULL, N'Cencosud\EA0344', CAST(N'2019-05-15 16:06:38.860' AS DateTime), N'/Consulta')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (40, N'INV', NULL, 1, N'INV_Importar', N'Importar', N'Importar', N'A', N'assets/images/importar.png', NULL, N'Cencosud\EA0344', CAST(N'2019-05-15 16:07:20.267' AS DateTime), N'/Importar')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (41, N'INV', NULL, 3, N'INV_Asignar', N'Asignar', N'Asignar', N'I', N'assets/images/asignar.png', NULL, N'Cencosud\Ea0344', CAST(N'2019-05-15 16:08:01.147' AS DateTime), N'/Asignar')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (42, N'INV', NULL, 4, N'INV_Estado', N'Estado Actual', N'Estado Actual', N'A', N'assets/images/estado.png', NULL, N'Cencosud\EA0344', CAST(N'2019-05-15 16:09:39.107' AS DateTime), N'/Estado')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (45, N'DIS', 20, 3, N'DIS_SOL', N'Solicitudes', N'Solicitudes', N'A', N'assets/images/solicitudes.png', NULL, N'Cencosud\EA0344', CAST(N'2019-05-29 00:00:00.000' AS DateTime), N'/Solicitudes')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (46, N'SOL', NULL, 1, N'SOL_Sigcer', N'Sigcer', N'Sigcer', N'A', N'assets/images/sigcer.png', NULL, N'Cencosud\EA0344', CAST(N'2019-05-29 00:00:00.000' AS DateTime), N'/Sigcer')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (47, N'SOL', 46, 1, N'SOL_SIG_ZIP', N'Generacion de Archivo', N'Generacion de Archivo', N'A', N'assets/images/zip.png', NULL, N'Cencosud\EA0344', CAST(N'2019-05-29 10:50:36.667' AS DateTime), N'/Sigcer/GeneracionZip')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (50, N'SOL', NULL, 2, N'SOL_Trazar', N'Trazar', N'Trazar', N'A', N'assets/images/trazar.png', NULL, N'', CAST(N'2019-08-01 15:46:28.713' AS DateTime), N'/Trazar')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (51, N'SGT', NULL, 1, N'SGT_APR_TAF', N'Aprobación de tarifa', N'Aprobación de tarifa', N'A', N'assets/images/aprobacion.png', NULL, N'Cencosud\EC3872', CAST(N'2019-09-24 17:10:16.753' AS DateTime), N'/Tarifas')
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (52, N'OLG', NULL, 1, N'OLG_SeguimientoUL', N'Seguimiento de UL', N'Seguimiento de UL', N'A', N'assets/images/SeguimientoUL.png', NULL, N'Cencosud\EC3872', CAST(N'2019-12-17 17:47:18.373' AS DateTime), N'/SeguimientoUL')
SET IDENTITY_INSERT [dbo].[ACC_dMenu] OFF
SET IDENTITY_INSERT [dbo].[ACC_dPerfiles] ON 

INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (1, 1, N'ACC', N'Accesos BA', N'A', N'Cencosud\EA0344', CAST(N'2019-01-02 00:00:00.000' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (2, 1, N'AUD', N'Auditoria BA', N'A', N'Cencosud\EA0344', CAST(N'2019-01-08 00:00:00.000' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (3, 1, N'ULS', N'Reparacion ULs BA', N'A', N'Cencosud\ACucci', CAST(N'2019-02-14 17:18:15.180' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (4, 3, N'ULS', N'Reparacion ULs CBA', N'A', N'Cencosud\ACucci', CAST(N'2019-02-14 17:18:15.327' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (5, 5, N'ULS', N'Reparacion ULs MZA', N'A', N'Cencosud\ACucci', CAST(N'2019-02-14 17:18:15.330' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (6, 4, N'ULS', N'Reparacion ULs TUC', N'A', N'Cencosud\ACucci', CAST(N'2019-02-14 17:18:15.333' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (7, 5, N'AUD', N'Auditoria MZA', N'A', N'Cencosud\ACucci', CAST(N'2019-02-15 13:06:34.413' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (8, 3, N'AUD', N'Auditoria CBA', N'A', N'Cencosud\ACucci', CAST(N'2019-02-15 13:25:06.957' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (9, 1, N'IWS', N'Inventario BA', N'A', N'Cencosud\EB6220', CAST(N'2019-02-26 17:20:01.353' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (20, 3, N'IWS', N'Inventario CBA', N'A', N'Cencosud\EB6220', CAST(N'2019-02-26 17:27:24.650' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (21, 5, N'IWS', N'Inventario MZA', N'A', N'Cencosud\EB6220', CAST(N'2019-02-26 17:31:11.743' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (22, 4, N'IWS', N'Inventario TUC', N'A', N'Cencosud\EB6220', CAST(N'2019-02-26 17:31:34.383' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (23, 1, N'DEV', N'Devoluciones BA', N'A', N'Cencosud\EB6220', CAST(N'2019-02-26 17:37:33.160' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (24, 3, N'DEV', N'Devolucones CBA', N'A', N'Cencosud\EB6220', CAST(N'2019-02-26 17:37:50.450' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (25, 5, N'DEV', N'Devoluciones MZA', N'A', N'Cencosud\EB6220', CAST(N'2019-02-26 17:38:09.793' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (26, 4, N'DEV', N'Devoluciones TUC', N'A', N'Cencosud\EB6220', CAST(N'2019-02-26 17:38:33.787' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (28, 1, N'DIS', N'Distribuidor Administrador', N'A', N'Cencosud\EA0344', CAST(N'2019-04-10 08:59:56.537' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (29, 1, N'DIS', N'Distribuidor Usuario', N'A', N'Cencosud\EA0344', CAST(N'2019-04-10 09:00:25.547' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (30, 1, N'OPE', N'Recepciones Adm BA', N'A', N'CENCOSUD\EA0344', CAST(N'2019-04-17 18:46:46.323' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (31, 5, N'DEV', N'EMA PU', N'A', N'CENCOSUD\EB6220', CAST(N'2019-05-14 16:01:10.480' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (32, 1, N'INV', N'Inventario Adm BA', N'A', N'Cencosud\EA0344', CAST(N'2019-05-15 16:11:31.527' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (33, 1, N'INV', N'Inventario Usuario BA', N'A', N'Cencosud\EA0344', CAST(N'2019-05-15 16:12:01.457' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (34, 1, N'SOL', N'Sigcer Adm BA', N'A', N'Cencosud\EA0344', CAST(N'2019-05-29 01:45:33.783' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (36, 1, N'SOL', N'Trazar Adm BA', N'A', N'', CAST(N'2019-08-01 15:36:57.743' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (39, 1, N'SGT', N'SGT Usuario BA', N'A', N'Cencosud\EC3872', CAST(N'2019-09-24 17:19:14.117' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (40, 1, N'SGT', N'SGT Aprobador BA', N'A', N'Cencosud\EC3872', CAST(N'2019-09-24 17:19:14.117' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (41, 1, N'OLG', N'OLG ADMIN BA', N'A', N'Cencosud\EC3872', CAST(N'2019-12-18 00:28:30.843' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (42, 1, N'OLG', N'OLG USER BA', N'A', N'Cencosud\EC3872', CAST(N'2019-12-18 00:28:30.843' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (43, 1, N'SUL', N'Seguimiento UL BA', N'A', N'Cencosud\EC3872', CAST(N'2020-01-14 15:13:58.497' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (44, 3, N'SUL', N'Seguimiento UL CBA', N'A', N'Cencosud\EC3872', CAST(N'2020-01-14 15:13:58.497' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (45, 4, N'SUL', N'Seguimiento UL MZA', N'A', N'Cencosud\EC3872', CAST(N'2020-01-14 15:13:58.497' AS DateTime))
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (46, 5, N'SUL', N'Seguimiento UL TUC', N'A', N'Cencosud\EC3872', CAST(N'2020-01-14 15:13:58.497' AS DateTime))
SET IDENTITY_INSERT [dbo].[ACC_dPerfiles] OFF
SET IDENTITY_INSERT [dbo].[ACC_dUsuarios] ON 

INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (1, N'Cencosud\EA0344', N'344', N'Campa', N'Javier                                            ', CAST(N'2019-01-02 00:00:00.000' AS DateTime), NULL, N'A', N'Cencosud\EA0344', CAST(N'2019-01-02 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (3, N'Cencosud\EB6220', N'6220', N'Rodriguez', N'Emanuel                                           ', CAST(N'2019-01-08 00:00:00.000' AS DateTime), NULL, N'A', N'6220', CAST(N'2019-01-08 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (4, N'acucci', N'1234', N'Cucci', N'Adrian                                            ', CAST(N'2019-01-14 14:19:21.000' AS DateTime), CAST(N'2019-01-14 12:15:48.893' AS DateTime), N'I', N'EA0344', CAST(N'2019-01-14 12:15:48.893' AS DateTime), NULL)
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (5, N'Cencosud\acucci', N'1234', N'Cucci', N'Adrian                                            ', CAST(N'2019-01-14 14:20:21.000' AS DateTime), CAST(N'2019-01-14 16:55:32.517' AS DateTime), N'I', N'EA0344', CAST(N'2019-01-14 16:55:32.547' AS DateTime), NULL)
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (6, N'Cencosud\acucci', N'1234', N'Cucci', N'Adrian                                            ', CAST(N'2019-01-14 14:19:21.000' AS DateTime), NULL, N'A', N'EA0344', CAST(N'2019-01-14 14:19:21.000' AS DateTime), NULL)
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (7, N'', N'15065', N'SANTILLAN', N'GERARDO BLAS                                      ', CAST(N'2019-02-15 13:05:19.297' AS DateTime), NULL, N'A', N'Cencosud\ACucci', CAST(N'2019-02-15 13:05:19.297' AS DateTime), NULL)
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (8, N'', N'15074', N'Ponce', N'Claudio Roberto                                   ', CAST(N'2019-02-15 13:33:36.413' AS DateTime), NULL, N'A', N'Cencosud\ACucci', CAST(N'2019-02-15 13:33:36.413' AS DateTime), NULL)
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (9, N'', N'26825', N'Alvarez', N'Matias                                            ', CAST(N'2019-02-15 13:38:42.903' AS DateTime), NULL, N'A', N'Cencosud\ACucci', CAST(N'2019-02-15 13:38:42.903' AS DateTime), NULL)
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (10, N'ACucci', N'4829', N'Cucci', N'Adrian                                            ', CAST(N'2019-03-20 13:29:55.777' AS DateTime), NULL, N'A', N'Cencosud\ACucci', CAST(N'2019-03-20 13:29:55.777' AS DateTime), NULL)
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (11, N'Cencosud\vmonserr', N'409649', N'Monserrat', N'Vanesa                                            ', CAST(N'2019-03-20 14:39:54.980' AS DateTime), NULL, N'A', N'Cencosud\ACucci', CAST(N'2019-03-20 14:39:54.980' AS DateTime), NULL)
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (12, N'Cencosud\GAlfonso', N'38470', N'Alfonso', N'Gonzalo                                           ', CAST(N'2019-03-20 14:40:51.487' AS DateTime), NULL, N'A', N'Cencosud\ACucci', CAST(N'2019-03-20 14:40:51.487' AS DateTime), NULL)
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (13, N'pcaraba', N'9999', N'Carabajal', N'Pedro                                             ', CAST(N'2019-03-25 10:17:02.987' AS DateTime), NULL, N'A', N'CENCOSUD\EA0344', CAST(N'2019-03-25 10:17:02.987' AS DateTime), NULL)
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (16, N'Cencosud\EA7217', N'7217', N'Di Risio', N'Julian                                            ', CAST(N'2019-07-31 00:00:00.000' AS DateTime), NULL, N'A', N'Cencosud\EA7217', CAST(N'2019-07-31 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (17, N'Cencosud\EC3872', N'3872', N'Cejas', N'Rodrigo                                           ', CAST(N'2019-09-18 10:52:18.160' AS DateTime), NULL, N'A', N'3872', CAST(N'2019-09-18 10:52:18.160' AS DateTime), N'rodrigoantonio.cejas@externos-ar.cencosud.com')
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (18, N'Cencosud\Olaborde', N'4567', N'Laborde', N'Osvaldo                                           ', CAST(N'2019-11-05 17:51:37.250' AS DateTime), NULL, N'A', N'Cencosud\EC3872', CAST(N'2019-11-05 17:51:37.250' AS DateTime), NULL)
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (19, N'Cencosud\hpledesma', N'1132', N'Ledesma', N'Hernan                                            ', CAST(N'2019-11-05 17:51:37.250' AS DateTime), NULL, N'A', N'Cencosud\EC3872', CAST(N'2019-11-05 17:51:37.250' AS DateTime), NULL)
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (20, N'Cencosud\jobenite', N'2972', N'Benitez', N'Jose                                              ', CAST(N'2020-03-17 08:10:19.990' AS DateTime), NULL, N'A', N'CENCOSUD\VMONSERR', CAST(N'2020-03-17 08:10:19.990' AS DateTime), NULL)
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (21, N'Cencosud\EC3871', N'3871', N'test', N'test                                              ', CAST(N'2020-03-20 12:03:59.707' AS DateTime), NULL, N'A', N'CENCOSUD\EC3872', CAST(N'2020-03-20 12:03:59.707' AS DateTime), N'roro@roro.com')
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts], [email]) VALUES (22, N'Cencosud\mic_dbar', N'89987', N'Barrios', N'Dario                                             ', CAST(N'2020-03-27 12:02:16.333' AS DateTime), NULL, N'A', N'CENCOSUD\VMONSERR', CAST(N'2020-03-27 12:02:16.333' AS DateTime), N'MIC_DBar@disco.com.ar')
SET IDENTITY_INSERT [dbo].[ACC_dUsuarios] OFF
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'ACC', 1, 1, N'Cencosud\EA0344', CAST(N'2019-01-02 00:00:00.000' AS DateTime))
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'AUD', 2, 2, N'Cencosud\EA0344', CAST(N'2019-01-08 16:49:13.963' AS DateTime))
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'ACC', 5, 1, N'Cencosud\EA0344', CAST(N'2020-03-12 11:58:00.310' AS DateTime))
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'OPE', 35, 9, N'Cencosud\EA0344', CAST(N'2020-02-10 12:52:11.777' AS DateTime))
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'OPE', 36, 9, N'Cencosud\EA0344', CAST(N'2020-02-10 13:06:53.427' AS DateTime))
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'INV', 39, 11, N'Cencosud\EA0344', CAST(N'2019-05-17 10:47:59.423' AS DateTime))
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'INV', 39, 12, N'Cencosud\EA0344', CAST(N'2019-05-17 10:46:52.727' AS DateTime))
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'INV', 40, 11, N'Cencosud\EA0344', CAST(N'2019-05-17 10:47:06.260' AS DateTime))
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'INV', 41, 11, N'Cencosud\EA0344', CAST(N'2019-05-17 10:47:17.293' AS DateTime))
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'INV', 42, 11, N'Cencosud\EA0344', CAST(N'2019-05-17 10:47:32.160' AS DateTime))
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'INV', 42, 12, N'Cencosud\EA0344', CAST(N'2019-05-17 10:47:41.930' AS DateTime))
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'SOL', 46, 13, N'Cencosud\EA0344', CAST(N'2019-05-29 01:49:57.163' AS DateTime))
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'SOL', 47, 13, N'Cencosud\EA0344', CAST(N'2019-05-29 10:51:03.733' AS DateTime))
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'SOL', 50, 15, N'', CAST(N'2019-08-01 16:05:28.927' AS DateTime))
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'SGT', 51, 16, N'Cencosud\EC3872', CAST(N'2019-09-24 17:33:34.953' AS DateTime))
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'SGT', 51, 17, N'Cencosud\EC3872', CAST(N'2019-09-24 17:33:34.953' AS DateTime))
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'OLG', 52, 18, N'Cencosud\EC3872', CAST(N'2019-12-18 10:34:31.650' AS DateTime))
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'OLG', 52, 19, N'Cencosud\EC3872', CAST(N'2019-12-18 10:34:31.650' AS DateTime))
SET IDENTITY_INSERT [dbo].[ACC_rdPerfil_dAcciones] ON 

INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (1, 1, N'Cencosud\EA0344', CAST(N'2019-01-02 00:00:00.000' AS DateTime), CAST(1 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (2, 2, N'Cencosud\EA0344', CAST(N'2019-01-08 16:50:40.997' AS DateTime), CAST(2 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (3, 3, N'Cencosud\EB6220', CAST(N'2019-03-07 14:09:32.567' AS DateTime), CAST(3 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (9, 4, N'Cencosud\EB6220', CAST(N'2019-03-07 14:09:44.687' AS DateTime), CAST(4 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (23, 5, N'Cencosud\EB6220', CAST(N'2019-03-07 14:09:59.210' AS DateTime), CAST(6 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (2, 1, N'Cencosud\EB6220', CAST(N'2019-03-07 14:10:09.530' AS DateTime), CAST(7 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (2, 3, N'Cencosud\EB6220', CAST(N'2019-03-07 14:10:20.267' AS DateTime), CAST(8 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (2, 4, N'Cencosud\EB6220', CAST(N'2019-03-07 14:10:32.683' AS DateTime), CAST(9 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (2, 5, N'Cencosud\EB6220', CAST(N'2019-03-07 14:10:42.377' AS DateTime), CAST(10 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (3, 1, N'Cencosud\EB6220', CAST(N'2019-03-07 14:10:58.907' AS DateTime), CAST(11 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (3, 2, N'Cencosud\EB6220', CAST(N'2019-03-07 14:11:28.440' AS DateTime), CAST(12 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (3, 4, N'Cencosud\EB6220', CAST(N'2019-03-07 14:11:36.330' AS DateTime), CAST(13 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (3, 5, N'Cencosud\EB6220', CAST(N'2019-03-07 14:11:52.350' AS DateTime), CAST(14 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (9, 1, N'Cencosud\EB6220', CAST(N'2019-03-07 14:12:00.170' AS DateTime), CAST(15 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (9, 2, N'Cencosud\EB6220', CAST(N'2019-03-07 14:13:48.277' AS DateTime), CAST(16 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (9, 3, N'Cencosud\EB6220', CAST(N'2019-03-07 14:13:55.503' AS DateTime), CAST(17 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (9, 5, N'Cencosud\EB6220', CAST(N'2019-03-07 14:14:05.900' AS DateTime), CAST(18 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (23, 1, N'Cencosud\EB6220', CAST(N'2019-03-07 14:14:16.150' AS DateTime), CAST(19 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (23, 2, N'Cencosud\EB6220', CAST(N'2019-03-07 14:14:21.397' AS DateTime), CAST(20 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (23, 3, N'Cencosud\EB6220', CAST(N'2019-03-07 14:14:27.173' AS DateTime), CAST(21 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (23, 4, N'Cencosud\EB6220', CAST(N'2019-03-07 14:14:32.163' AS DateTime), CAST(22 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (1, 2, N'Cencosud\EB6220', CAST(N'2019-03-07 14:14:42.187' AS DateTime), CAST(23 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (1, 3, N'Cencosud\EB6220', CAST(N'2019-03-07 14:14:48.783' AS DateTime), CAST(24 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (1, 4, N'Cencosud\EB6220', CAST(N'2019-03-07 14:14:54.423' AS DateTime), CAST(25 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (1, 5, N'Cencosud\EB6220', CAST(N'2019-03-07 14:15:02.733' AS DateTime), CAST(26 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (7, 2, N'Mar 20 2019  2:47PM', CAST(N'1900-01-28 00:00:00.000' AS DateTime), CAST(27 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (25, 5, N'Mar 20 2019  2:48PM', CAST(N'1900-01-29 00:00:00.000' AS DateTime), CAST(28 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (21, 4, N'Mar 20 2019  2:48PM', CAST(N'1900-01-30 00:00:00.000' AS DateTime), CAST(29 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (5, 3, N'Mar 20 2019  2:48PM', CAST(N'1900-01-31 00:00:00.000' AS DateTime), CAST(30 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (28, 6, N'Cencosud\EA0344', CAST(N'2019-04-10 09:02:11.423' AS DateTime), CAST(31 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (29, 7, N'Cencosud\EA0344', CAST(N'2019-04-10 09:02:27.597' AS DateTime), CAST(32 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (30, 9, N'Cencosud\EA0344', CAST(N'2019-04-10 00:00:00.000' AS DateTime), CAST(36 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (31, 5, N'CENCOSUD\EB6220', CAST(N'2019-05-14 16:01:10.480' AS DateTime), CAST(37 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (32, 11, N'Cencosud\EA0344', CAST(N'2019-05-15 16:13:04.703' AS DateTime), CAST(38 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (33, 12, N'Cencosud\EA0344', CAST(N'2019-05-17 10:26:03.247' AS DateTime), CAST(39 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (34, 13, N'Cencosud\Ea0344', CAST(N'2019-05-29 01:47:04.460' AS DateTime), CAST(40 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (36, 15, N'', CAST(N'2019-08-01 15:36:57.857' AS DateTime), CAST(42 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (39, 16, N'Cencosud\EC3872', CAST(N'2019-09-24 17:42:48.810' AS DateTime), CAST(44 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (40, 17, N'Cencosud\EC3872', CAST(N'2019-09-24 17:42:48.810' AS DateTime), CAST(45 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (41, 19, N'Cencosud\EC3872', CAST(N'2019-12-18 14:21:50.210' AS DateTime), CAST(46 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (42, 18, N'Cencosud\EC3872', CAST(N'2019-12-18 14:21:50.210' AS DateTime), CAST(47 AS Numeric(8, 0)))
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (43, 20, N'Cencosud\EC3872', CAST(N'2020-01-14 15:58:31.030' AS DateTime), CAST(48 AS Numeric(8, 0)))
SET IDENTITY_INSERT [dbo].[ACC_rdPerfil_dAcciones] OFF
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (1, CAST(1 AS Numeric(8, 0)), N'Cencosud\Ea0344', CAST(N'2020-03-26 13:01:10.950' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (1, CAST(2 AS Numeric(8, 0)), N'Cencosud\Ea0344', CAST(N'2019-03-21 23:46:40.293' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (1, CAST(3 AS Numeric(8, 0)), N'Cencosud\Ea0344', CAST(N'2019-03-21 23:46:49.600' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (1, CAST(4 AS Numeric(8, 0)), N'Cencosud\Ea0344', CAST(N'2019-03-21 23:47:02.027' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (1, CAST(6 AS Numeric(8, 0)), N'Cencosud\Ea0344', CAST(N'2019-03-21 23:47:12.527' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (1, CAST(36 AS Numeric(8, 0)), N'Cencosud\EA0344', CAST(N'2019-04-26 14:40:54.133' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (1, CAST(37 AS Numeric(8, 0)), N'CENCOSUD\EB6220', CAST(N'2019-05-14 16:05:36.327' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (1, CAST(38 AS Numeric(8, 0)), N'Cencosud\EA0344', CAST(N'2019-05-15 16:13:30.947' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (1, CAST(40 AS Numeric(8, 0)), N'cencosud\EA0344', CAST(N'2019-05-29 01:47:25.013' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (1, CAST(46 AS Numeric(8, 0)), N'Cencosud\EC3872', CAST(N'2020-01-23 14:45:26.923' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (1, CAST(48 AS Numeric(8, 0)), N'Cencosud\EC3872', CAST(N'2020-01-23 14:45:32.130' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (3, CAST(2 AS Numeric(8, 0)), N'Cencosud\EB6220', CAST(N'2019-03-07 14:17:12.937' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (3, CAST(3 AS Numeric(8, 0)), N'Cencosud\EB6220', CAST(N'2019-03-07 14:17:18.013' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (3, CAST(4 AS Numeric(8, 0)), N'Cencosud\EB6220', CAST(N'2019-03-07 14:17:22.013' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (3, CAST(6 AS Numeric(8, 0)), N'Cencosud\EB6220', CAST(N'2019-03-07 14:18:10.140' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (3, CAST(36 AS Numeric(8, 0)), N'CENCOSUD\EB6220', CAST(N'2019-05-03 16:12:13.637' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (3, CAST(38 AS Numeric(8, 0)), N'CENCOSUD\EB6220', CAST(N'2019-07-31 00:00:00.000' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (3, CAST(40 AS Numeric(8, 0)), N'cencosud\EA0344', CAST(N'2019-05-29 01:47:38.993' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (10, CAST(1 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2020-03-26 18:10:35.913' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (10, CAST(2 AS Numeric(8, 0)), N'Cencosud\ACucci', CAST(N'2019-03-20 14:19:02.713' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (10, CAST(3 AS Numeric(8, 0)), N'Cencosud\ACucci', CAST(N'2019-03-20 14:25:58.547' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (10, CAST(4 AS Numeric(8, 0)), N'Cencosud\ACucci', CAST(N'2019-03-20 14:27:35.500' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (10, CAST(6 AS Numeric(8, 0)), N'Cencosud\ACucci', CAST(N'2019-03-20 14:28:03.560' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (10, CAST(27 AS Numeric(8, 0)), N'Cencosud\ACucci', CAST(N'2019-03-20 14:47:43.480' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (11, CAST(1 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2020-03-26 18:10:00.900' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (11, CAST(2 AS Numeric(8, 0)), N'CENCOSUD\EB6220', CAST(N'2019-05-06 11:55:45.197' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (11, CAST(3 AS Numeric(8, 0)), N'CENCOSUD\EB6220', CAST(N'2019-05-06 11:55:45.197' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (11, CAST(4 AS Numeric(8, 0)), N'CENCOSUD\EB6220', CAST(N'2019-05-06 11:55:45.197' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (11, CAST(6 AS Numeric(8, 0)), N'CENCOSUD\EB6220', CAST(N'2019-05-06 11:55:45.197' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (11, CAST(36 AS Numeric(8, 0)), N'CENCOSUD\EB6220', CAST(N'2019-05-06 11:55:45.200' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (11, CAST(38 AS Numeric(8, 0)), N'CENCOSUD\EB6220', CAST(N'2019-07-31 00:00:00.000' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (11, CAST(46 AS Numeric(8, 0)), N'Cencosud\EC3872', CAST(N'2020-01-16 17:50:22.017' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (11, CAST(48 AS Numeric(8, 0)), N'Cencosud\EC3872', CAST(N'2020-01-16 17:51:13.117' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (12, CAST(27 AS Numeric(8, 0)), N'Cencosud\ACucci', CAST(N'2019-03-20 14:48:10.733' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (12, CAST(28 AS Numeric(8, 0)), N'Cencosud\ACucci', CAST(N'2019-03-20 14:48:10.727' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (12, CAST(29 AS Numeric(8, 0)), N'Cencosud\ACucci', CAST(N'2019-03-20 14:48:10.730' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (12, CAST(30 AS Numeric(8, 0)), N'Cencosud\ACucci', CAST(N'2019-03-20 14:48:10.730' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (12, CAST(46 AS Numeric(8, 0)), N'Cencosud\EC3872', CAST(N'2020-01-17 18:48:17.750' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (12, CAST(48 AS Numeric(8, 0)), N'Cencosud\EC3872', CAST(N'2020-01-17 18:48:17.750' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (16, CAST(2 AS Numeric(8, 0)), N'', CAST(N'2019-07-31 15:26:35.540' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (16, CAST(3 AS Numeric(8, 0)), N'', CAST(N'2019-07-31 15:26:37.780' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (16, CAST(4 AS Numeric(8, 0)), N'', CAST(N'2019-07-31 15:26:39.777' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (16, CAST(6 AS Numeric(8, 0)), N'', CAST(N'2019-07-31 15:26:41.650' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (16, CAST(30 AS Numeric(8, 0)), N'ea1', CAST(N'2019-08-29 16:49:30.690' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (16, CAST(36 AS Numeric(8, 0)), N'', CAST(N'2019-07-31 15:34:17.947' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (16, CAST(38 AS Numeric(8, 0)), N'''''', CAST(N'2019-08-06 16:35:49.463' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (16, CAST(40 AS Numeric(8, 0)), N'', CAST(N'2019-07-31 15:34:19.953' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (16, CAST(42 AS Numeric(8, 0)), N'''''', CAST(N'2019-08-01 00:00:00.000' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (17, CAST(1 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2020-03-26 17:43:07.737' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (17, CAST(2 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-09-18 11:05:41.070' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (17, CAST(3 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-09-18 11:05:41.070' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (17, CAST(4 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-09-18 11:05:41.070' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (17, CAST(6 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-09-18 11:05:41.070' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (17, CAST(7 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2020-04-02 09:46:43.717' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (17, CAST(8 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2020-04-02 09:46:43.727' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (17, CAST(9 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2020-04-02 09:46:43.727' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (17, CAST(10 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2020-04-02 09:46:43.727' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (17, CAST(36 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-09-18 11:05:41.070' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (17, CAST(38 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-09-18 11:05:41.070' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (17, CAST(40 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-09-18 11:05:41.070' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (17, CAST(45 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-11-19 06:14:52.450' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (17, CAST(46 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2020-01-07 11:43:50.640' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (17, CAST(48 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2020-01-14 16:00:43.857' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (18, CAST(2 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-11-05 17:58:05.327' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (18, CAST(3 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-11-05 17:58:05.327' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (18, CAST(4 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-11-05 17:58:05.327' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (18, CAST(6 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-11-05 17:58:05.327' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (18, CAST(36 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-11-05 17:58:05.327' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (18, CAST(38 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-11-05 17:58:05.327' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (18, CAST(40 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-11-05 17:58:05.327' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (19, CAST(2 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-11-05 17:58:26.523' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (19, CAST(3 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-11-05 17:58:26.523' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (19, CAST(4 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-11-05 17:58:26.523' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (19, CAST(6 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-11-05 17:58:26.523' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (19, CAST(36 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-11-05 17:58:26.523' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (19, CAST(38 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-11-05 17:58:26.523' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (19, CAST(40 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2019-11-05 17:58:26.523' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (19, CAST(46 AS Numeric(8, 0)), N'Cencosud\EC3872', CAST(N'2019-12-18 14:26:43.530' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (20, CAST(46 AS Numeric(8, 0)), N'CENCOSUD\VMONSERR', CAST(N'2020-03-27 12:06:36.410' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (20, CAST(48 AS Numeric(8, 0)), N'CENCOSUD\VMONSERR', CAST(N'2020-03-17 08:12:51.873' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (21, CAST(1 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2020-03-26 17:43:33.993' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (21, CAST(23 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2020-03-26 17:43:34.107' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (21, CAST(24 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2020-03-26 17:43:34.113' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (21, CAST(25 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2020-03-26 17:43:34.113' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (21, CAST(26 AS Numeric(8, 0)), N'CENCOSUD\EC3872', CAST(N'2020-03-26 17:43:34.117' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (22, CAST(46 AS Numeric(8, 0)), N'CENCOSUD\VMONSERR', CAST(N'2020-03-27 12:07:01.980' AS DateTime))
INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (22, CAST(48 AS Numeric(8, 0)), N'CENCOSUD\VMONSERR', CAST(N'2020-03-27 12:03:09.863' AS DateTime))
INSERT [dbo].[ACC_sEstados] ([id], [descripcion]) VALUES (N'A', N'Activo')
INSERT [dbo].[ACC_sEstados] ([id], [descripcion]) VALUES (N'I', N'Inactivo')
SET IDENTITY_INSERT [dbo].[ACC_sRegiones] ON 

INSERT [dbo].[ACC_sRegiones] ([id], [descripcion], [descripcionCorta]) VALUES (1, N'Buenos Aires', N'BA')
INSERT [dbo].[ACC_sRegiones] ([id], [descripcion], [descripcionCorta]) VALUES (3, N'Cordoba', N'CBA')
INSERT [dbo].[ACC_sRegiones] ([id], [descripcion], [descripcionCorta]) VALUES (4, N'Tucuman', N'TUC')
INSERT [dbo].[ACC_sRegiones] ([id], [descripcion], [descripcionCorta]) VALUES (5, N'Mendoza', N'MZA')
SET IDENTITY_INSERT [dbo].[ACC_sRegiones] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ_ACC_dPerfiles]    Script Date: 18/4/2020 17:52:35 ******/
ALTER TABLE [dbo].[ACC_dPerfiles] ADD  CONSTRAINT [UQ_ACC_dPerfiles] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ_ACC_rdMenu_dAcciones]    Script Date: 18/4/2020 17:52:35 ******/
ALTER TABLE [dbo].[ACC_rdMenu_dAcciones] ADD  CONSTRAINT [UQ_ACC_rdMenu_dAcciones] UNIQUE NONCLUSTERED 
(
	[idAplicacion] ASC,
	[idAccion] ASC,
	[idMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ_ACC_rdPerfil_dAcciones]    Script Date: 18/4/2020 17:52:35 ******/
ALTER TABLE [dbo].[ACC_rdPerfil_dAcciones] ADD  CONSTRAINT [UQ_ACC_rdPerfil_dAcciones] UNIQUE NONCLUSTERED 
(
	[idPerfil] ASC,
	[idAccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ_ACC_rdUsuarios_dPerfiles_dAcciones]    Script Date: 18/4/2020 17:52:35 ******/
ALTER TABLE [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ADD  CONSTRAINT [UQ_ACC_rdUsuarios_dPerfiles_dAcciones] UNIQUE NONCLUSTERED 
(
	[idUsuario] ASC,
	[idPerfilAccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ACC_dAcciones]  WITH CHECK ADD  CONSTRAINT [FK_ACC_dAcciones_ACC_dAplicaciones] FOREIGN KEY([idAplicacion])
REFERENCES [dbo].[ACC_dAplicaciones] ([id])
GO
ALTER TABLE [dbo].[ACC_dAcciones] CHECK CONSTRAINT [FK_ACC_dAcciones_ACC_dAplicaciones]
GO
ALTER TABLE [dbo].[ACC_dAcciones]  WITH CHECK ADD  CONSTRAINT [FK_ACC_dAcciones_ACC_sEstados] FOREIGN KEY([idEstado])
REFERENCES [dbo].[ACC_sEstados] ([id])
GO
ALTER TABLE [dbo].[ACC_dAcciones] CHECK CONSTRAINT [FK_ACC_dAcciones_ACC_sEstados]
GO
ALTER TABLE [dbo].[ACC_dAplicaciones]  WITH CHECK ADD  CONSTRAINT [FK_ACC_dAplicaciones_ACC_sEstados] FOREIGN KEY([idEstado])
REFERENCES [dbo].[ACC_sEstados] ([id])
GO
ALTER TABLE [dbo].[ACC_dAplicaciones] CHECK CONSTRAINT [FK_ACC_dAplicaciones_ACC_sEstados]
GO
ALTER TABLE [dbo].[ACC_dMenu]  WITH CHECK ADD  CONSTRAINT [FK_ACC_dMenu_ACC_dAplicaciones] FOREIGN KEY([idAplicacion])
REFERENCES [dbo].[ACC_dAplicaciones] ([id])
GO
ALTER TABLE [dbo].[ACC_dMenu] CHECK CONSTRAINT [FK_ACC_dMenu_ACC_dAplicaciones]
GO
ALTER TABLE [dbo].[ACC_dMenu]  WITH CHECK ADD  CONSTRAINT [FK_ACC_dMenu_ACC_sEstados] FOREIGN KEY([idEstado])
REFERENCES [dbo].[ACC_sEstados] ([id])
GO
ALTER TABLE [dbo].[ACC_dMenu] CHECK CONSTRAINT [FK_ACC_dMenu_ACC_sEstados]
GO
ALTER TABLE [dbo].[ACC_dPerfiles]  WITH CHECK ADD  CONSTRAINT [FK_ACC_dPerfiles_ACC_dAplicaciones] FOREIGN KEY([idAplicacion])
REFERENCES [dbo].[ACC_dAplicaciones] ([id])
GO
ALTER TABLE [dbo].[ACC_dPerfiles] CHECK CONSTRAINT [FK_ACC_dPerfiles_ACC_dAplicaciones]
GO
ALTER TABLE [dbo].[ACC_dPerfiles]  WITH CHECK ADD  CONSTRAINT [FK_ACC_dPerfiles_ACC_sEstados] FOREIGN KEY([idEstado])
REFERENCES [dbo].[ACC_sEstados] ([id])
GO
ALTER TABLE [dbo].[ACC_dPerfiles] CHECK CONSTRAINT [FK_ACC_dPerfiles_ACC_sEstados]
GO
ALTER TABLE [dbo].[ACC_dPerfiles]  WITH CHECK ADD  CONSTRAINT [FK_ACC_dPerfiles_ACC_sRegiones] FOREIGN KEY([idRegion])
REFERENCES [dbo].[ACC_sRegiones] ([id])
GO
ALTER TABLE [dbo].[ACC_dPerfiles] CHECK CONSTRAINT [FK_ACC_dPerfiles_ACC_sRegiones]
GO
ALTER TABLE [dbo].[ACC_dUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_ACC_dUsuarios_ACC_sEstados] FOREIGN KEY([idEstado])
REFERENCES [dbo].[ACC_sEstados] ([id])
GO
ALTER TABLE [dbo].[ACC_dUsuarios] CHECK CONSTRAINT [FK_ACC_dUsuarios_ACC_sEstados]
GO
ALTER TABLE [dbo].[ACC_rdMenu_dAcciones]  WITH CHECK ADD  CONSTRAINT [FK_ACC_rdMenu_dAcciones_ACC_dAcciones] FOREIGN KEY([idAccion])
REFERENCES [dbo].[ACC_dAcciones] ([id])
GO
ALTER TABLE [dbo].[ACC_rdMenu_dAcciones] CHECK CONSTRAINT [FK_ACC_rdMenu_dAcciones_ACC_dAcciones]
GO
ALTER TABLE [dbo].[ACC_rdMenu_dAcciones]  WITH CHECK ADD  CONSTRAINT [FK_ACC_rdMenu_dAcciones_ACC_dAplicaciones] FOREIGN KEY([idAplicacion])
REFERENCES [dbo].[ACC_dAplicaciones] ([id])
GO
ALTER TABLE [dbo].[ACC_rdMenu_dAcciones] CHECK CONSTRAINT [FK_ACC_rdMenu_dAcciones_ACC_dAplicaciones]
GO
ALTER TABLE [dbo].[ACC_rdMenu_dAcciones]  WITH CHECK ADD  CONSTRAINT [FK_ACC_rdMenu_dAcciones_ACC_dMenu] FOREIGN KEY([idMenu])
REFERENCES [dbo].[ACC_dMenu] ([id])
GO
ALTER TABLE [dbo].[ACC_rdMenu_dAcciones] CHECK CONSTRAINT [FK_ACC_rdMenu_dAcciones_ACC_dMenu]
GO
ALTER TABLE [dbo].[ACC_rdPerfil_dAcciones]  WITH CHECK ADD  CONSTRAINT [FK_ACC_rdPerfil_dAcciones_ACC_dAcciones] FOREIGN KEY([idAccion])
REFERENCES [dbo].[ACC_dAcciones] ([id])
GO
ALTER TABLE [dbo].[ACC_rdPerfil_dAcciones] CHECK CONSTRAINT [FK_ACC_rdPerfil_dAcciones_ACC_dAcciones]
GO
ALTER TABLE [dbo].[ACC_rdPerfil_dAcciones]  WITH CHECK ADD  CONSTRAINT [FK_ACC_rdPerfil_dAcciones_ACC_dPerfiles] FOREIGN KEY([idPerfil])
REFERENCES [dbo].[ACC_dPerfiles] ([id])
GO
ALTER TABLE [dbo].[ACC_rdPerfil_dAcciones] CHECK CONSTRAINT [FK_ACC_rdPerfil_dAcciones_ACC_dPerfiles]
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
ALTER TABLE [dbo].[ACC_dUsuarios]  WITH CHECK ADD  CONSTRAINT [chkUniqueLegajoActivo] CHECK  (([dbo].[ACC_CheckExisteLegajoActivo]([legajo])<(2)))
GO
ALTER TABLE [dbo].[ACC_dUsuarios] CHECK CONSTRAINT [chkUniqueLegajoActivo]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'N para No o S para si' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ACC_dAplicaciones', @level2type=N'COLUMN',@level2name=N'esPocket'
GO
