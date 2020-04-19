USE [AccesosSUA]
GO
/****** Object:  Table [dbo].[ACC_dAcciones]    Script Date: 29/01/2019 09:45:17 a.m. ******/
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
	[ts] [datetime] NOT NULL,
 CONSTRAINT [PKAcciones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACC_dAplicaciones]    Script Date: 29/01/2019 09:45:17 a.m. ******/
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
	[ts] [datetime] NOT NULL,
 CONSTRAINT [PKAplicacionesIdapp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACC_dMenu]    Script Date: 29/01/2019 09:45:17 a.m. ******/
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
	[ts] [datetime] NOT NULL
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
/****** Object:  Table [dbo].[ACC_dPerfiles]    Script Date: 29/01/2019 09:45:17 a.m. ******/
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
	[ts] [datetime] NOT NULL,
 CONSTRAINT [PKPerfiles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACC_dUsuarios]    Script Date: 29/01/2019 09:45:17 a.m. ******/
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
	[ts] [datetime] NOT NULL,
 CONSTRAINT [PKUsuariosIdUsuari] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACC_rdMenu_dAcciones]    Script Date: 29/01/2019 09:45:17 a.m. ******/
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
	[ts] [datetime] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACC_rdPerfil_dAcciones]    Script Date: 29/01/2019 09:45:17 a.m. ******/
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
	[ts] [datetime] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACC_rdUsuarios_dPerfiles]    Script Date: 29/01/2019 09:45:17 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[ACC_rdUsuarios_dPerfiles](
	[idUsuario] [smallint] NOT NULL,
	[idPerfil] [smallint] NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[ts] [datetime] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACC_sEstados]    Script Date: 29/01/2019 09:45:17 a.m. ******/
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
/****** Object:  Table [dbo].[ACC_sRegiones]    Script Date: 29/01/2019 09:45:17 a.m. ******/
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

