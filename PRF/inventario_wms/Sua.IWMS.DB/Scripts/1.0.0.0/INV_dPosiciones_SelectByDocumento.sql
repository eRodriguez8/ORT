USE [CDs]
GO

/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_SelectByDocumento]    Script Date: 06/08/2019 11:22:53 a.m. ******/
DROP PROCEDURE [dbo].[INV_dPosiciones_SelectByDocumento]
GO

/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_SelectByDocumento]    Script Date: 06/08/2019 11:22:53 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE proc [dbo].[INV_dPosiciones_SelectByDocumento]
	@idDoc as int
AS

BEGIN
	Declare	@Escritos as int
	Declare	@TotalRegistros as int
	Declare	@PrimerId as int
	Declare	@PrimerIdDisponible as int

	set @Escritos = (select COUNT(I.Usuario) as Escrito 
								from INV_dPosiciones I
								where I.idDocumento = @idDoc and I.Usuario <> '')

	set @TotalRegistros = (select COUNT(I.Id) as Total 
								from INV_dPosiciones I
								where I.idDocumento = @idDoc)

	set @PrimerId = (select top 1 I.Id as PrimerId
									from INV_dPosiciones I 
									where I.idDocumento = @idDoc
									order by I.Id)

	set @PrimerIdDisponible = (select top 1 I.Id as PrimerIdDisponible
									from INV_dPosiciones I 
									where I.idDocumento = @idDoc and I.Usuario = ''
									order by I.Id)
									
	select @TotalRegistros as TotalRegistros, @Escritos as Escritos, @PrimerId as PrimerId, @PrimerIdDisponible as PrimerIdDisponible
END



GO


