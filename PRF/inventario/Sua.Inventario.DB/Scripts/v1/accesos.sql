USE [AccesosSUA]

GO
INSERT [dbo].[ACC_dAplicaciones] ([id], [descripcion], [idEstado], [accesos], [ts], [esPocket], [tooltip], [imagen], [url]) VALUES (N'INV', N'Inventario', N'A', N'S', CAST(N'2019-05-15 00:00:00.000' AS DateTime), N'N', NULL, N'assets/images/inventario.png', N'http://g100603sv216/Inventario')
GO

GO
SET IDENTITY_INSERT [dbo].[ACC_dPerfiles] ON 

GO
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (32, 1, N'INV', N'Inventario Adm BA', N'A', N'Cencosud\EA0344', CAST(N'2019-05-15 16:11:31.527' AS DateTime))
GO
INSERT [dbo].[ACC_dPerfiles] ([id], [idRegion], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (33, 1, N'INV', N'Inventario Usuario BA', N'A', N'Cencosud\EA0344', CAST(N'2019-05-15 16:12:01.457' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ACC_dPerfiles] OFF
GO
SET IDENTITY_INSERT [dbo].[ACC_dAcciones] ON 

GO

INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (11, N'INV', N'INV_ADM', N'A', N'Cencosud\EA0344', CAST(N'2019-05-15 16:10:19.927' AS DateTime))
GO
INSERT [dbo].[ACC_dAcciones] ([id], [idAplicacion], [descripcion], [idEstado], [usuario], [ts]) VALUES (12, N'INV', N'INV_USR', N'A', N'Cencosud\EA0344', CAST(N'2019-05-15 16:10:36.283' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ACC_dAcciones] OFF
GO
SET IDENTITY_INSERT [dbo].[ACC_dMenu] ON 

GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (38, N'DIS', 20, 2, N'DIS_INV', N'Inventario', N'Inventario', N'A', N'assets/images/inventario.png', NULL, N'Cencosud\EA0344', CAST(N'2019-05-15 16:05:34.703' AS DateTime), N'/Inventario')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (40, N'INV', NULL, 1, N'INV_Importar', N'Importar', N'Importar', N'A', N'assets/images/importar.png', NULL, N'Cencosud\EA0344', CAST(N'2019-05-15 16:07:20.267' AS DateTime), N'/Importar')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (39, N'INV', NULL, 2, N'INV_Consulta', N'Consulta', N'Consulta', N'A', N'assets/images/consultar.png', NULL, N'Cencosud\EA0344', CAST(N'2019-05-15 16:06:38.860' AS DateTime), N'/Consulta')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (41, N'INV', NULL, 3, N'INV_Asignar', N'Asignar', N'Asignar', N'A', N'assets/images/asignar.png', NULL, N'Cencosud\Ea0344', CAST(N'2019-05-15 16:08:01.147' AS DateTime), N'/Asignar')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (42, N'INV', NULL, 4, N'INV_Estado', N'Estado Actual', N'Estado Actual', N'A', N'assets/images/estado.png', NULL, N'Cencosud\EA0344', CAST(N'2019-05-15 16:09:39.107' AS DateTime), N'/Estado')
GO

SET IDENTITY_INSERT [dbo].[ACC_dMenu] OFF
GO
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'INV', 39, 12, N'Cencosud\EA0344', CAST(N'2019-05-17 10:46:52.727' AS DateTime))
GO
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'INV', 40, 11, N'Cencosud\EA0344', CAST(N'2019-05-17 10:47:06.260' AS DateTime))
GO
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'INV', 41, 11, N'Cencosud\EA0344', CAST(N'2019-05-17 10:47:17.293' AS DateTime))
GO
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'INV', 42, 11, N'Cencosud\EA0344', CAST(N'2019-05-17 10:47:32.160' AS DateTime))
GO
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'INV', 42, 12, N'Cencosud\EA0344', CAST(N'2019-05-17 10:47:41.930' AS DateTime))
GO
INSERT [dbo].[ACC_rdMenu_dAcciones] ([idAplicacion], [idMenu], [idAccion], [usuario], [ts]) VALUES (N'INV', 39, 11, N'Cencosud\EA0344', CAST(N'2019-05-17 10:47:59.423' AS DateTime))
GO

SET IDENTITY_INSERT [dbo].[ACC_rdPerfil_dAcciones] ON 

GO
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (32, 11, N'Cencosud\EA0344', CAST(N'2019-05-15 16:13:04.703' AS DateTime), CAST(38 AS Numeric(8, 0)))
GO
INSERT [dbo].[ACC_rdPerfil_dAcciones] ([idPerfil], [idAccion], [usuario], [ts], [id]) VALUES (33, 12, N'Cencosud\EA0344', CAST(N'2019-05-17 10:26:03.247' AS DateTime), CAST(39 AS Numeric(8, 0)))
GO
SET IDENTITY_INSERT [dbo].[ACC_rdPerfil_dAcciones] OFF
GO

INSERT [dbo].[ACC_rdUsuarios_dPerfiles_dAcciones] ([idUsuario], [idPerfilAccion], [usuario], [ts]) VALUES (1, CAST(38 AS Numeric(8, 0)), N'Cencosud\EA0344', CAST(N'2019-05-15 16:13:30.947' AS DateTime))
GO
