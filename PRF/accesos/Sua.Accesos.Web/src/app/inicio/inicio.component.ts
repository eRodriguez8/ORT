import { Component, OnInit, Output, Input, EventEmitter, ViewContainerRef } from '@angular/core';
import { AppContextService } from '../services/appContext.service';
import { AppContext } from '../models/appContext';



@Component({
    selector: 'app-inicio',
    templateUrl: './inicio.component.html',
    styleUrls: ['./inicio.component.css']
})

export class InicioComponent implements OnInit {

  public appContext: AppContext;

     constructor (private context: AppContextService) {
    }

    ngOnInit() {
        this.appContext = this.context.getActualContext();
    }

}
