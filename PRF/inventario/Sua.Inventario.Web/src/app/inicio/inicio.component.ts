import { Component, OnInit, AfterViewInit } from '@angular/core';
import { AppContextService } from '../services/appContext.service';
import { AppContext } from '../models/appContext';
import { Router } from '@angular/router';
import { Menu } from '../models/menu';

@Component({
    selector: 'app-inicio',
    templateUrl: './inicio.component.html',
    styleUrls: ['./inicio.component.css']
})

export class InicioComponent implements OnInit  {
  public appContext: AppContext;
  public bussy: boolean;
  public menu: Menu[];

  constructor(private context: AppContextService, private router: Router) {
    this.bussy = true;
  }

  ngOnInit() {
    this.appContext = this.context.getActualContext();
    this.menu = this.appContext.menu;
    this.bussy = false;
  }
}
