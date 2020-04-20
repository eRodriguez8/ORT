USE [CDs]
GO
/****** Object:  StoredProcedure [dbo].[INV_dDocumentos_SelectxLegajo]    Script Date: 19/4/2020 22:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rodriguez Emanuel
-- Create date: 16 de Agosto de 2019
-- Description:	Trae el documento asociado al legajo
-- =============================================
CREATE PROCEDURE [dbo].[INV_dDocumentos_SelectxLegajo]
	@legajo as nvarchar(20)
AS
BEGIN
	select d.id, d.Documento from INV_dDocumentos d
	where LegajoAsignado = @legajo and Estado = 1
END

GO
/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_AjusteSega]    Script Date: 19/4/2020 22:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INV_dPosiciones_AjusteSega]
	@idDoc int
AS

declare @Estado nvarchar(50)
declare @contenedor nvarchar(20)
declare @ean13 nvarchar(15)
declare @bultosinv int
DECLARE	@return_value int
/*
set @Estado = 'Diferencia Bultos'
set @contenedor = 'PA20190718203655264'
set @ean13 = '7794940000116 '
set @bultosinv = 100
*/
DECLARE cursor_posiciones CURSOR
FOR SELECT 
        estado, 
        etiqueta,
		ean13,
		bultosinv
    FROM 
        INV_dPosiciones
	Where idDocumento = @idDoc;
 
OPEN cursor_posiciones;
 
FETCH NEXT FROM cursor_posiciones INTO 
    @Estado, 
    @contenedor,
	@ean13,
	@bultosinv;
 
WHILE @@FETCH_STATUS = 0
    BEGIN
        exec server_sega.disco_sega.dbo.SUA_SP_INVENTARIO_AJUSTES @Estado, @contenedor, @ean13, @bultosinv
        FETCH NEXT FROM cursor_posiciones INTO 
            @Estado, 
			@contenedor,
			@ean13,
			@bultosinv;
    END;
 
CLOSE cursor_posiciones;
DEALLOCATE cursor_posiciones;

update INV_dDocumentos
set ImpactadoSega = 1
where id = @idDoc;

set @return_value = 0
SELECT	'Return Value' = @return_value
GO
/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_Borrar]    Script Date: 19/4/2020 22:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[INV_dPosiciones_Borrar]
	@Id int = null
as
delete
from INV_dPosiciones 
where Id = @Id



GO
/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_CrearControlForzado]    Script Date: 19/4/2020 22:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INV_dPosiciones_CrearControlForzado]
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
where d.id = @idDoc and d.fase = 2) = 0
begin
    if  ((select count(*) from [CDs].[dbo].[INV_dPosiciones] d where d.idDocumento = @idDoc and d.fechaact is null) = 0 
	and (select count(*) as Cantidad from INV_dPosiciones p where p.idDocumento = @idDoc and p.estado <> 'Sin Descuadre') > 0 )
    BEGIN
        select p.*
        into #Posiciones
        from INV_dPosiciones p 
        where p.idDocumento = @idDoc and p.estado <> 'Sin Descuadre'
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
GO
/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_Delete]    Script Date: 19/4/2020 22:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




create proc [dbo].[INV_dPosiciones_Delete]
	@id Int = 0
as
delete INV_dPosiciones where ((id = @id) or (@id = 0))





GO
/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_DocumentosSelect]    Script Date: 19/4/2020 22:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[INV_dPosiciones_DocumentosSelect]
as
select distinct Documento From INV_dPosiciones



GO
/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_Insert]    Script Date: 19/4/2020 22:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[INV_dPosiciones_Insert]
	@Documento nvarchar(255),
	@Sector nvarchar(255),
    @PASILLO float,
    @COLUMNA float,
    @NIVEL float,
    @COMPART float,
    @ETIQUETA nvarchar(255),
    @ean13 nvarchar(255),
    @DESCRIPCION nvarchar(255),
    @Proveedor nvarchar(255),
    @ID_ORDEN_COMPRA nvarchar(255),
    @Fecha_hora_recepcion datetime,
    @Vencimiento datetime,
    @VidaUtil float,
    @DiasVencer nvarchar(255),
    @CxH float,
    @HxP float,
    @UxB float,
    @UxPck float,
    @Bultos float,
    @Packs float,
    @Unidades float,
    @Recepcionista nvarchar(255),
    @Almacenador nvarchar(255),
    @EstadoCalidad nvarchar(255),
    @CARA float,
    @TipoInventario nvarchar(100),
	@tipolectura nvarchar(100) = 'Ubicacion'
