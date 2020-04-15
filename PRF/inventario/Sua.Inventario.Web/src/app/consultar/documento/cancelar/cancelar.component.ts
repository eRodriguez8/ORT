import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HttpManagerService } from '../../../services/manager.service';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { SecurityService } from '../../../services/security.service';
import { Documento } from '../../../models/documento';

@Component({
  selector: 'app-cancelar',
  templateUrl: './cancelar.component.html',
  styleUrls: ['./cancelar.component.scss']
})
export class CancelarComponent implements OnInit {
  @Input() formRecep: FormGroup;
  idDocumento: number;
  documento: string;

  constructor(public activeModal: NgbActiveModal, public http: HttpManagerService,
              public security: SecurityService) { }

  ngOnInit() {
  }
  OkButton() {
    this.activeModal.close('aceptar');
  }
  Salir() {
    this.activeModal.close('cancelar');
  }
}
