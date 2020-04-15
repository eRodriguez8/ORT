import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HttpManagerService } from '../../../services/manager.service';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { SecurityService } from '../../../services/security.service';
import { Documento } from '../../../models/documento';

@Component({
  selector: 'app-asignar',
  templateUrl: './asignar.component.html',
  styleUrls: ['./asignar.component.scss']
})

export class AsignarComponent implements OnInit {
  @Input() formRecep: FormGroup;
  idDocumento: number;
  documento: string;
  cargandoUsuario = false;
  ErrorAsigando = false;

  constructor(public activeModal: NgbActiveModal, public http: HttpManagerService,
              public security: SecurityService) {
  }

  ngOnInit() {
    this.formRecep = new FormGroup({
      documento: new FormControl(this.documento),
      legajo: new FormControl('', [Validators.required]),
      usuario: new FormControl('')
    });
  }

  onSubmit() {
    if (this.formRecep.invalid) {
      return;
    }
    // tslint:disable-next-line: max-line-length
    this.http.post<Documento>('Documento/Asignacion/' + this.idDocumento + '/' + this.formRecep.controls.legajo.value, null).subscribe(data => {
      const response = (data) as unknown as string;
      if (response === 'OK') {
        this.ErrorAsigando = false;
        this.activeModal.close('aceptar');
      } else {
        this.ErrorAsigando = true;
      }
    });
  }

  getLegajo($event: any) {
    this.ErrorAsigando = false;
    this.cargandoUsuario = true;
    this.security.getLegajo($event)
      .subscribe(data => {
        if (data != null) {
          this.formRecep.patchValue({ usuario: data.nombre.trim() + ' ' + data.apellido.trim() });
          this.cargandoUsuario = false;
        } else {
          this.formRecep.patchValue({ usuario: 'USUARIO INEXISTENTE'});
          this.formRecep.patchValue({ legajo: ''});
          this.cargandoUsuario = false;
        }
      });
  }

  public Salir(): void {
    this.activeModal.close('cancelar');
  }
}
