import { Injectable } from '@angular/core';
import { Usuario } from '../models/usuario';
import { Observable, of } from 'rxjs';
import { AppContext } from '../models/appContext';

/**
 * @description
 * @class
 */
@Injectable()
export class SecurityServiceMock {

  constructor() {
  }

  public getUsuario(): Observable<Usuario> {
    return of(new Usuario());
  }

  public getAppContext(): Observable<AppContext> {
    return of(new AppContext());
  }

}
