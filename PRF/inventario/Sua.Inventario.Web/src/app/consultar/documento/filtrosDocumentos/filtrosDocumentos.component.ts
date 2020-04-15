import { Component, OnInit, ViewChild, EventEmitter, Output, Input } from '@angular/core';
import { Filtro } from '../../../models/filtro';
import { HttpManagerService } from '../../../services/manager.service';
import { Fase } from '../../../models/fase';
import { AppContextService } from '../../../services/appContext.service';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { DocFiltroAM } from '../../../models/DocFiltroAM';
import { EstadoDocumento } from 'src/app/models/estadoDocumento';

@Component({
  selector: "app-filtrosDocumentos",
  templateUrl: "./filtrosDocumentos.component.html",
  styleUrls: ["./filtrosDocumentos.component.scss"]
})

export class FiltrosDocumentosComponent implements OnInit {
  filtro: DocFiltroAM;
  filtroForm: FormGroup;
  fases: Fase[];
  estados = EstadoDocumento;
  documentos = 'documento';

  @Output('filtroDataDoc') filtroDocEvent = new EventEmitter<DocFiltroAM>();
  @Input() padre: string;


  constructor(private http: HttpManagerService, private context: AppContextService) {
    this.filtro = new DocFiltroAM(null, null,null,null,null, null,null,null);
    this.filtroForm = new FormGroup({
      pasillo: new FormControl(''), // [Validators.required]),
      columna: new FormControl(''),
      nivel: new FormControl(''),
      documento: new FormControl(''),
      faseSelect: new FormControl(''),
      legajo: new FormControl(''),
      estadoSelect: new FormControl('')
    });
  }

  WidgetsCollapse(idCollapse: string, idOpen: string): void {
    $(idCollapse).find('a[data-toggle="collapse"]').trigger('click');
    if ($(idOpen).find('.fa-chevron-down').length > 0) {
      $(idOpen).trigger('click');
    }
  }

  WidgetClose(id: any): void {
    if ($(id).find('.fa-chevron-down').length > 0) {
      $(id).trigger('click');
    }
  }

  ngOnInit() {
    this.http.get<Fase[]>('Fase').subscribe(x => this.fases = x);
  }


  onSubmit() {
    this.filtro.columna = this.filtroForm.controls['columna'].value;
    this.filtro.documento = this.filtroForm.controls['documento'].value;
    this.filtro.fase = this.filtroForm.controls['faseSelect'].value;
    this.filtro.nivel = this.filtroForm.controls['nivel'].value;
    this.filtro.pasillo = this.filtroForm.controls['pasillo'].value;
    this.filtro.legajo = this.filtroForm.controls['legajo'].value;
    this.filtro.estado = this.filtroForm.controls['estadoSelect'].value;

    this.filtroDocEvent.emit(this.filtro);
  }
  keys(): Array<string> { var keys = Object.keys(this.estados); return keys.slice(keys.length / 2); }
}
