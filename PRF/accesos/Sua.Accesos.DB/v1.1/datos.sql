USE [AccesosSUA]
GO
SET IDENTITY_INSERT [dbo].[ACC_dMenu] ON 

GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (1, N'ACC', NULL, 1, N'ACC_Usuario',  N'Usuarios', N'Usuarios', N'A', N'assets/images/usuarios.png', 10, N'Cencosud\EA0344', CAST(0x0000A9C900000000 AS DateTime), N'/Usuario')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (2, N'AUD', NULL, 1, N'AUD_ADM', NULL, N'Administracion', N'A', NULL, NULL, N'Cencosud\EA0344', CAST(0x0000A9CF00000000 AS DateTime), NULL)
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (5, N'ACC', NULL, 2, N'ACC_Perfil', N'Perfiles', N'Perfiles', N'A', N'assets/images/perfiles.png', NULL, N'Cencosud\EA0344', CAST(0x0000A9DD0103191D AS DateTime), N'/Perfil')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (7, N'ACC', 1, 1, N'ACC_Usuario_Alta', 'Alta', N'Alta', N'A', N'assets/images/addUser.png', NULL, N'Cencosud\EA0344', CAST(0x0000A9DD01035D9A AS DateTime), N'/Usuario/alta')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (8, N'ACC', 1, 2, N'ACC_Usuario_Modif', N'Modificacion', N'Modificacion', N'A', N'assets/images/editUser.png', NULL, N'Cencosud\EA0344', CAST(0x0000A9DD01038D6E AS DateTime), N'/Usuario/modif')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (10, N'ACC', 1, 3, N'ACC_Usuario_Baja', N'Baja', N'Baja', N'A', N'assets/images/removeUser.png', NULL, N'Cencosud\EA0344', CAST(0x0000A9DD0103BBCF AS DateTime), N'/Usuario/baja')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (12, N'ACC', 5, 1, N'ACC_Perfil_Alta', N'Alta', N'Alta', N'A', N'assets/images/addPerfil.png', NULL, N'Cencosud\EA0344', CAST(0x0000A9DD01046AC2 AS DateTime), N'/Perfil/alta')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (13, N'ACC', 5, 2, N'ACC_Perfil_Baja', N'Baja', N'Baja', N'A', N'assets/images/removePerfil.png', NULL, N'Cencosud\EA0344', CAST(0x0000A9DD01049302 AS DateTime), N'/Perfil/baja')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (14, N'ACC', 5, 3, N'ACC_Perfil_Asociar', N'Asociar Perfiles', N'Asociar Perfiles', N'A', N'assets/images/asociarPerfil.png', NULL, N'Cencosud\EA0344', CAST(0x0000A9DD0104FA1F AS DateTime), N'/Perfil/asociar')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (15, N'ACC', 5, 4, N'ACC_Perfil_Copia',  N'Copiar Perfiles', N'Copiar Perfiles', N'A', N'assets/images/copiarPerfil.png', NULL, N'Cencosud\EA0344', CAST(0x0000A9DD01052524 AS DateTime), N'/Perfil/copiar')
GO
INSERT [dbo].[ACC_dMenu] ([id], [idAplicacion], [idMenu_Precede], [orden], [nombre], [tooltip], [descripcion], [idEstado], [imagen], [usuariosMaximos], [usuario], [ts], [url]) VALUES (16, N'ACC', 1, 4, N'ACC_Usuario_Consulta', N'Consulta', N'Consulta', N'A', N'assets/images/findUser.png', NULL, N'Cencosud\EA0344', CAST(0x0000A9DE00CF036F AS DateTime), N'/Usuario/consulta')
GO
SET IDENTITY_INSERT [dbo].[ACC_dMenu] OFF
GO

  update [AccesosSUA].[dbo].[ACC_dAcciones] set descripcion = 'Administrador' where id = 1