GO
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (1, N'ACC', N'ACC_ADM', N'A', N'Cencosud\EA0344', CAST(0x0000A9C900000000 AS DateTime))
GO
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (2, N'AUD', N'AUD_ADM', N'A', N'Cencosud\EA0344', CAST(0x0000A9CF01145D18 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ACC_dAcciones] OFF
GO
INSERT [dbo].[ACC_dAplicaciones] ([id], [descripcion], [idEstado], [accesos], [ts]) VALUES (N'ACC', N'Accesos SUA', N'A', N'S', CAST(0x0000A9C900000000 AS DateTime))
GO
INSERT [dbo].[ACC_dAplicaciones] ([id], [descripcion], [idEstado], [accesos], [ts]) VALUES (N'AUD', N'Auditoria', N'A', N'S', CAST(0x0000A9CF00000000 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ACC_dMenu] ON 

GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (1, N'ACC', NULL, 1, N'ACC_Usuario', NULL, N'Usuarios', N'A', N'assets/images/usuarios.png', 10, N'Cencosud\EA0344', CAST(0x0000A9C900000000 AS DateTime), N'/Usuario')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (2, N'AUD', NULL, 1, N'AUD_ADM', NULL, N'Administracion', N'A', NULL, NULL, N'Cencosud\EA0344', CAST(0x0000A9CF00000000 AS DateTime), NULL)
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (5, N'ACC', NULL, 2, N'ACC_Perfil', NULL, N'Perfiles', N'A', N'assets/images/perfiles.png', NULL, N'Cencosud\EA0344', CAST(0x0000A9DD0103191D AS DateTime), N'/Perfil')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (7, N'ACC', 1, 1, N'ACC_Usuario_Alta', NULL, N'Alta', N'A', N'assets/images/addUser.png', NULL, N'Cencosud\EA0344', CAST(0x0000A9DD01035D9A AS DateTime), N'/Usuario/alta')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (8, N'ACC', 1, 2, N'ACC_Usuario_Modif', NULL, N'Modificacion', N'A', N'assets/images/editUser.png', NULL, N'Cencosud\EA0344', CAST(0x0000A9DD01038D6E AS DateTime), N'/Usuario/modif')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (10, N'ACC', 1, 3, N'ACC_Usuario_Baja', NULL, N'Baja', N'A', N'assets/images/removeUser.png', NULL, N'Cencosud\EA0344', CAST(0x0000A9DD0103BBCF AS DateTime), N'/Usuario/baja')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (12, N'ACC', 5, 1, N'ACC_Perfil_Alta', NULL, N'Alta', N'A', NULL, NULL, N'Cencosud\EA0344', CAST(0x0000A9DD01046AC2 AS DateTime), NULL)
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (13, N'ACC', 5, 2, N'ACC_Perfil_Baja', NULL, N'Baja', N'A', NULL, NULL, N'Cencosud\EA0344', CAST(0x0000A9DD01049302 AS DateTime), NULL)
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (14, N'ACC', 5, 3, N'ACC_Perfil_Asociar', NULL, N'Asociar Perfiles', N'A', NULL, NULL, N'Cencosud\EA0344', CAST(0x0000A9DD0104FA1F AS DateTime), NULL)
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (15, N'ACC', 5, 4, N'ACC_Perfil_Copia', NULL, N'Copiar Perfiles', N'A', NULL, NULL, N'Cencosud\EA0344', CAST(0x0000A9DD01052524 AS DateTime), NULL)
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (16, N'ACC', 1, 4, N'ACC_Usuario_Consulta', NULL, N'Consulta', N'A', N'assets/images/findUser.png', NULL, N'Cencosud\EA0344', CAST(0x0000A9DE00CF036F AS DateTime), N'/Usuario/consulta')
GO
SET IDENTITY_INSERT [dbo].[ACC_dMenu] OFF
GO
SET IDENTITY_INSERT [dbo].[ACC_dPerfiles] ON 

GO
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (1, 1, N'ACC', N'Accesos Bs As', N'A', N'Cencosud\EA0344', CAST(0x0000A9C900000000 AS DateTime))
GO
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (2, 1, N'AUD', N'Auditoria Bs As', N'A', N'Cencosud\EA0344', CAST(0x0000A9CF00000000 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ACC_dPerfiles] OFF
GO
SET IDENTITY_INSERT [dbo].[ACC_dUsuarios] ON 

GO
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts]) VALUES (1, N'Cencosud\EA0344', N'344', N'Campa', N'Javier                                            ', CAST(0x0000A9C900000000 AS DateTime), NULL, N'A', N'Cencosud\EA0344', CAST(0x0000A9C900000000 AS DateTime))
GO
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts]) VALUES (3, N'Cencosud\EB6220', N'6220', N'Rodriguez', N'Emanuel                                           ', CAST(0x0000A9CF00000000 AS DateTime), NULL, N'A', N'6220', CAST(0x0000A9CF00000000 AS DateTime))
GO
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts]) VALUES (4, N'acucci', N'1234', N'Cucci', N'Adrian                                            ', CAST(0x0000A9D500EC070C AS DateTime), CAST(0x0000A9D500CA18FC AS DateTime), N'I', N'EA0344', CAST(0x0000A9D500CA18FC AS DateTime))
GO
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts]) VALUES (5, N'Cencosud\acucci', N'1234', N'Cucci', N'Adrian                                            ', CAST(0x0000A9D500EC4D5C AS DateTime), CAST(0x0000A9D50116ED4B AS DateTime), N'I', N'EA0344', CAST(0x0000A9D50116ED54 AS DateTime))
GO
INSERT [dbo].[ACC_dUsuarios] ([id], [usuarioAD], [legajo], [apellido], [nombre], [fhAlta], [fhBaja], [idEstado], [usuario], [ts]) VALUES (6, N'Cencosud\acucci', N'1234', N'Cucci', N'Adrian                                            ', CAST(0x0000A9D500EC070C AS DateTime), NULL, N'A', N'EA0344', CAST(0x0000A9D500EC070C AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ACC_dUsuarios] OFF
GO
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'ACC', 1, 1, N'Cencosud\EA0344', CAST(0x0000A9C900000000 AS DateTime))
GO
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'AUD', 2, 2, N'Cencosud\EA0344', CAST(0x0000A9CF011531AD AS DateTime))
GO
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts]) VALUES (1, 1, N'Cencosud\EA0344', CAST(0x0000A9C900000000 AS DateTime))
GO
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts]) VALUES (2, 2, N'Cencosud\EA0344', CAST(0x0000A9CF011597AB AS DateTime))
GO
INSERT [dbo].[ACC_rdUsuarios_dPerfiles] ([idUsuario], [idPerfil], [usuario], [ts]) VALUES (1, 1, N'Cencosud\EA0344', CAST(0x0000A9C900000000 AS DateTime))
GO
INSERT [dbo].[ACC_rdUsuarios_dPerfiles] ([idUsuario], [idPerfil], [usuario], [ts]) VALUES (3, 2, N'Cencosud\EA0344', CAST(0x0000A9CF0115BC60 AS DateTime))
GO
INSERT [dbo].[ACC_sEstados] ([id], [descripcion]) VALUES (N'A', N'Activo')
GO
INSERT [dbo].[ACC_sEstados] ([id], [descripcion]) VALUES (N'I', N'Inactivo')
GO
SET IDENTITY_INSERT [dbo].[ACC_sRegiones] ON 

