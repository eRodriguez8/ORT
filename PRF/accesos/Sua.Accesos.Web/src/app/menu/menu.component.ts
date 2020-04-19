import { Component, Input, OnInit } from '@angular/core';
import { AppContext } from '../models/appContext';
import { environment } from '../../environments/environment';

@Component({
    selector: 'app-menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

    appContext: AppContext;
    urlDistribuidor: string;

    @Input()
    set context(context: AppContext) {
        this.appContext = context;
    }

    constructor() {
      this.urlDistribuidor = `${environment.server}` + 'Distribuidor';
    }

    ngOnInit() {
    }



}
