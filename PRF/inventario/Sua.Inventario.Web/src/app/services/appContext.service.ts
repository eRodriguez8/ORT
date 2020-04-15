import { Injectable } from '@angular/core';
import { AppContext } from '../models/appContext';
import { Region } from "../models/region";

@Injectable()
export class AppContextService {

  private appContext: AppContext;
  private regiones: Region[];

  constructor() { }

  setActualContext(context: AppContext) {
    this.appContext = context;
  }

  getActualContext() {
    return this.appContext;
  }

  setRegiones(regiones: Region[]) {
    this.regiones = regiones;
  }

  getRegiones() {
    return this.regiones;
  }
}
