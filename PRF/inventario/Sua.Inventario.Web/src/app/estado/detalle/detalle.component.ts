import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { HttpManagerService } from '../../services/manager.service';
import { ReporteDocumento } from 'src/app/models/ReporteDocumento';
import { ReporteInventario } from 'src/app/models/ReporteInventario';
import { FiltroReporte } from 'src/app/models/filtroReporte';
import { HelperService } from 'src/app/services/helper.service';
import { Response } from 'selenium-webdriver/http';
import { RespuestaExcel } from 'src/app/models/respuestaExcel';
import { EstadoDocumento } from 'src/app/models/estadoDocumento';

@Component({
  selector: 'app-detalle',
  templateUrl: './detalle.component.html',
  styleUrls: ['./detalle.component.scss']
})
export class DetalleComponent implements OnInit {

  dtReporte: any = {};
  estadisticasInventario: ReporteInventario;
  reportes: ReporteDocumento[];
  cargoGrilla = false;
  filtros: FiltroReporte;
  @Output('removeInv') removeInvEvent = new EventEmitter<string>();

  constructor(private http: HttpManagerService, private helper: HelperService) {
  }
  @Input() idInventario: number;
  @Input() statusInv: string;

  ngOnInit() {
    this.estadisticasInventario = new ReporteInventario();
    this.cargoGrilla = true;
    this.cargarGrilla();
  }

  cargarGrilla() {
    this.cargoGrilla = false;
    if (this.filtros == null || this.filtros === undefined) {
      let fil = new FiltroReporte();
      fil.id = this.idInventario;
      fil.fase = null;
      this.http.post<ReporteDocumento[]>('Inventario/Estado/', fil ).subscribe(dataResult => {
        this.reportes = dataResult;
        this.calcularTotales(this.reportes);
        this.fillTable();
      });
    } else {
      this.http.post<ReporteDocumento[]>('Inventario/Estado/', this.filtros).subscribe(dataResult => {
        this.reportes = dataResult;
        this.calcularTotales(dataResult);
        this.fillTable();
      });
    }
  }

  fillTable() {
    this.dtReporte = {
      searching: false,
      lengthChange: false,
      processing: true,
      select: true,
      scrollX: true,
      language: {
        info: 'Mostrando página _PAGE_ de _PAGES_',
        infoEmpty: '',
        sEmptyTable: 'Sin datos',
        paginate: {
          previous: 'Anterior',
          next: 'Siguiente'
        }
      }
    };
    this.cargoGrilla = true;
  }

  calcularTotales(dataResult: ReporteDocumento[]) {
    this.estadisticasInventario = new ReporteInventario();
    for (let repor of dataResult) {
      this.estadisticasInventario.totalLineas += repor.lineasTotales;
      this.estadisticasInventario.totalContadas += repor.lineasContadas;
      this.estadisticasInventario.totalConDescuadre += repor.totalConDescuadre;
      this.estadisticasInventario.totalDescuadreArticulo += repor.totalDescuadreArticulo;
      this.estadisticasInventario.totalDiferenciaBulto += repor.totalDiferenciaBulto;
      this.estadisticasInventario.totalDiferenciaEtiqueta += repor.totalDiferenciaEtiqueta;
      this.estadisticasInventario.totalSinDescuadre += repor.totalSinDescuadre;
      repor.estadoString = this.replazarEstado(repor.estado);
    }
    // tslint:disable-next-line: max-line-length
    this.estadisticasInventario.totalPorcentaje = (this.estadisticasInventario.totalContadas / this.estadisticasInventario.totalLineas) * 100;
    this.estadisticasInventario.totalDescuadresGeneral = this.estadisticasInventario.totalConDescuadre +
      this.estadisticasInventario.totalDescuadreArticulo + this.estadisticasInventario.totalDiferenciaBulto +
      this.estadisticasInventario.totalDiferenciaEtiqueta;
  }

  public obtenerFiltros(filtro: any) {
    this.filtros = filtro;
    this.filtros.id = this.idInventario;
    this.cargarGrilla();
  }

  volver() {
    this.removeInvEvent.emit('0');
  }
  descargar() {
    this.http.get<RespuestaExcel>('Inventario/EstadoExcel/' + this.idInventario ).subscribe(dataResult => {
      this.helper.downloadFile(dataResult.bytes, dataResult.nombre);
    });
  }
  replazarEstado(idEstado: number) {
    switch (idEstado) {
      case 0:
        return EstadoDocumento[EstadoDocumento.Creado];
      case 1:
        return EstadoDocumento[EstadoDocumento.Asignado];
      case 2:
        return EstadoDocumento[EstadoDocumento.Finalizado];
      case 3:
        return EstadoDocumento[EstadoDocumento.Cancelado];
      default:
        return ' ';
    }
  }


}
