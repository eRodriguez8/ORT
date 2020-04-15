import { Component, OnInit, Renderer2, ViewChild, NgZone, Inject, Input } from '@angular/core';
import { HttpManagerService } from '../services/manager.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Inventario } from '../models/inventario';

@Component({
  selector: 'app-consultar',
  templateUrl: './consultar.component.html',
  styleUrls: ['./consultar.component.scss']
})

export class ConsultarComponent {
  guardo = false;
  title = 'Inventarios';
  dtInventarios: any = {};
  inventarios: Inventario[];
  cargoGrilla = false;
  filtros = '';
  inventarioId = 0;
  inventarioEstado = '';
  estado = 'estado';
  @Input() padre: string;

  constructor(private http: HttpManagerService, private modalService: NgbModal) {
    this.cargoGrilla = true;
    this.cargarGrilla();
    this.inventarios = [];
  }

  ngOnInit() {
  }

  public obtenerFiltros(filtro: string) {
    this.filtros = filtro;
    this.recargarGrilla();
  }

  cargarGrilla() {
    this.dtInventarios = {
      searching: false,
      lengthChange: false,
      processing: true,
      select: true,
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
  }

  recargarGrilla() {
    this.cargoGrilla = false;
    this.http.get<Inventario[]>('Inventario/xFechas_CC' + this.filtros).subscribe(dataResult => {
      this.inventarios = dataResult;
      this.cargoGrilla = true;
    });
  }

  limpiarInv(idInv: string){
    this.inventarioId = 0;
    this.inventarioEstado = '';
  }

  consultar(id: number, estado: string) {
    this.inventarioId = id;
    this.inventarioEstado = estado;
  }

  cerrar(id: number, nombre: string) {
    if (confirm("¿Esta seguro que desea cerrar el inventario '" + nombre +
      "'? Esta accion no se puede deshacer, en caso de poseer documentos activos se finalizarán tambien.")) {
      this.http.delete<string>('Inventario/' + id)
      .subscribe(data => {
        this.guardo = true;
        this.recargarGrilla();
        setTimeout(c => {
          this.guardo = false;
        }, 10000);
      }
      );
    }
  }
}
