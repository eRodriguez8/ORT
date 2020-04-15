USE [CDs]
GO

/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_ReiniciarDocumento]    Script Date: 06/08/2019 11:21:51 a.m. ******/
DROP PROCEDURE [dbo].[INV_dPosiciones_ReiniciarDocumento]
GO

/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_ReiniciarDocumento]    Script Date: 06/08/2019 11:21:51 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE proc [dbo].[INV_dPosiciones_ReiniciarDocumento]
	@doc as varchar(30)
AS

BEGIN
	Declare @reinicio as bit
	
	Update INV_dPosiciones
	Set 
		Usuario = null,
		FechaAct = getdate()
	Where Documento = @doc
	
	set @reinicio = 1
	
	select @reinicio as Reinicio
END





GO