as
INSERT INTO INV_dPosiciones
           ([Documento]
           ,[Sector]
           ,[PASILLO]
           ,[COLUMNA]
           ,[NIVEL]
           ,[COMPART]
           ,[ETIQUETA]
           ,[ean13]
           ,[DESCRIPCION]
           ,[Proveedor]
           ,[ID_ORDEN_COMPRA]
           ,[Fecha_hora_recepcion]
           ,[Vencimiento]
           ,[VidaUtil]
           ,[DiasVencer]
           ,[CxH]
           ,[HxP]
           ,[UxB]
           ,[UxPack]
           ,[Bultos]
           ,[Packs]
           ,[Unidades]
           ,[Recepcionista]
           ,[Almacenador]
           ,[EstadoCalidad]
           ,[CARA], TS, TipoInventario, tipolectura)
     select
           @Documento
           ,@Sector
           ,@PASILLO
           ,@COLUMNA
           ,@NIVEL
           ,@COMPART
           ,@ETIQUETA
           ,@ean13
           ,@DESCRIPCION
           ,@Proveedor
           ,@ID_ORDEN_COMPRA
           ,@Fecha_hora_recepcion
           ,@Vencimiento
           ,@VidaUtil
           ,@DiasVencer
           ,@CxH
           ,@HxP
           ,@UxB
           ,@UxPck
           ,@Bultos
           ,@Packs
           ,@Unidades
           ,@Recepcionista
           ,@Almacenador
           ,@EstadoCalidad
           ,@CARA, getdate(), @TipoInventario, @tipolectura





GO
/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_ReiniciarDocumento]    Script Date: 19/4/2020 22:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE proc [dbo].[INV_dPosiciones_ReiniciarDocumento]
	@idDoc as int
AS

BEGIN
	Declare @reinicio as bit
	
	Update INV_dPosiciones
	Set 
		Usuario = '',
		FechaAct = getdate()
	Where idDocumento = @idDoc
	
	set @reinicio = 1
	
	select @reinicio as Reinicio
END






GO
/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_ReiniciarDocumento2]    Script Date: 19/4/2020 22:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE proc [dbo].[INV_dPosiciones_ReiniciarDocumento2]
	@doc as varchar(30)
AS

Declare @reinicio as bit

BEGIN TRY
    Update INV_dPosiciones
	Set 
		Usuario = null,
		FechaAct = getdate()
	Where Documento = @doc
	
	Set @reinicio = 1
	
	Select @reinicio as Reinicio
END TRY
BEGIN CATCH
	Update INV_dPosiciones
	Set
		Usuario = 'Revisar',
		FechaAct = getdate(),
		Observaciones = ERROR_LINE() + ' - ' + ERROR_MESSAGE()
		Where Documento = @doc
		
		Set @reinicio = 0	
		
		Select @reinicio as Reinicio						
END CATCH






GO
/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_Select]    Script Date: 19/4/2020 22:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[INV_dPosiciones_Select]
	@FechaIni datetime = null,
	@FechaFin datetime = null,
	@Documento nvarchar(50) = ''
as
Select 
	Estado,
	Id,
	Documento,
	Sector,
	PASILLO,
	COLUMNA,
	NIVEL,
	COMPART,
	ETIQUETA,
	ean13,
	DESCRIPCION,
	Proveedor,
	ID_ORDEN_COMPRA,
	Fecha_hora_recepcion,
	Vencimiento,
	VidaUtil,
	DiasVencer,
	CxH,
	HxP,
	UxB,
	UxPack,
	Bultos,
	Packs,
	Unidades,
	Recepcionista,
	Almacenador,
	EstadoCalidad,
	CARA,
	Usuario,
	Digito,
	BultosInv,
	Ts,
	FechaAct,
	UsuarioInventario,
	TipoInventario,
	HxPInv,
	CajasSueltasInv,	
	Observaciones,
	CodigoArticulo
from INV_dPosiciones 
where ((@Documento = '' and (convert(nvarchar, ts, 111) between convert(nvarchar, @FechaIni, 111) and convert(nvarchar, @FechaFin, 111)))
or documento = @Documento)
order by Id 