GO
INSERT [dbo].[ACC_sRegiones] ([id], [descripcion], [descripcionCorta]) VALUES (1, N'Buenos Aires', N'BA')
GO
INSERT [dbo].[ACC_sRegiones] ([id], [descripcion], [descripcionCorta]) VALUES (3, N'Cordoba', N'CBA')
GO
INSERT [dbo].[ACC_sRegiones] ([id], [descripcion], [descripcionCorta]) VALUES (4, N'Tucuman', N'TUC')
GO
INSERT [dbo].[ACC_sRegiones] ([id], [descripcion], [descripcionCorta]) VALUES (5, N'Mendoza', N'MZA')
GO
SET IDENTITY_INSERT [dbo].[ACC_sRegiones] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ_ACC_dPerfiles]    Script Date: 29/01/2019 09:45:19 a.m. ******/
ALTER TABLE [dbo].[ACC_dPerfiles] ADD  CONSTRAINT [UQ_ACC_dPerfiles] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ_ACC_rdMenu_dAcciones]    Script Date: 29/01/2019 09:45:19 a.m. ******/
ALTER TABLE [dbo].[ACC_rdMenu_dAcciones] ADD  CONSTRAINT [UQ_ACC_rdMenu_dAcciones] UNIQUE NONCLUSTERED 
(
	[idAplicacion] ASC,
	[idAccion] ASC,
	[idMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE FUNCTION [dbo].[ACC_CheckExisteLegajoActivo] (@legajo varchar(20))
RETURNS int
AS 
BEGIN
  DECLARE @retval int
    SELECT @retval = count(1)
    FROM dbo.ACC_dUsuarios
    WHERE legajo = @legajo 
	and idEstado = 'A'
  RETURN @retval
END;
GO
/****** Object:  Index [UQ_ACC_rdPerfil_dAcciones]    Script Date: 29/01/2019 09:45:19 a.m. ******/
ALTER TABLE [dbo].[ACC_rdPerfil_dAcciones] ADD  CONSTRAINT [UQ_ACC_rdPerfil_dAcciones] UNIQUE NONCLUSTERED 
(
	[idPerfil] ASC,
	[idAccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ_ACC_rdUsuarios_dPerfiles]    Script Date: 29/01/2019 09:45:19 a.m. ******/
ALTER TABLE [dbo].[ACC_rdUsuarios_dPerfiles] ADD  CONSTRAINT [UQ_ACC_rdUsuarios_dPerfiles] UNIQUE NONCLUSTERED 
(
	[idUsuario] ASC,
	[idPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ACC_dAcciones] ADD  CONSTRAINT [DF_ACC_dAcciones_ts]  DEFAULT (getdate()) FOR [ts]
GO
ALTER TABLE [dbo].[ACC_dAplicaciones] ADD  CONSTRAINT [DF_ACC_dAplicaciones_ts]  DEFAULT (getdate()) FOR [ts]
GO
ALTER TABLE [dbo].[ACC_dMenu] ADD  CONSTRAINT [DF_ACC_dMenu_ts]  DEFAULT (getdate()) FOR [ts]
GO
ALTER TABLE [dbo].[ACC_dPerfiles] ADD  CONSTRAINT [DF_ACC_dPerfiles_ts]  DEFAULT (getdate()) FOR [ts]
GO
ALTER TABLE [dbo].[ACC_dUsuarios] ADD  CONSTRAINT [DF_ACC_dUsuarios_ts]  DEFAULT (getdate()) FOR [ts]
GO
ALTER TABLE [dbo].[ACC_rdMenu_dAcciones] ADD  CONSTRAINT [DF_ACC_rdMenu_dAcciones_ts]  DEFAULT (getdate()) FOR [ts]
GO
ALTER TABLE [dbo].[ACC_rdPerfil_dAcciones] ADD  CONSTRAINT [DF_ACC_rdPerfil_dAcciones_ts]  DEFAULT (getdate()) FOR [ts]
GO
ALTER TABLE [dbo].[ACC_rdUsuarios_dPerfiles] ADD  CONSTRAINT [DF_ACC_rdUsuarios_dPerfiles_ts]  DEFAULT (getdate()) FOR [ts]
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
ALTER TABLE [dbo].[ACC_rdUsuarios_dPerfiles]  WITH CHECK ADD  CONSTRAINT [FK_ACC_rdUsuarios_dPerfiles_ACC_dPerfiles] FOREIGN KEY([idPerfil])
REFERENCES [dbo].[ACC_dPerfiles] ([id])
GO
ALTER TABLE [dbo].[ACC_rdUsuarios_dPerfiles] CHECK CONSTRAINT [FK_ACC_rdUsuarios_dPerfiles_ACC_dPerfiles]
GO
ALTER TABLE [dbo].[ACC_rdUsuarios_dPerfiles]  WITH CHECK ADD  CONSTRAINT [FK_ACC_rdUsuarios_dPerfiles_ACC_dUsuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[ACC_dUsuarios] ([id])
GO
ALTER TABLE [dbo].[ACC_rdUsuarios_dPerfiles] CHECK CONSTRAINT [FK_ACC_rdUsuarios_dPerfiles_ACC_dUsuarios]
GO
ALTER TABLE [dbo].[ACC_dUsuarios]  WITH CHECK ADD  CONSTRAINT [chkUniqueLegajoActivo] CHECK  (([dbo].[ACC_CheckExisteLegajoActivo]([legajo])<(2)))
GO
ALTER TABLE [dbo].[ACC_dUsuarios] CHECK CONSTRAINT [chkUniqueLegajoActivo]
GO
