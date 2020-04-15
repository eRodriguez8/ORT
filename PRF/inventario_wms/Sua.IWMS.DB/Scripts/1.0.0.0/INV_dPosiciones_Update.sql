USE [CDs]
GO

/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_Update]    Script Date: 06/08/2019 11:23:51 a.m. ******/
DROP PROCEDURE [dbo].[INV_dPosiciones_Update]
GO

/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_Update]    Script Date: 06/08/2019 11:23:51 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[INV_dPosiciones_Update]
	@id Int,
	@Usuario nvarchar(255),
    @Digito nvarchar(50),
    @BultosInv float,
    @UsuarioInventario nvarchar(100),
    @HxPInv int,
    @CajasSueltasInv int,
    @Observaciones nvarchar(100) = '',
    @CodigoArticulo nvarchar(25)
AS
BEGIN
	Declare @reinicio as bit
	
	Update INV_dPosiciones 
	Set 
		Usuario = @Usuario, 
		Digito = @Digito, 
		BultosInv = @BultosInv, 
		FechaAct = getdate(), 
		UsuarioInventario = @UsuarioInventario,
		HxPInv = @HxPInv,
		CajasSueltasInv = @CajasSueltasInv,
		Observaciones = @Observaciones,
		CodigoArticulo = @CodigoArticulo
	where id = @id

	Update INV_dPosiciones 
		Set 
			Estado = case 
						when digito is null then 'Sin Conteo'  
						when (bultosinv = -1 or digito = '.') and etiqueta <> '' then 'Con Descuadre'
						when (bultosinv = -1 or digito = '.') and etiqueta = '' then 'Sin Descuadre'
						when digito <> ltrim(rtrim(etiqueta)) and digito <> right(ltrim(rtrim(etiqueta)), len(digito)) then 'Diferencia Etiqueta'  
						when bultos <> bultosinv then 'Diferencia Bultos'
						when CodigoArticulo <> '(-.-)' and codigoarticulo <> '.' and digito = right(ltrim(rtrim(etiqueta)), 2) and CodigoArticulo <> ean13 then 'Descuadre de Articulo'
						when CodigoArticulo <> '(-.-)' and codigoarticulo <> '.'and CodigoArticulo <> ean13 then 'Descuadre de Articulo'
						when codigoarticulo = '.' and ean13 = '' then 'Sin Descuadre'
						when CodigoArticulo = 'Revisar' then 'Revisar'
					else 'Sin Descuadre'
			end
	where id = @id

	--BEGIN TRY  
	--	exec INV_dPosiciones_ValidarYCrearControles @id
	--END TRY  
	--BEGIN CATCH  

	--END CATCH  
	
	set @reinicio = 1
	
	select @reinicio
END





GO


