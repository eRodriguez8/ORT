import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpManagerService } from './manager.service';
import { Usuario } from '../models/usuario';
import { AppContext } from '../models/appContext';

@Injectable({
    providedIn: 'root'
})
export class SecurityService {

    constructor(private httpManagerService: HttpManagerService) { }

    // public getContext(): Observable<AppContext> {
    //     return this.httpManagerService.get<AppContext>(`Context`);
    // }

    public getUsuario(): Observable<Usuario> {
      return this.httpManagerService.get<Usuario>(`Usuarios/xIdAplicacion/ACC`);
    }


    public getAppContext(): Observable<AppContext> {
      return this.httpManagerService.get<AppContext>(`AppContext/ACC`)
      ;
    }
}
