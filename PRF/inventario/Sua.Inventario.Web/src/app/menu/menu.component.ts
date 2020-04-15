import { Component, Input, OnInit } from '@angular/core';
import { Usuario } from '../models/usuario';
import { AppContext } from '../models/appContext';
import { environment } from 'src/environments/environment';

@Component({
    selector: 'app-menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

    public appContext: AppContext;
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
