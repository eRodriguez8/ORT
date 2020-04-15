import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpManagerService } from './manager.service';
import { Usuario } from '../models/usuario';
import { AppContext } from '../models/appContext';
import { Region } from '../models/region';

@Injectable({
    providedIn: 'root'
})

export class SecurityService {
    constructor(private httpManagerService: HttpManagerService) { }

    public getAppContext(): Observable<AppContext> {
      return this.httpManagerService.getExtAcc<AppContext>(`AppContext/INV`);
    }

    public getRegiones(): Observable<Region[]> {
      return this.httpManagerService.getExtAcc<Region[]>(`Regiones`);
    }

    public getLegajo(legajo: string): Observable<Usuario> {
      return this.httpManagerService.getExtAcc<Usuario>(`Usuarios/xLegajo/` + legajo);
    }
}
