USE [CDs]
GO

/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_SelectDisponible]    Script Date: 06/08/2019 11:23:15 a.m. ******/
DROP PROCEDURE [dbo].[INV_dPosiciones_SelectDisponible]
GO

/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_SelectDisponible]    Script Date: 06/08/2019 11:23:15 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE proc [dbo].[INV_dPosiciones_SelectDisponible]
	@idDoc as int
AS

BEGIN
	Select top 1 * 
	from INV_dPosiciones I 
	where I.idDocumento = @idDoc and I.Usuario = ''
	order by I.id
END




GO


