import { Component, OnInit, ViewChild, EventEmitter, Output } from '@angular/core';
import { DaterangePickerComponent } from 'ng2-daterangepicker';
import * as moment from 'moment';
import { Filtro } from '../../models/filtro';
import { CC } from '../../models/cc';
import { HttpManagerService } from '../../services/manager.service';
import $ from "jquery";
import { Region } from '../../models/region';
import { AppContextService } from '../../services/appContext.service';
import { FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: "app-filtrosConsultar",
  templateUrl: "./filtrosConsultar.component.html",
  styleUrls: ["./filtrosConsultar.component.scss"]
})

export class FiltrosConsultarComponent implements OnInit {
  regiones: Region[];
  daterangeC: any = {};
  filtro: Filtro;
  public ccs: CC[];
  filtroForm: FormGroup;
  cargoCC = true;

  @Output('filtroData') filtroEvent = new EventEmitter<string>();

  @ViewChild(DaterangePickerComponent)
  picker: DaterangePickerComponent;
  options: any = {
    locale: {
      format: 'DD/MM/YYYY',
      separator: ' - ',
      applyLabel: 'Aceptar',
      cancelLabel: 'Cancelar',
      fromLabel: 'Desde',
      toLabel: 'Hasta',
      customRangeLabel: 'Custom',
      daysOfWeek: [
        'Do',
        'Lu',
        'Ma',
        'Mi',
        'Ju',
        'Vi',
        'Sa'
      ],
      monthNames: [
        'Enero',
        'Febrero',
        'Marzo',
        'Abril',
        'Mayo',
        'Junio',
        'Julio',
        'Agosto',
        'Septiembre',
        'Octubre',
        'Noviembre',
        'Diciembre'
      ]
    },
    alwaysShowCalendars: false,
    autoUpdateInput: false
  };

  constructor(private http: HttpManagerService, private context: AppContextService) {
    this.daterangeC = {};
    this.filtro = new Filtro('', '');
    this.filtroForm = new FormGroup({
      region: new FormControl(''), // [Validators.required]),
      cc: new FormControl('')
    });
  }

  selectedDate(value: any, tipo: string) {
    if (tipo === 'C') {
      if (value != null) {
        this.daterangeC.start = value.start;
        this.daterangeC.end = value.end;
        this.daterangeC.label = value.label;
        this.filtro.fecha = value.start.format('DD/MM/YYYY') + ' - ' + value.end.format('DD/MM/YYYY');
      } else {
        this.picker.datePicker.startDate = moment();
        this.picker.datePicker.endDate = moment();
        this.daterangeC = {};
        this.filtro.fecha = '';
      }
    }
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
    this.regiones = this.context.getRegiones();
  }


  onSubmit() {
    let fechaCDesde = '';
    let fechaCHasta = '';
    if (this.filtro.fecha !== '') {
      const fechas = this.FormatStringDate(this.filtro.fecha);
      fechaCDesde = fechas.yearFrom + '-' + fechas.monthFrom + '-' + fechas.dayFrom;
      fechaCHasta = fechas.yearTo + '-' + fechas.monthTo + '-' + fechas.dayTo;
    }

    const valores = '/' + fechaCDesde + '/' + fechaCHasta + '/' + this.filtroForm.controls['cc'].value;
    this.filtroEvent.emit(valores);
  }

  FormatStringDate(fecha: string): any {
    return {
      dayFrom: fecha.slice(0, 2),
      monthFrom: Number(fecha.slice(3, 5)),
      yearFrom: fecha.slice(6, 10),
      dayTo: fecha.slice(13, 15),
      monthTo: Number(fecha.slice(16, 18)),
      yearTo: fecha.slice(19, 23)
    };
  }

  onRegionChange($event: any) {
    this.cargoCC = false;
    this.ccs = [];
    this.http.get<CC[]>(`CC/xIdRegion/` + $event).subscribe(data => {
      for (const cc of data) {
        this.ccs.push(cc);
      }
        this.cargoCC = true;
    });
  }
}
