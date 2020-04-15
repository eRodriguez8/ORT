import { Component, OnInit, EventEmitter, Input, Output } from "@angular/core";
import { Posicion } from "../../../models/posicion";
import { HttpManagerService } from "../../../services/manager.service";
import { Documento } from 'src/app/models/documento';
import { DocFiltroAM } from 'src/app/models/DocFiltroAM';
import { RespuestaExcel } from 'src/app/models/respuestaExcel';
import { HelperService } from 'src/app/services/helper.service';
import { AppContext } from 'src/app/models/appContext';
import { AppContextService } from 'src/app/services/appContext.service';

@Component({
  selector: "app-posiciones",
  templateUrl: "./posiciones.component.html",
  styleUrls: ["./posiciones.component.scss"]
})

export class PosicionesComponent implements OnInit {
  dtposiciones: any = {};
  cargoGrilla = false;
  filtros: DocFiltroAM;
  componente = 'posiciones';
  esAdmin: boolean;
  public appContext: AppContext;
  mostrarLoader = false;
  @Output('removeDoc') removeDocEvent = new EventEmitter<string>();

  constructor(private http: HttpManagerService, private helper: HelperService, private context:AppContextService ) {
    this.appContext = context.getActualContext();
  }

  @Input() idDocumento: string;
  @Input() impactadoSega: boolean;
  @Input() fase: string;

  ngOnInit() {
    const valor = this.appContext.usuario.perfiles[0].aplicacion.acciones.filter((x) => x.descripcion === 'INV_ADM');
    this.esAdmin = valor !== undefined ? true : false;
    this.cargoGrilla = true;
    this.cargarGrilla();
    console.log(this.VerificarBoton());
  }

  cargarGrilla() {
    this.cargoGrilla = false;
    this.http.get<Posicion[]>('Posicion/xDocumentoId/' + this.idDocumento).subscribe(dataResult => {
      this.cargoGrilla = true;
      this.configGrilla(dataResult);
    });
  }
  recargarGrilla() {
    this.cargoGrilla = false;
    this.filtros.idInventario = Number(this.idDocumento);
    this.http.post<Documento[]>('Posicion/xFiltrosPos/', this.filtros).subscribe(dataResult => {
      this.configGrilla(dataResult);
      this.cargoGrilla = true;
    });
  }

  configGrilla(dataResult: any) {
    this.dtposiciones = {
      data: dataResult,
      searching: false,
      lengthChange: false,
      processing: true,
      select: true,
      scrollX: true,
      language: {
        info: 'Mostrando página _PAGE_ de _PAGES_',
        infoEmpty: '',
        sEmptyTable: 'Sin datos',
        sSearch: 'Buscar',
        paginate: {
          previous: 'Anterior',
          next: 'Siguiente'
        }
      },
      columns: [
        { title: 'Sector', data: 'sector' },
        { title: 'Pasillo', data: 'pasillo' },
        { title: 'Columna', data: 'columna' },
        { title: 'Nivel', data: 'nivel' },
        { title: 'Compart', data: 'compart' },
        { title: 'Etiqueta', data: 'etiqueta' },
        { title: 'Ean13', data: 'ean13' },
        { title: 'Desc.', data: 'descripcion' },
        { title: 'Proveedor', data: 'proveedor' },
        { title: 'Id OC', data: 'id_orden_compra' },
        { title: 'Fec. Recep', data: 'fecha_hora_recepcion' },
        { title: 'Vencimiento', data: 'vencimiento' },
        { title: 'Vida Util', data: 'vidautil' },
        { title: 'Dias a Vencer', data: 'diasvencer' },
        { title: 'Cxh', data: 'cxh' },
        { title: 'Hxp', data: 'hxp' },
        { title: 'Uxb', data: 'uxb' },
        { title: 'Uxpack', data: 'uxpack' },
        { title: 'Bultos', data: 'bultos' },
        { title: 'Packs', data: 'packs' },
        { title: 'Unidades', data: 'unidades' },
        { title: 'Recepcionista', data: 'recepcionista' },
        { title: 'Almacenador', data: 'almacenador' },
        { title: 'Estado Calidad', data: 'estadocalidad' },
        { title: 'Cara', data: 'cara' },
        { title: 'Metodo', data: 'metodo' },
        { title: 'Usuario', data: 'usuario' },
        { title: 'Digito', data: 'digito' },
        { title: 'Bultos Inv', data: 'bultosinv' },
        { title: 'Fecha Act', data: 'fechaact' },
        { title: 'Usuario Inv', data: 'usuarioinventario' },
        { title: 'Tipo Inv', data: 'tipoinventario' },
        { title: 'Hxp Inv', data: 'hxpinv' },
        { title: 'Cajas Sueltas', data: 'cajassueltasinv' },
        { title: 'Estado', data: 'estado' },
        { title: 'Obs', data: 'observaciones' },
        { title: 'Dun14', data: 'dun14' },
        { title: 'Codigo Art', data: 'codigoarticulo' },
        { title: 'Tipo Lectura', data: 'tipolectura' },
        { title: 'Doc Asociado', data: 'documentoasociado' }
      ]
    };
  }

  volver() {
    this.removeDocEvent.emit('0');
  }

  ImpactarEnSega(id: string) {
    this.mostrarLoader = true;
    this.http.put<Posicion>('Posicion/ImpactarSega/' + id, '').subscribe(dataResult => {
      this.http.ShowNotification('Exito', 'Se ha impactado con exito', null, null, null);
      this.mostrarLoader = false;
      this.impactadoSega = true;
    });
  }

  descargar(id: string) {
    this.mostrarLoader = true;
    this.http.get<RespuestaExcel>('Posicion/ExportarExcel/' + id ).subscribe(dataResult => {
      this.helper.downloadFile(dataResult.bytes, dataResult.nombre);
      this.mostrarLoader = false;
    });
  }

  VerificarBoton() {
    if (this.esAdmin && !this.impactadoSega && (this.fase === 'ControlAutomatico' || this.fase === 'ControlManual')) {
      return false;
    } else {
      return true;
    }
  }
  ControlManual(id: string) {
    this.mostrarLoader = true;
    this.http.post<Documento>('Documento/ControlManual/' + id, null).subscribe(data => {
      const response = (data) as unknown as string;
      this.mostrarLoader = false;
      if (response === 'Creado correctamente') {
        this.http.ShowNotification('Exito', 'Se ha generado un control manual', null, null, null);
        this.removeDocEvent.emit('0');
      } else {
        this.http.ShowNotification('Atención', response, null, null, null);
      }
    });
  }
   public obtenerFiltros(filtro: DocFiltroAM) {
    this.filtros = filtro;
    this.recargarGrilla();
   }
}
