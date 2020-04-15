import { Component, OnInit, ViewChild, EventEmitter, Output } from '@angular/core';
import { HttpManagerService } from '../../services/manager.service';
import { Fase } from '../../models/fase';
import { AppContextService } from '../../services/appContext.service';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { FiltroReporte } from 'src/app/models/filtroReporte';

@Component({
  selector: 'app-filtro-estado',
  templateUrl: './filtro-estado.component.html',
  styleUrls: ['./filtro-estado.component.scss']
})
export class FiltroEstadoComponent implements OnInit {

  filtro: FiltroReporte;
  filtroForm: FormGroup;
  fases: Fase[];
  @Output('filtroReporte') filtroReporte = new EventEmitter<FiltroReporte>();

  constructor(private http: HttpManagerService, private context: AppContextService) {
    this.filtro = new FiltroReporte();
    this.filtroForm = new FormGroup({
      faseSelect: new FormControl('')
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
    this.filtro.fase = this.filtroForm.controls['faseSelect'].value;
    this.filtroReporte.emit(this.filtro);
  }
}
