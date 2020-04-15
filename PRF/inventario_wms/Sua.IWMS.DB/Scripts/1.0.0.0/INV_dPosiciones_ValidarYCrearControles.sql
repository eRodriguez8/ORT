USE [CDs]
GO

/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_ValidarYCrearControles]    Script Date: 06/08/2019 11:24:11 a.m. ******/
DROP PROCEDURE [dbo].[INV_dPosiciones_ValidarYCrearControles]
GO

/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_ValidarYCrearControles]    Script Date: 06/08/2019 11:24:11 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[INV_dPosiciones_ValidarYCrearControles]
	@idDoc int
as

declare @Salida nvarchar(100)
declare @Documento nvarchar(255)
declare @idInventario int

set @Documento = (select d.Documento 
				 from [CDs].[dbo].[INV_dDocumentos] d 
				 where id = @idDoc)

/* para generar el control, busco si está finalizado el documento, si es de tipo inventario, si tiene descuadres y si no tiene ya un control generado */
if ((select count(*) as Cantidad from INV_dPosiciones p where p.idDocumento = @idDoc and p.fechaact is null) = 0 and 
(select count(*) as Cantidad from INV_dPosiciones p where p.idDocumento = @idDoc and p.estado <> 'Sin Descuadre') > 0 )  
begin
	/* miro si ya está creado el control */
	if (select d.Fase from [CDs].[dbo].[INV_dDocumentos] d where d.id = @idDoc) > 0
	begin

		update [CDs].[dbo].[INV_dDocumentos] set Estado = 2
		where id = @idDoc

		update [CDs].[dbo].[INV_dDocumentos] set LegajoAsignado = ''
		where id = @idDoc

		select @Salida = 'Ya existe control automático generado'
	end
	else
	begin
	/* corresponde crearlo */
		select * 
		into #Posiciones
		from [CDs].[dbo].[INV_dPosiciones] as p
		where p.idDocumento = @idDoc and p.estado <> 'Sin Descuadre'
		order by id

		declare @Fase nvarchar(max)
	
		set @Fase = 'Control Automático'
		
		set @idInventario = (select d.idInventario 
					from [CDs].[dbo].[INV_dDocumentos] d 
					where id = @idDoc)

		insert into [CDs].[dbo].[INV_dDocumentos] 
		(Documento, LegajoAsignado, Estado, Fecha, Usuario, idInventario, Fase, idDocumentoPadre)
		values
		(@Documento + ' ' + @Fase, '', 0, (SELECT CONVERT(VARCHAR(10), GETDATE(), 102)), 'Pocket', @idInventario, 1, @idDoc);
		
		update #Posiciones set estado = ''
		update #Posiciones set ts = getdate()
		update #Posiciones set usuario = ''
		update #Posiciones set digito = null
		update #Posiciones set bultosinv = null
		update #Posiciones set fechaact = null
		update #Posiciones set usuarioinventario = null
		update #Posiciones set hxpinv = null
		update #Posiciones set cajassueltasinv = null
		update #Posiciones set estado = null
		update #Posiciones set observaciones = null
		update #Posiciones set codigoarticulo = null
		update #Posiciones set iddocumento = (select d.id from [CDs].[dbo].[INV_dDocumentos] d where d.idDocumentoPadre = @idDoc)

		alter table #Posiciones drop column id

		insert into [CDs].[dbo].[INV_dPosiciones]
		select * from #Posiciones

		update [CDs].[dbo].[INV_dDocumentos] set Estado = 2
		where id = @idDoc

		update [CDs].[dbo].[INV_dDocumentos] set LegajoAsignado = ''
		where id = @idDoc

		drop table #Posiciones

		set @Salida = @Fase + ' Creado correctamente'
	end
end
else
begin
		update [CDs].[dbo].[INV_dDocumentos] set Estado = 2
		where id = @idDoc

		update [CDs].[dbo].[INV_dDocumentos] set LegajoAsignado = ''
		where id = @idDoc

	select @Salida = 'No corresponde generar control'
end	

select @Salida as Resultado

	-- select * from INV_dPosiciones where documento = '20180318_2336_P_25_I'

	-- select count(*) from INV_dPosiciones where documentoasociado = '20180318_2328_P_01_I' and fase = 'Control Automático'
GO


