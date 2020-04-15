USE [CDs]
GO
SET IDENTITY_INSERT [dbo].[INV_dCCsActivos] ON 

GO
INSERT [dbo].[INV_dCCsActivos] ([id], [idRegion], [cc], [descripcion], [idb], [usuario], [ts], [estado]) VALUES (CAST(1 AS Numeric(18, 0)), 1, CAST(217 AS Numeric(5, 0)), N'Centro Distribución Ezeiza-BA.', CAST(9217 AS Numeric(5, 0)), N'cencosud\EA0344', CAST(N'2019-05-23' AS Date), N'A')
GO
INSERT [dbo].[INV_dCCsActivos] ([id], [idRegion], [cc], [descripcion], [idb], [usuario], [ts], [estado]) VALUES (CAST(2 AS Numeric(18, 0)), 1, CAST(596 AS Numeric(5, 0)), N'Planta Fiambrería Ezeiza -BA ', CAST(9596 AS Numeric(5, 0)), N'cencosud\EA0344', CAST(N'2019-05-23' AS Date), N'A')
GO
INSERT [dbo].[INV_dCCsActivos] ([id], [idRegion], [cc], [descripcion], [idb], [usuario], [ts], [estado]) VALUES (CAST(4 AS Numeric(18, 0)), 1, CAST(597 AS Numeric(5, 0)), N'Sub-depósito Devol.Ezeiza -BA ', CAST(9597 AS Numeric(5, 0)), N'cencosud\EA0344', CAST(N'2019-05-23' AS Date), N'A')
GO
INSERT [dbo].[INV_dCCsActivos] ([id], [idRegion], [cc], [descripcion], [idb], [usuario], [ts], [estado]) VALUES (CAST(5 AS Numeric(18, 0)), 1, CAST(663 AS Numeric(5, 0)), N'Planta de Carnes Ezeiza-BA    ', CAST(9663 AS Numeric(5, 0)), N'cencosud\EA0344', CAST(N'2019-05-23' AS Date), N'A')
GO
INSERT [dbo].[INV_dCCsActivos] ([id], [idRegion], [cc], [descripcion], [idb], [usuario], [ts], [estado]) VALUES (CAST(6 AS Numeric(18, 0)), 1, CAST(229 AS Numeric(5, 0)), N'Planta Panif. Brandsen -BA', CAST(9229 AS Numeric(5, 0)), N'cencosud\EA0344', CAST(N'2019-05-23' AS Date), N'A')
GO
SET IDENTITY_INSERT [dbo].[INV_dCCsActivos] OFF
GO
