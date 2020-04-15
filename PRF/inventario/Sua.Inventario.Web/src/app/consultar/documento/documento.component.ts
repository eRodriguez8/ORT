import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Documento } from '../../models/documento';
import { HttpManagerService } from '../../services/manager.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AsignarComponent } from './asignar/asignar.component';
import { DocFiltroAM } from '../../models/DocFiltroAM';
import { EstadoDocumento } from 'src/app/models/estadoDocumento';
import { CancelarComponent } from '../documento/cancelar/cancelar.component';
import { RespuestaExcel } from 'src/app/models/respuestaExcel';
import { HelperService } from 'src/app/services/helper.service';

@Component({
  selector: 'app-documento',
  templateUrl: './documento.component.html',
  styleUrls: ['./documento.component.scss']
})

export class DocumentoComponent implements OnInit {
  dtdocumentos: any = {};
  documentos: Documento[];
  cargoGrilla = false;
  filtros: DocFiltroAM;
  documentoId = 0;
  impactadoSega: boolean;
  fase: string;
  componente = 'documento';
  @Output('removeInv') removeInvEvent = new EventEmitter<string>();
  asigno = false;

  constructor(private http: HttpManagerService, private modalService: NgbModal, private helper: HelperService ) {
    this.filtros = new DocFiltroAM(null, null, null, null, null, null, null, null);
  }
  @Input() idInventario: string;
  @Input() statusInv: string;
  ngOnInit() {
    this.cargoGrilla = true;
    this.cargarGrilla();
  }

  cargarGrilla() {
    this.cargoGrilla = false;
    this.http.get<Documento[]>('Documento/xIdInventario/' + this.idInventario).subscribe(dataResult => {
      this.documentos = dataResult;
      this.fillTable();
    });
  }

  fillTable() {
    this.dtdocumentos = {
      searching: false,
      lengthChange: false,
      processing: true,
      select: true,
      stateSave: true,
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

  public obtenerFiltrosDoc(filtro: DocFiltroAM) {
    this.filtros = filtro;
    this.recargarGrilla();
  }

  recargarGrilla() {
    this.cargoGrilla = false;
    this.filtros.idInventario = Number(this.idInventario);
    this.http.post<Documento[]>('Documento/xFiltros/', this.filtros).subscribe(dataResult => {
      this.documentos = dataResult;
      this.cargoGrilla = true;
    });
  }

  limpiarDoc(idDoc: string) {
    this.documentoId = 0;
  }

  volver() {
    this.removeInvEvent.emit('0');
  }

  consultarDoc(id: number, impactado: boolean, faseDoc: string) {
    this.documentoId = id;
    this.impactadoSega = impactado;
    this.fase = faseDoc;
  }

  asignarDoc(id: number, documento: string) {
    let doc = this.documentos.find(x => x.id == id);
    console.log(doc.estado);

    const modalRef = this.modalService.open(AsignarComponent, {
      windowClass: 'animated bounce modal-500',
      keyboard: false,
      backdrop: 'static'
    });

    modalRef.componentInstance.idDocumento = id;
    modalRef.componentInstance.documento = documento;
    modalRef.result.then((data) => {
      if (data !== 'cancelar') {
        this.asigno = true;
        setTimeout(c => {
          this.asigno = false;
        }, 5000);
        this.recargarGrilla();
      }
    });
  }

  desasignarDoc(id: number) {
    this.http.post<Documento>('Documento/Desasignacion/' + id, null).subscribe(data => {
      const response = data;
      if (response !== undefined) {
        this.asigno = false;
        setTimeout(c => {
          this.asigno = true;
        }, 5000);
        this.recargarGrilla();
      }
    });
  }

  cancelarDoc(id: number) {
    const modalRef = this.modalService.open(CancelarComponent, {
      windowClass: 'animated bounce modal-500',
      keyboard: false,
      backdrop: 'static'
    });

    modalRef.componentInstance.idDocumento = id;
    modalRef.componentInstance.documento = Document;

    modalRef.result.then((response) => {
      const respuesta = response as string;
      if (respuesta === 'aceptar') {
        this.http.delete<Documento>('Documento/CancelarDocumento/' + id).subscribe(data => {
          if (data !== undefined) {
            this.recargarGrilla();
          }
        });
      }
    });
  }

  descargarInventario(id: number ) {
    this.cargoGrilla = false;
    this.http.get<RespuestaExcel>('Inventario/ExcelPosiciones/' + id ).subscribe(dataResult => {
      this.helper.downloadFile(dataResult.bytes, dataResult.nombre);
      this.cargoGrilla = true;
    });
  }
  descargarPosicion(id: number ) {
    this.cargoGrilla = false;
    this.http.get<RespuestaExcel>('Posicion/ExportarExcel/' + id ).subscribe(dataResult => {
      this.helper.downloadFile(dataResult.bytes, dataResult.nombre);
      this.cargoGrilla = true;
    });
  }
}
