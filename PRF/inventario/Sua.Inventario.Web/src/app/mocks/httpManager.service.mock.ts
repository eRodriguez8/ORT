import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

/**
 * @description
 * @class
 */
@Injectable()
export class HttManagerServiceMock {

  constructor() {
  }

  public get<T>(type: (new () => T), route: string): Observable<T> {
    return of(new type());
  }

  public post<T>(type: (new () => T), route: string, objeto: any): Observable<T> {
    return of(new type());
  }

  public getExt<T>(type: (new () => T), route: string): Observable<T> {
    return of(new type());
  }

  public getUrl(route: string): string {
      return '' + route;
  }

  public delete<T>(type: (new () => T), route: string, legajo: string):  Observable<T> {
    return of(new type());
  }

  public put<T>(type: (new () => T), route: string, objeto: any): Observable<T> {
    return of(new type());
  }
}
