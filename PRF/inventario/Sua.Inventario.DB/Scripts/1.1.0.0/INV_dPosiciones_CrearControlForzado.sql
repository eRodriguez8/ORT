USE [CDs]
GO
/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_CrearControlForzado]    Script Date: 10/10/2019 16:30:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[INV_dPosiciones_CrearControlForzado]
    @idDoc int
as

declare @Salida nvarchar(100)
declare @Documento nvarchar(255)
declare @idInventario int
declare @idPadre int

set @idPadre = (select d.idDocumentoPadre
from [CDs].[dbo].[INV_dDocumentos] d
where id = @idDoc)

set @Documento = (select d.Documento
from [CDs].[dbo].[INV_dDocumentos] d
where id = @idPadre)

if (select count(*)
from [CDs].[dbo].[INV_dDocumentos] d
where d.id = @idDoc and d.fase = 1) = 1
begin
    if  ((select count(*) from [CDs].[dbo].[INV_dPosiciones] d where d.idDocumento = @idDoc and d.fechaact is null) = 0 
	and (select count(*) as Cantidad from INV_dPosiciones p where p.idDocumento = @idDoc and p.estado <> 'Sin Descuadre') > 0 )
    BEGIN
        select p.*
        into #Posiciones
        from INV_dPosiciones p , INV_dDocumentos d
        where p.idDocumento = @idDoc and d.Fase = 1
            and p.estado <> 'Sin Descuadre'
        order by id

        declare @Fase nvarchar(max)

        set @Fase = 'Control Forzado'

        set @idInventario = (select d.idInventario
        from [CDs].[dbo].[INV_dDocumentos] d
        where id = @idDoc)


        insert into [CDs].[dbo].[INV_dDocumentos]
            (Documento, LegajoAsignado, Estado, Fecha, Usuario, idInventario, Fase, idDocumentoPadre)
        values
            (@Documento + ' ' + @Fase, '', 0, (SELECT CONVERT(VARCHAR(10), GETDATE(), 102)), 'Pocket', @idInventario, 2, @idDoc);

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
        update #Posiciones set iddocumento = (select d.id
        from [CDs].[dbo].[INV_dDocumentos] d
        where d.idDocumentoPadre = @idDoc)

        alter table #Posiciones drop column id

        insert into [CDs].[dbo].[INV_dPosiciones]
        select *
        from #Posiciones

        update [CDs].[dbo].[INV_dDocumentos] set Estado = 2
            where id = @idDoc

        update [CDs].[dbo].[INV_dDocumentos] set LegajoAsignado = ''
            where id = @idDoc

        drop table #Posiciones

        set @Salida = @Fase + ' Creado correctamente'
    END
    ELSE
    BEGIN
        select @Salida = 'Falta procesar posiciones o No hay registros con descuadres'
    END

end
else
begin
    select @Salida = 'Ya existe control forzado'
end

select @Salida as Resultado