GO
/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_SelectByDocumento]    Script Date: 19/4/2020 22:37:18 ******/
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
/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_SelectDisponible]    Script Date: 19/4/2020 22:37:18 ******/
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
/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_SelectResumen]    Script Date: 19/4/2020 22:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[INV_dPosiciones_SelectResumen]
	@FechaIni datetime = null,
	@FechaFin datetime = null
as
/*declare @FechaIni datetime
declare @FechaFin datetime

set @FechaIni = getdate() - 30
set @FechaFin = getdate()
*/
select ROW_NUMBER() over(partition by documento order by Documento, fechaact) as RowNro, *
into #DifPosiciones
from INV_dPosiciones 

select 
	Documento,
	RowNro,
	Minutos = isnull(datediff(minute, (select top 1 fechaact from #DifPosiciones b where a.documento = b.documento and a.RowNro > b.RowNro order by b.RowNro desc), fechaact), 0)
Into #MinutosPosiciones
from #DifPosiciones a
where convert(nvarchar, ts, 111) between convert(nvarchar, @FechaIni, 111) and convert(nvarchar, @FechaFin, 111)

select 
	Documento,
	LineasTotales = count(distinct id),
	PrimerLectura = min(fechaact),
	UltimaLectura = max(fechaact)
Into #Tmp
from
	INV_dPosiciones
where convert(nvarchar, ts, 111) between convert(nvarchar, @FechaIni, 111) and convert(nvarchar, @FechaFin, 111)
group by documento

Select
	*,
	LineasContadas = (select count(distinct id) from INV_dPosiciones b where b.usuario is not null and b.documento = a.documento)
Into #Tmp2
from
	#Tmp a
order by documento

Select
	Documento,
	LineasTotales,
	LineasContadas,
	Porcentaje = (LineasContadas * 100) / LineasTotales,
	PrimerLectura,
	UltimaLectura,
	MinOperacion = datediff(minute, PrimerLectura, UltimaLectura),
	MinUltimaLectura = case when lineastotales <> lineascontadas then datediff(minute, UltimaLectura, getdate()) else 0 end,
	MinPromEntreUbicac = (select avg(minutos) from #MinutosPosiciones b where a.documento = b.documento),
	MaximoMinEntreUbic = (select max(minutos) from #MinutosPosiciones b where a.documento = b.documento),
	CantPosicionesMas30Min = (select count(*) from #MinutosPosiciones b where a.documento = b.documento and Minutos > 30),
	PromedioLineasXMin = (LineasContadas / (case when (datediff(minute, PrimerLectura, UltimaLectura)) > 0 then (datediff(minute, PrimerLectura, UltimaLectura)) else 1 end)),
	PromedioDescuadre = ((select count(id) from INV_dPosiciones a1 where estado <> 'Sin Conteo' and estado <> 'Sin Descuadre' and a1.documento = a.documento) * 100) / LineasTotales
from
	#Tmp2 a
order by 
	(LineasContadas * 100) / LineasTotales desc

drop table #Tmp2
drop table #Tmp
drop table #DifPosiciones
drop table #MinutosPosiciones
GO
/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_Update]    Script Date: 19/4/2020 22:37:18 ******/
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
						when (bultosinv = -1 or digito = '.') and etiqueta <> '' then 'Con Descuadre' /* la ubicación no está vacia y se ingresó ubicación vacía */ 
						when (bultosinv = -1 or digito = '.') and etiqueta = '' then 'Sin Descuadre' /* la ubicación está vacia y se ingresó ubicación vacía */ 
						when digito <> ltrim(rtrim(etiqueta)) and digito <> right(ltrim(rtrim(etiqueta)), len(digito)) and upper(digito) <> 'P' then 'Diferencia Etiqueta' 
						when CodigoArticulo <> '(-.-)' and codigoarticulo <> '.' and digito = right(ltrim(rtrim(etiqueta)), 2) and CodigoArticulo <> ean13 then 'Descuadre de Articulo'
						when upper(Digito) = 'P' and (codigoarticulo = '.' and ean13 <> '') then 'Descuadre de Articulo'
						when ltrim(rtrim(ean13)) <> ltrim(rtrim(replace(codigoarticulo, '	', ''))) then 'Descuadre de Articulo'
						when codigoarticulo = '.' and ean13 = '' then 'Sin Descuadre'
						when CodigoArticulo = 'Revisar' then 'Revisar'
						when bultos <> bultosinv then 'Diferencia Bultos'
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
/****** Object:  StoredProcedure [dbo].[INV_dPosiciones_ValidarYCrearControles]    Script Date: 19/4/2020 22:37:18 ******/
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
if ((select count(*) as Cantidad from INV_dPosiciones p WITH (NOLOCK) where p.idDocumento = @idDoc and p.fechaact is null) = 0 and 
(select count(*) as Cantidad from INV_dPosiciones p WITH (NOLOCK) where p.idDocumento = @idDoc and p.estado <> 'Sin Descuadre') > 0 )  
begin
	/* miro si ya está creado el control */
	if (select d.Fase from [CDs].[dbo].[INV_dDocumentos] d WITH (NOLOCK) where d.id = @idDoc) > 0
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
		from [CDs].[dbo].[INV_dPosiciones] as p WITH (NOLOCK)
		where p.idDocumento = @idDoc and p.estado <> 'Sin Descuadre'
		order by id

		declare @Fase nvarchar(max)
	
		set @Fase = 'Control Automático'
		
		set @idInventario = (select d.idInventario 
					from [CDs].[dbo].[INV_dDocumentos] d WITH (NOLOCK)
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
		update #Posiciones set iddocumento = (select d.id from [CDs].[dbo].[INV_dDocumentos] d WITH (NOLOCK) where d.idDocumentoPadre = @idDoc)

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
GO
/****** Object:  StoredProcedure [dbo].[INV_EstadoActual]    Script Date: 19/4/2020 22:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[INV_EstadoActual]
	@IdInventario int,
	@Fase int
as
select 
	docu.Documento,
	docu.id,
	docu.UltimoLegajoAsignado,
	docu.Estado,
	LineasTotales = count(distinct pos.id),
	PrimerLectura = min(pos.fechaact),
	UltimaLectura = max(pos.fechaact)
Into #Tmp
from
	INV_dDocumentos docu,
	INV_dPosiciones pos
where docu.idInventario = @IdInventario
and (docu.Fase = @Fase or @Fase is NULL)
and pos.idDocumento = docu.id
and docu.Estado != 3
group by Docu.Documento,docu.id,docu.UltimoLegajoAsignado,docu.Estado

Select
	*,
	LineasContadas = (select count(distinct id) from INV_dPosiciones b where b.fechaact is not null and b.estado is not null and b.idDocumento = a.id)
Into #Tmp2
from
	#Tmp a
order by documento

Select
	Documento,
	UltimoLegajoAsignado,
	LineasTotales,
	LineasContadas,
	Porcentaje = ((LineasContadas * 100.00) / LineasTotales),
	Estado,
	PrimerLectura,
	UltimaLectura,
	TiempoOperacionMinutos =  ISNULL(datediff(minute, PrimerLectura, UltimaLectura), 0 ) ,
	TiempoUltimaLecturaMinutos = ISNULL((case when lineastotales <> lineascontadas then datediff(minute, UltimaLectura, getdate()) else 0 end),0),
	PromedioLineasXMinuto = CAST(((LineasContadas / (case when (datediff(minute, PrimerLectura, UltimaLectura)) > 0 then (datediff(minute, PrimerLectura, UltimaLectura)) else 1 end))) AS decimal),
	PromedioDescuadre =((((select count(id) from INV_dPosiciones a1 where estado <> 'Sin Conteo' and estado <> 'Sin Descuadre' and a1.idDocumento = a.id) * 100.00) / LineasTotales)),
	TotalSinDescuadre = (select count(id) from INV_dPosiciones a1 where estado = 'Sin Descuadre' and a1.idDocumento = a.id),
	TotalDiferenciaEtiqueta = (select count(id) from INV_dPosiciones a1 where estado = 'Diferencia Etiqueta' and a1.idDocumento = a.id),
	TotalDiferenciaBulto = (select count(id) from INV_dPosiciones a1 where estado = 'Diferencia Bultos' and a1.idDocumento = a.id),
	TotalConDescuadre = (select count(id) from INV_dPosiciones a1 where estado = 'Con Descuadre' and a1.idDocumento = a.id),
	TotalDescuadreArticulo = (select count(id) from INV_dPosiciones a1 where estado = 'Descuadre de Articulo' and a1.idDocumento = a.id)
from
	#Tmp2 a
order by 
	(LineasContadas * 100) / LineasTotales

drop table #Tmp2
drop table #Tmp


GO
