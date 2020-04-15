import { Component, OnInit, ViewChild } from "@angular/core";
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpManagerService } from "../services/manager.service";
import { Region } from "../models/region";
import { CC } from "../models/cc";
import { AppContextService } from "../services/appContext.service";
import { InventarioAM } from '../models/InventarioAM';
import { Inventario } from '../models/inventario';
import { importExpr } from '@angular/compiler/src/output/output_ast';
import { ImportarAM } from '../models/ImportarAM';
import { Subscription } from 'rxjs';

@Component({
  selector: "app-importar",
  templateUrl: "./importar.component.html",
  styleUrls: ["./importar.component.scss"]
})

export class ImportarComponent implements OnInit {
  uploadForm: FormGroup;
  genero = false;
  public regiones: Region[];
  public ccs: CC[];
  public inputRutaVal: any;
  public busy: Subscription;
  esNuevoInv: boolean;
  bytesExcel: Uint8Array;
  activado = true;

  @ViewChild('fileInput')
  fileInput: any;

  constructor(private context: AppContextService, private http: HttpManagerService) {
    this.regiones = [];
    this.ccs = [];
  }

  ngOnInit() {
    this.uploadForm = new FormGroup({
      ruta: new FormControl('', [Validators.required]),
      regiones: new FormControl('', [Validators.required]),
      cc: new FormControl('', [Validators.required]),
      esNuevoInv: new FormControl(),
      nombre: new FormControl('')
    });
    this.regiones = this.context.getRegiones();
  }

  fileUpload() {
    try {
      let rutacompleta: any = (document.getElementById("file"));
      if (rutacompleta != undefined && rutacompleta.files.length > 0) {
        if (rutacompleta.files[0].name.length <= 4) {
          this.http.ShowNotification('Error', 'El archivo que esta intentando subir no tiene un formato válido', null, null, null);
          return;
        }

        let extension: string = rutacompleta.files[0].name.substring(rutacompleta.files[0].name.length - 4);

        if (extension == '.xls' || extension == 'xlsx') {
          this.uploadForm.controls['ruta'].setValue(rutacompleta.files[0].name);
          this.inputRutaVal = rutacompleta.files[0];
        }
        else {
          this.http.ShowNotification('Error', 'El archivo que esta intentando subir no tiene un formato válido', null, null, null);
          return;
        }
      }
      else {
        this.http.ShowNotification('Error', 'Archivo invalido', null, null, null);
        return;
      }
    }
    catch (Error) {
      this.http.ShowNotification('Error', 'Ocurrió un error', null, null, null);
      return;
    }
  }

  onRegionChange($event: any) {
    this.ccs = [];
    this.http.get<CC[]>(`CC/xIdRegion/` + $event).subscribe(data => {
      for (const cc of data) {
        this.ccs.push(cc);
      }
    });
  }

  onSubmit() {
    if (this.uploadForm.invalid) {
      const controls = this.uploadForm.controls;
      for (const name in controls) {
        if (controls[name].invalid) {
        }
      }
      return;
    }
    this.activado = false;
    if (this.esNuevoInv) {
      const nuevoInv = new InventarioAM(this.uploadForm.controls['nombre'].value,
        1, this.uploadForm.controls['cc'].value);
      this.http.post<Inventario>('Inventario/', nuevoInv).subscribe(data => {
        // if (!data) {
        //   this.http.ShowNotification('Error', 'Ocurrió un error al insertar el inventario. ' +
        //     'Contacte al administrador', null, null, null);
        // } else {
        //   this.importExcel(data.id)
        // }
        if (data) {
          this.importExcel(data.id);
        }
      }
      );
    } else {
      this.http.get<Inventario>('Inventario/xCC/' + this.uploadForm.controls['cc'].value)
        .subscribe(data => {
          if (!data) {
            this.http.ShowNotification('Error', 'Ocurrió un error al importar el inventario. ' +
              'De persistir el error contacte al administrador', null, null, null);
          } else {
            this.importExcel(data.id);
          }
        });
    }
  }

  getInventario(value: boolean) {
    this.esNuevoInv = value;
    if (value) {
      this.uploadForm.controls['nombre'].setValidators(Validators.required);
    } else {
      this.uploadForm.controls['nombre'].clearValidators();
    }
  }

  importExcel(idInventario: number) {
    let formData: FormData = new FormData();
    formData.append('uploadFile', this.inputRutaVal, this.inputRutaVal.name);

    this.busy = this.http.post<Inventario>('Inventario/ImportarExcel/' + idInventario + '/' + true, formData).subscribe(data => {
      this.genero = true;
      this.uploadForm.reset();
      this.fileInput.nativeElement.value = '';
      this.activado = true;
      setTimeout(c => {
        this.genero = false;
      }, 10000);
    });
  }
}

