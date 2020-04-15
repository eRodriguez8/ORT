import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-handle-error',
  templateUrl: './handle-error.component.html',
  styleUrls: ['./handle-error.component.css']
})
export class HandleErrorComponent implements OnInit {

  @Input()
  title: string;
  @Input()
  message: string;
  @Input()
  exceptionMessage: string;
  @Input()
  imagen: string;

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit() {
  }

  public Aceptar(): void {
    this.activeModal.close('aceptar');
  }

}
